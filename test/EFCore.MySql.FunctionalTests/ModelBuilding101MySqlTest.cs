using Microsoft.EntityFrameworkCore;
using PulseSql.EntityFrameworkCore.MySql.Tests;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests;

public class ModelBuilding101MySqlTest : ModelBuilding101RelationalTestBase
{
    protected override DbContextOptionsBuilder ConfigureContext(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(AppConfig.ServerVersion);
}
