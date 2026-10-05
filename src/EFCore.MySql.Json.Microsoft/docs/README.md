## About

_PulseSql.EntityFrameworkCore.MySql.Json.Microsoft_ adds JSON support for `System.Text.Json` (the Microsoft JSON stack) to [PulseSql.EntityFrameworkCore.MySql](https://github.com/PulseSql/PulseSql.EntityFrameworkCore.MySql).

> PulseSql is a maintained fork of [Pomelo.EntityFrameworkCore.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql) that tracks current EF Core releases. Namespaces were renamed from `Pomelo.*` to `PulseSql.*`; database-level objects and model annotations remain compatible.

## How to Use

```csharp
optionsBuilder.UseMySql(
    connectionString,
    serverVersion,
    options => options.UseMicrosoftJson())
```

## Related Packages

* [PulseSql.EntityFrameworkCore.MySql](https://www.nuget.org/packages/PulseSql.EntityFrameworkCore.MySql)
* [System.Text.Json](https://www.nuget.org/packages/System.Text.Json)

## License

_PulseSql.EntityFrameworkCore.MySql.Json.Microsoft_ is released as open source under the [MIT license](https://github.com/PulseSql/PulseSql.EntityFrameworkCore.MySql/blob/main/LICENSE).

## Feedback

Bug reports and contributions are welcome at our [GitHub repository](https://github.com/PulseSql/PulseSql.EntityFrameworkCore.MySql).