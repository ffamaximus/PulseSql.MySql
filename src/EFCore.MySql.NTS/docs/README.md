## About

_PulseSql.EntityFrameworkCore.MySql.NetTopologySuite_ adds spatial support for [NetTopologySuite](https://github.com/NetTopologySuite/NetTopologySuite) to [PulseSql.EntityFrameworkCore.MySql](https://github.com/PulseSql/PulseSql.EntityFrameworkCore.MySql).

> PulseSql is a maintained fork of [Pomelo.EntityFrameworkCore.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql) that tracks current EF Core releases. Namespaces were renamed from `Pomelo.*` to `PulseSql.*`; database-level objects and model annotations remain compatible.

## How to Use

```csharp
optionsBuilder.UseMySql(
    connectionString,
    serverVersion,
    options => options.UseNetTopologySuite())
```

## Related Packages

* [PulseSql.EntityFrameworkCore.MySql](https://www.nuget.org/packages/PulseSql.EntityFrameworkCore.MySql)
* [NetTopologySuite](https://www.nuget.org/packages/NetTopologySuite)

## License

_PulseSql.EntityFrameworkCore.MySql.NetTopologySuite_ is released as open source under the [MIT license](https://github.com/PulseSql/PulseSql.EntityFrameworkCore.MySql/blob/main/LICENSE).

## Feedback

Bug reports and contributions are welcome at our [GitHub repository](https://github.com/PulseSql/PulseSql.EntityFrameworkCore.MySql).