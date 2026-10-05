using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;
using PulseSql.EntityFrameworkCore.MySql.Tests;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests
{
    public class KeysWithConvertersMySqlTest : KeysWithConvertersTestBase<
        KeysWithConvertersMySqlTest.KeysWithConvertersMySqlFixture>
    {
        public KeysWithConvertersMySqlTest(KeysWithConvertersMySqlFixture fixture)
            : base(fixture)
        {
        }

        public class KeysWithConvertersMySqlFixture : KeysWithConvertersFixtureBase
        {
            protected override ITestStoreFactory TestStoreFactory
                => MySqlTestStoreFactory.Instance;

            public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
                => builder.UseMySql(AppConfig.ServerVersion, b => b.MinBatchSize(1));
        }
    }
}
