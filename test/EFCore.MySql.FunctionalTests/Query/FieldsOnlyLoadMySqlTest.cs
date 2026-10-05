using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests.Query
{
    public class FieldsOnlyLoadMySqlTest : FieldsOnlyLoadTestBase<FieldsOnlyLoadMySqlTest.FieldsOnlyLoadMySqlFixture>
    {
        public FieldsOnlyLoadMySqlTest(FieldsOnlyLoadMySqlFixture fixture)
            : base(fixture)
        {
        }

        public class FieldsOnlyLoadMySqlFixture : FieldsOnlyLoadFixtureBase
        {
            protected override ITestStoreFactory TestStoreFactory
                => MySqlTestStoreFactory.Instance;
        }
    }
}
