using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using PulseSql.EntityFrameworkCore.MySql.Design.Internal;
using PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests
{
    public class DesignTimeMySqlTest : DesignTimeTestBase<DesignTimeMySqlTest.DesignTimeMySqlFixture>
    {
        public DesignTimeMySqlTest(DesignTimeMySqlFixture fixture)
            : base(fixture)
        {
        }

        protected override Assembly ProviderAssembly
            => typeof(MySqlDesignTimeServices).Assembly;

        public class DesignTimeMySqlFixture : DesignTimeFixtureBase
        {
            protected override ITestStoreFactory TestStoreFactory
                => MySqlTestStoreFactory.Instance;
        }
    }
}
