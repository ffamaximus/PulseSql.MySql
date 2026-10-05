using Microsoft.EntityFrameworkCore;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests
{
    public class SerializationMySqlTest : SerializationTestBase<F1MySqlFixture>
    {
        public SerializationMySqlTest(F1MySqlFixture fixture)
            : base(fixture)
        {
        }
    }
}
