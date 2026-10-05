using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests.Query
{
    public class ManyToManyQueryMySqlFixture : ManyToManyQueryRelationalFixture
    {
        protected override ITestStoreFactory TestStoreFactory
            => MySqlTestStoreFactory.Instance;
    }
}
