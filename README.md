# PulseSql.EntityFrameworkCore.MySql

[![Build status](https://github.com/PulseSql/PulseSql.EntityFrameworkCore.MySql/actions/workflows/build.yml/badge.svg?branch=main)](https://github.com/PulseSql/PulseSql.EntityFrameworkCore.MySql/actions/workflows/build.yml)
[![NuGet](https://img.shields.io/nuget/vpre/PulseSql.EntityFrameworkCore.MySql.svg?style=flat-square&label=NuGet)](https://www.nuget.org/packages/PulseSql.EntityFrameworkCore.MySql/)

Entity Framework Core provider for MySQL, MariaDB and other MySQL-compatible databases, built on
[MySqlConnector](https://mysqlconnector.net/).

PulseSql is a maintained fork of
[Pomelo.EntityFrameworkCore.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql)
whose goal is to track current EF Core releases. It is the first provider of the **PulseSql** family
of EF Core database providers.

## Compatibility

| PulseSql | EF Core | .NET  | MySqlConnector |
|----------|:-------:|:-----:|:--------------:|
| 10.0.x   | 10.0.x  | 10.0+ | >= 2.4.0       |

### Packages

| Package | Replaces |
|---|---|
| `PulseSql.EntityFrameworkCore.MySql` | `Pomelo.EntityFrameworkCore.MySql` |
| `PulseSql.EntityFrameworkCore.MySql.Json.Microsoft` | `Pomelo.EntityFrameworkCore.MySql.Json.Microsoft` |
| `PulseSql.EntityFrameworkCore.MySql.Json.Newtonsoft` | `Pomelo.EntityFrameworkCore.MySql.Json.Newtonsoft` |
| `PulseSql.EntityFrameworkCore.MySql.NetTopologySuite` | `Pomelo.EntityFrameworkCore.MySql.NetTopologySuite` |

### Tested database servers

MySQL 8.4, 8.0 · MariaDB 11.6, 11.5, 11.4 (LTS), 11.3, 10.11 (LTS), 10.6 (LTS), 10.5.

## Getting started

```xml
<PackageReference Include="PulseSql.EntityFrameworkCore.MySql" Version="10.0.0-preview.1" />
```

```csharp
var connectionString = "server=localhost;user=root;password=1234;database=ef";

// Use MariaDbServerVersion for MariaDB, or ServerVersion.AutoDetect(connectionString).
var serverVersion = new MySqlServerVersion(new Version(8, 4, 6));

builder.Services.AddDbContext<AppDbContext>(options => options
    .UseMySql(connectionString, serverVersion));
```

Scaffolding:

```
dotnet ef dbcontext scaffold "Server=localhost;User=root;Password=1234;Database=ef" "PulseSql.EntityFrameworkCore.MySql"
```

## Migrating from Pomelo

1. Replace the `Pomelo.EntityFrameworkCore.MySql*` package references with `PulseSql.EntityFrameworkCore.MySql*`.
2. Replace `using Pomelo.EntityFrameworkCore.MySql...` with `using PulseSql.EntityFrameworkCore.MySql...`
   (including existing migration `*.Designer.cs` and model snapshot files).
3. Nothing else needs regenerating: model annotations (`MySql:*`), the migrations history table and the helper
   stored procedures (`POMELO_BEFORE_DROP_PRIMARY_KEY`, `POMELO_AFTER_ADD_PRIMARY_KEY`) are intentionally
   unchanged, so existing databases and migrations keep working.
4. `Database.ProviderName` / `MigrationBuilder.ActiveProvider` now return `"PulseSql.EntityFrameworkCore.MySql"`.
   Prefer `Database.IsMySql()` / `migrationBuilder.IsMySql()` over comparing provider-name strings.
5. EF Core 10 behaviour changes apply, see the
   [EF Core 10 breaking changes](https://learn.microsoft.com/ef/core/what-is-new/ef-core-10.0/breaking-changes).

## Building

Requires the .NET 10 SDK (see `global.json`).

```
dotnet build PulseSql.EFCore.MySql.sln
dotnet test test/EFCore.MySql.Tests
```

Functional tests need a MySQL/MariaDB server: copy
`test/EFCore.MySql.FunctionalTests/config.json.example` to `config.json` and adjust the connection string.

See [MAINTENANCE.md](MAINTENANCE.md) for how this fork is kept in sync with upstream.

## License

[MIT](LICENSE). Original work © Pomelo Foundation; modifications © PulseSql contributors.
