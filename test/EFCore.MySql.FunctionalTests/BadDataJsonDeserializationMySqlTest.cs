using Microsoft.EntityFrameworkCore;
using PulseSql.EntityFrameworkCore.MySql.Tests;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests;

public class BadDataJsonDeserializationMySqlTest : BadDataJsonDeserializationTestBase
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => base.OnConfiguring(optionsBuilder.UseMySql(AppConfig.ServerVersion, b => b.UseNetTopologySuite()));
}
