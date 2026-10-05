using System.Collections.Generic;
using Xunit.Abstractions;

namespace PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities.Xunit;

public interface IMySqlTestClassOrderer
{
    IEnumerable<ITestClass> OrderTestClasses(IEnumerable<ITestClass> testClasses);
}
