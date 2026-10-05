using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.TestUtilities;
using PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests.Query;

public class AdHocManyToManyQueryMySqlTest(NonSharedFixture fixture) : AdHocManyToManyQueryRelationalTestBase(fixture)
{
    protected override ITestStoreFactory TestStoreFactory
        => MySqlTestStoreFactory.Instance;
}
