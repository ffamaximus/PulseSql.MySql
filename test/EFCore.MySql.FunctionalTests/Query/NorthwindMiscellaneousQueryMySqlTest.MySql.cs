using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PulseSql.EntityFrameworkCore.MySql.Infrastructure;
using PulseSql.EntityFrameworkCore.MySql.Storage;
using PulseSql.EntityFrameworkCore.MySql.Tests.TestUtilities.Attributes;
using Xunit;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests.Query
{
    public partial class NorthwindMiscellaneousQueryMySqlTest
    {
        [ConditionalTheory]
        [MemberData(nameof(IsAsyncData))]
        [SupportedServerVersionLessThanCondition(nameof(ServerVersionSupport.WindowFunctions))]
        public virtual Task RowNumberOverPartitionBy_not_supported_throws(bool async)
        {
            return Assert.ThrowsAsync<InvalidOperationException>(() => base.SelectMany_Joined_Take(async));
        }
    }
}
