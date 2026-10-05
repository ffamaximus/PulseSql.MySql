using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests
{
    public class CompositeKeyEndToEndMySqlTest : CompositeKeyEndToEndTestBase<CompositeKeyEndToEndMySqlTest.CompositeKeyEndToEndMySqlFixture>
    {
        public CompositeKeyEndToEndMySqlTest(CompositeKeyEndToEndMySqlFixture fixture)
            : base(fixture)
        {
        }

        public class CompositeKeyEndToEndMySqlFixture : CompositeKeyEndToEndFixtureBase
        {
            protected override ITestStoreFactory TestStoreFactory => MySqlTestStoreFactory.Instance;
        }
    }
}
