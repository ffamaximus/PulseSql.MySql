using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.TestUtilities;
using PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests.Query
{
    public class CaseSensitiveNorthwindQueryMySqlFixture<TModelCustomizer> : NorthwindQueryMySqlFixture<TModelCustomizer>
        where TModelCustomizer : ITestModelCustomizer, new()
    {
        protected override string StoreName => "NorthwindCs";
        protected override ITestStoreFactory TestStoreFactory => MySqlNorthwindTestStoreFactory.InstanceCs;
    }
}
