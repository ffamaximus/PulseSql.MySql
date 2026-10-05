using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests
{
    public class OverzealousInitializationMySqlTest
        : OverzealousInitializationTestBase<OverzealousInitializationMySqlTest.OverzealousInitializationMySqlFixture>
    {
        public OverzealousInitializationMySqlTest(OverzealousInitializationMySqlFixture fixture)
            : base(fixture)
        {
        }

        public class OverzealousInitializationMySqlFixture : OverzealousInitializationFixtureBase
        {
            protected override ITestStoreFactory TestStoreFactory => MySqlTestStoreFactory.Instance;
        }
    }
}
