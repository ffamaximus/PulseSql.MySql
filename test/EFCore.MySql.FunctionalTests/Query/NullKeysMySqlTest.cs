using PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests.Query
{
    public class NullKeysMySqlTest : NullKeysTestBase<NullKeysMySqlTest.NullKeysMySqlFixture>
    {
        public NullKeysMySqlTest(NullKeysMySqlFixture fixture)
            : base(fixture)
        {
        }

        public class NullKeysMySqlFixture : NullKeysFixtureBase
        {
            protected override ITestStoreFactory TestStoreFactory => MySqlTestStoreFactory.Instance;
        }
    }
}
