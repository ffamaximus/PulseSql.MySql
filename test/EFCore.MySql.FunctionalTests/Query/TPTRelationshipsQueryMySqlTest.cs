using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;
using Xunit.Abstractions;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests.Query
{
    public class TPTRelationshipsQueryMySqlTest
        : TPTRelationshipsQueryTestBase<TPTRelationshipsQueryMySqlTest.TPTRelationshipsQueryMySqlFixture>
    {
        public TPTRelationshipsQueryMySqlTest(
            TPTRelationshipsQueryMySqlFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture)
            => fixture.TestSqlLoggerFactory.Clear();

        public class TPTRelationshipsQueryMySqlFixture : TPTRelationshipsQueryRelationalFixture
        {
            protected override ITestStoreFactory TestStoreFactory
                => MySqlTestStoreFactory.Instance;
        }
    }
}
