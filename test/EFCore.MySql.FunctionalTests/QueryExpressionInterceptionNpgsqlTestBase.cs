using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;
using PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities;
using PulseSql.EntityFrameworkCore.MySql.Storage.Internal;
using Xunit;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests;

public abstract class QueryExpressionInterceptionMySqlTestBase : QueryExpressionInterceptionTestBase
{
    protected QueryExpressionInterceptionMySqlTestBase(InterceptionMySqlFixtureBase fixture)
        : base(fixture)
    {
    }

    public abstract class InterceptionMySqlFixtureBase : InterceptionFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => MySqlTestStoreFactory.Instance;

        protected override IServiceCollection InjectInterceptors(
            IServiceCollection serviceCollection,
            IEnumerable<IInterceptor> injectedInterceptors)
            => base.InjectInterceptors(serviceCollection.AddEntityFrameworkMySql(), injectedInterceptors);

        public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
        {
            new MySqlDbContextOptionsBuilder(base.AddOptions(builder))
                .ExecutionStrategy(d => new MySqlExecutionStrategy(d));
            return builder;
        }
    }

    public class QueryExpressionInterceptionMySqlTest
        : QueryExpressionInterceptionMySqlTestBase, IClassFixture<QueryExpressionInterceptionMySqlTest.InterceptionMySqlFixture>
    {
        public QueryExpressionInterceptionMySqlTest(InterceptionMySqlFixture fixture)
            : base(fixture)
        {
        }

        public class InterceptionMySqlFixture : InterceptionMySqlFixtureBase
        {
            protected override string StoreName
                => "QueryExpressionInterception";

            protected override bool ShouldSubscribeToDiagnosticListener
                => false;
        }
    }

    public class QueryExpressionInterceptionWithDiagnosticsMySqlTest
        : QueryExpressionInterceptionMySqlTestBase,
            IClassFixture<QueryExpressionInterceptionWithDiagnosticsMySqlTest.InterceptionMySqlFixture>
    {
        public QueryExpressionInterceptionWithDiagnosticsMySqlTest(InterceptionMySqlFixture fixture)
            : base(fixture)
        {
        }

        public class InterceptionMySqlFixture : InterceptionMySqlFixtureBase
        {
            protected override string StoreName
                => "QueryExpressionInterceptionWithDiagnostics";

            protected override bool ShouldSubscribeToDiagnosticListener
                => true;
        }
    }
}
