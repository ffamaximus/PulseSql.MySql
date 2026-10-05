using Microsoft.EntityFrameworkCore.Query;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests.Query
{
    public class InheritanceRelationshipsQueryMySqlTest : InheritanceRelationshipsQueryRelationalTestBase<InheritanceRelationshipsQueryMySqlFixture>
    {
        public InheritanceRelationshipsQueryMySqlTest(InheritanceRelationshipsQueryMySqlFixture fixture)
            : base(fixture)
        {
        }
    }
}
