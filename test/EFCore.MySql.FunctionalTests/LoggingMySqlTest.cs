using System;
using System.Reflection;
using PulseSql.EntityFrameworkCore.MySql.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;
using PulseSql.EntityFrameworkCore.MySql.Diagnostics.Internal;
using PulseSql.EntityFrameworkCore.MySql.Tests;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests
{
    // TODO: Reenable once this issue has been fixed in EF Core upstream.
    // Skip because LoggingTestBase uses the wrong order:
    // Wrong:   DefaultOptions + "NoTracking"
    // Correct: "NoTracking" + DefaultOptions
    // The order in LoggingRelationalTestBase<,> is correct though.
    internal class LoggingMySqlTest : LoggingRelationalTestBase<MySqlDbContextOptionsBuilder, MySqlOptionsExtension>
    {
        protected override DbContextOptionsBuilder CreateOptionsBuilder(
            IServiceCollection services,
            Action<RelationalDbContextOptionsBuilder<MySqlDbContextOptionsBuilder, MySqlOptionsExtension>> relationalAction)
            => new DbContextOptionsBuilder()
                .UseInternalServiceProvider(services.AddEntityFrameworkMySql().BuildServiceProvider(validateScopes: true))
                .UseMySql("Database=DummyDatabase", AppConfig.ServerVersion, relationalAction);

        protected override TestLogger CreateTestLogger()
            => new TestLogger<MySqlLoggingDefinitions>();

        protected override string ProviderName => "PulseSql.EntityFrameworkCore.MySql";

        protected override string ProviderVersion => typeof(MySqlOptionsExtension).Assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            ?.InformationalVersion;

        protected override string DefaultOptions => $"ServerVersion {AppConfig.ServerVersion} ";
    }
}
