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

## Publicación

El job `NuGet` de `.github/workflows/build.yml` solo corre si la variable de repositorio `PULSESQL_PUBLISH=true`.
Publica en nuget.org al crear un *release* con tag `X.Y.Z[-sufijo]` usando el secreto `NUGET_API_KEY`.

## Clave de strong-name

`PulseSql.snk` es una clave nueva (no compatible con la de Pomelo). Como en la mayoría de proyectos OSS de .NET,
se versiona en el repo: el strong-name sirve para identidad, no como mecanismo de seguridad.
