using PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests
{
    public class NotificationEntitiesMySqlTest : NotificationEntitiesTestBase<NotificationEntitiesMySqlTest.NotificationEntitiesMySqlFixture>
    {
        public NotificationEntitiesMySqlTest(NotificationEntitiesMySqlFixture fixture)
            : base(fixture)
        {
        }

        public class NotificationEntitiesMySqlFixture : NotificationEntitiesFixtureBase
        {
            protected override ITestStoreFactory TestStoreFactory => MySqlTestStoreFactory.Instance;
        }
    }
}
