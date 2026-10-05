using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests.Query;

public class OptionalDependentQueryMySqlFixture : OptionalDependentQueryFixtureBase
{
    protected override ITestStoreFactory TestStoreFactory
        => MySqlTestStoreFactory.Instance;
}
