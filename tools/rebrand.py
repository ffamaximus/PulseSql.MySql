#!/usr/bin/env python3
"""Usage: python3 tools/rebrand.py <repo-root> "$(cat tools/PulseSql.publickey.txt)"

Rebrand Pomelo.EntityFrameworkCore.MySql -> PulseSql.EntityFrameworkCore.MySql.

Deliberately NOT renamed (compat / legal):
  * "Copyright (c) Pomelo Foundation" source headers (MIT attribution).
  * Database-facing identifiers (POMELO_BEFORE_DROP_PRIMARY_KEY, ...) so existing
    databases/migrations created with Pomelo keep working.
  * Links to upstream issues/PRs (github.com/PomeloFoundation/.../issues|pull/N).
  * Annotation prefix "MySql:" (unchanged upstream anyway) -> existing model snapshots stay valid.
"""
import os, re, subprocess, sys

ROOT = sys.argv[1]
PUBKEY = sys.argv[2]
OLD_PUBKEY = ("00240000048000009400000006020000002400005253413100040000010001002d40e2372e6f611238ace2bf7c80546c03a568c471495b6c91b89de694de5413"
              "b25ac77a005a371c46f15ab87f13d49ec7aa9bbd9fa99d8f51deb1d87c42d81047aa118519d9813bd5973e8cc8d17d8e5e5e865bce62518aa46e2348dac3db36"
              "38b00b9a8df69e1158e4ea82913b6a14c19c07fe473e7511ce91c1b7f41155cf")

TEXT_EXT = {'.cs', '.csproj', '.props', '.targets', '.sln', '.json', '.md', '.yml', '.yaml', '.resx', '.tt', '.xml',
            '.sh', '.ps1', '.cmd', '.txt', '.config', '.ruleset', '.editorconfig', '', '.sample', '.sql', '.cshtml', '.csbak'}

# Any link to the upstream repository is kept as-is (attribution / issue references).
PROTECT = [
    re.compile(r'https?://github\.com/PomeloFoundation/Pomelo\.EntityFrameworkCore\.MySql[^\s)"\'<>]*'),
]

# Hand-written docs that intentionally mention the upstream package names.
SKIP = {'README.md', 'MAINTENANCE.md', 'tools/rebrand.py'}
SKIP_RX = re.compile(r'^src/[^/]+/docs/README\.md$')

REPLACEMENTS = [
    ('Pomelo.EntityFrameworkCore.MySql', 'PulseSql.EntityFrameworkCore.MySql'),
    ('Pomelo.EFCore.MySql', 'PulseSql.EFCore.MySql'),
    ('namespace Pomelo.EntityFrameworkCore.TestUtilities', 'namespace PulseSql.EntityFrameworkCore.TestUtilities'),
    ('PomeloTestTargetFramework', 'PulseSqlTestTargetFramework'),
    ('PomeloTargetFramework', 'PulseSqlTargetFramework'),
    ('Pomelo.snk', 'PulseSql.snk'),
    ("Pomelo's MySQL", "PulseSql's MySQL"),
    (OLD_PUBKEY, PUBKEY),
]

def tracked_files():
    out = subprocess.check_output(['git', '-C', ROOT, 'ls-files', '-z']).decode('utf-8')
    return [f for f in out.split('\0') if f]

def is_text(path):
    _, ext = os.path.splitext(path)
    return ext.lower() in TEXT_EXT or os.path.basename(path) in ('Makefile', 'CODEOWNERS')

changed = 0
for rel in tracked_files():
    p = os.path.join(ROOT, rel)
    if not os.path.isfile(p) or not is_text(rel) or rel in SKIP or SKIP_RX.match(rel):
        continue
    raw = open(p, 'rb').read()
    try:
        s = raw.decode('utf-8')
    except UnicodeDecodeError:
        continue
    keep = {}
    def stash(m):
        k = f'\x00{len(keep)}\x00'
        keep[k] = m.group(0)
        return k
    t = s
    for rx in PROTECT:
        t = rx.sub(stash, t)
    for a, b in REPLACEMENTS:
        t = t.replace(a, b)
    for k, v in keep.items():
        t = t.replace(k, v)
    if t != s:
        open(p, 'wb').write(t.encode('utf-8'))
        changed += 1

# File/dir renames
renamed = 0
for rel in sorted(tracked_files(), key=len, reverse=True):
    base = os.path.basename(rel)
    if 'Pomelo' in base:
        new = os.path.join(os.path.dirname(rel), base.replace('Pomelo.EntityFrameworkCore.MySql', 'PulseSql.EntityFrameworkCore.MySql')
                           .replace('Pomelo.EFCore.MySql', 'PulseSql.EFCore.MySql'))
        if new != rel:
            subprocess.check_call(['git', '-C', ROOT, 'mv', rel, new])
            renamed += 1
print(f'content changed: {changed}, files renamed: {renamed}')
