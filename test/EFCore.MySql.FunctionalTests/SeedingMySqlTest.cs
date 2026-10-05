using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;
using PulseSql.EntityFrameworkCore.MySql.Tests;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests
{
    public class SeedingMySqlTest : SeedingTestBase
    {
        protected override TestStore TestStore => MySqlTestStore.Create("SeedingTest");

        protected override SeedingContext CreateContextWithEmptyDatabase(string testId)
            => new SeedingMySqlContext(testId);

        protected class SeedingMySqlContext : SeedingContext
        {
            public SeedingMySqlContext(string testId)
                : base(testId)
            {
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseMySql(MySqlTestStore.CreateConnectionString($"Seeds{TestId}"), AppConfig.ServerVersion);
        }
    }
}
