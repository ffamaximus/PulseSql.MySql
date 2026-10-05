using Microsoft.EntityFrameworkCore;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests
{
    public class DatabindingMySqlTest : DataBindingTestBase<F1MySqlFixture>
    {
        public DatabindingMySqlTest(F1MySqlFixture fixture)
            : base(fixture)
        {
        }
    }
}
