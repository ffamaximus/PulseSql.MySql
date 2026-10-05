using PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests
{
    public class MySqlServiceCollectionExtensionsTest : RelationalServiceCollectionExtensionsTestBase
    {
        public MySqlServiceCollectionExtensionsTest()
            : base(MySqlTestHelpers.Instance)
        {
        }
    }
}
