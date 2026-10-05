## About

_PulseSql.EntityFrameworkCore.MySql.Json.Newtonsoft_ adds JSON support for `Newtonsoft.Json` (the Newtonsoft JSON/Json.NET stack) to [PulseSql.EntityFrameworkCore.MySql](https://github.com/PulseSql/PulseSql.EntityFrameworkCore.MySql).

> PulseSql is a maintained fork of [Pomelo.EntityFrameworkCore.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql) that tracks current EF Core releases. Namespaces were renamed from `Pomelo.*` to `PulseSql.*`; database-level objects and model annotations remain compatible.

## How to Use

```csharp
optionsBuilder.UseMySql(
    connectionString,
    serverVersion,
    options => options.UseNewtonsoftJson())
```

## Related Packages

* [PulseSql.EntityFrameworkCore.MySql](https://www.nuget.org/packages/PulseSql.EntityFrameworkCore.MySql)
* [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json)

## License

_PulseSql.EntityFrameworkCore.MySql.Json.Newtonsoft_ is released as open source under the [MIT license](https://github.com/PulseSql/PulseSql.EntityFrameworkCore.MySql/blob/main/LICENSE).

## Feedback

Bug reports and contributions are welcome at our [GitHub repository](https://github.com/PulseSql/PulseSql.EntityFrameworkCore.MySql).