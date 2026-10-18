# Mantenimiento del fork

## Origen

| Capa | Origen | Commit |
|---|---|---|
| Base | `PomeloFoundation/Pomelo.EntityFrameworkCore.MySql` rama `main` (9.0.1) | `14c2cd55` |
| Port a EF Core 10 | Pomelo PR [#2043](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql/pull/2043) (Felipe Quintella + HoboCY) | `a5d9eabb` |
| Rebrand PulseSql | este repo | ver `git log` |

Alternativas evaluadas (oct-2026):

- PR [#2019](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql/pull/2019) de Laurents Meyer
  (mantenedor de Pomelo): port mínimo a EF Core 10.0.0, sin actividad desde nov-2025. Útil como referencia.
- Fork de Microting (`Microting.EntityFrameworkCore.MySql`): ya en 10.0.12 con rama `net11`, pero con ~1400 commits
  propios y algunos cambios de comportamiento discutibles (p. ej. desactivar `MySqlBugLimit0Offset0ExistsWorkaround`
  "para cuadrar baselines"). Útil para buscar fixes puntuales, no como base.

## Remotos

```bash
git remote add upstream https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql.git
git remote add microting https://github.com/microting/Pomelo.EntityFrameworkCore.MySql.git   # opcional, referencia
```

## Traer cambios de upstream

El rebrand es un único commit casi mecánico, así que los merges desde upstream funcionan bien:

```bash
git fetch upstream
git merge upstream/main          # o: git fetch upstream pull/<N>/head:pr<N> && git merge pr<N>
```

Si aparecen archivos nuevos con `Pomelo.EntityFrameworkCore.MySql`, vuelve a ejecutar el script de rebrand
(`tools/rebrand.py`), que es idempotente:

```bash
python3 tools/rebrand.py . "$(cat tools/PulseSql.publickey.txt)"
```

Qué NO se renombra a propósito:

- Cabeceras `Copyright (c) Pomelo Foundation` (atribución MIT obligatoria).
- Procedimientos `POMELO_BEFORE_DROP_PRIMARY_KEY` / `POMELO_AFTER_ADD_PRIMARY_KEY` y prefijo de anotaciones `MySql:`
  (compatibilidad con bases y migraciones existentes).
- Enlaces a issues/PRs de upstream.

## Subir de versión de EF Core

1. `Directory.Packages.props` → `EFCoreVersion` y paquetes `Microsoft.Extensions.*`/`AspNetCore`.
2. `global.json` → SDK.
3. `Version.props` → `VersionPrefix` (seguimos la versión mayor/menor de EF Core).
4. `dotnet build` → corregir APIs; `dotnet test` contra MySQL y MariaDB; actualizar baselines SQL.
5. Para EF Core 11: crear rama `11.0-wip`; mantener `10.0-maint` para servicing.

## Publicación (`.github/workflows/release.yml`)

Flujo: **Prepare** (versión desde el tag) → **Test** (unit + funcionales de humo contra MySQL 8.4 y MariaDB 11.4)
→ **Pack** (4 `.nupkg` + `.snupkg`, verificados) → **Publish** (nuget.org + adjunta paquetes al Release).

Configuración única:

1. En nuget.org: *API Keys → Create*, scope **Push new packages and package versions**, glob
   `PulseSql.EntityFrameworkCore.MySql*`, expiración 365 días (anota la fecha para rotarla).
2. En GitHub: *Settings → Environments → New environment* `nuget`; agrega el secreto `NUGET_API_KEY`.
   Opcional: *Required reviewers* para aprobar manualmente cada push.

Publicar una versión:

1. Ajusta `Version.props` (`VersionPrefix`, `PreReleaseVersionLabel`, `PreReleaseVersionIteration`) y haz push.
2. Crea un Release con tag igual a la versión: `v10.0.0-preview.1` (marca *pre-release*) o `v10.0.0` para estable.
   Si el tag no coincide con `Version.props`, el job **Pack** falla y no se publica nada.

Ensayo sin publicar: *Actions → Release → Run workflow* con la versión (opcional `full_functional_tests`);
los paquetes quedan como artifact del run.

`build.yml` es la CI completa heredada de Pomelo (2 SO × 9 BD) y ya no publica; su job `NuGet` solo empaqueta
si la variable `PULSESQL_CI_PACK=true`.

## Clave de strong-name

`PulseSql.snk` es una clave nueva (no compatible con la de Pomelo). Como en la mayoría de proyectos OSS de .NET,
se versiona en el repo: el strong-name sirve para identidad, no como mecanismo de seguridad.
