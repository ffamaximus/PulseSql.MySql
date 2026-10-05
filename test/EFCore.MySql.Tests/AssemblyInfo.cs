// #define FIXED_TEST_ORDER

using Xunit;

//
// Optional: Control the test execution order.
//           This can be helpful for diffing etc.
//

#if FIXED_TEST_ORDER

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly, DisableTestParallelization = true, MaxParallelThreads = 1)]
[assembly: TestCollectionOrderer("PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities.Xunit.MySqlTestCollectionOrderer", "PulseSql.EntityFrameworkCore.MySql.FunctionalTests")]
[assembly: TestCaseOrderer("PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities.Xunit.MySqlTestCaseOrderer", "PulseSql.EntityFrameworkCore.MySql.FunctionalTests")]

#endif

// Our custom MySqlXunitTestFrameworkDiscoverer class allows filtering whole classes like SupportedServerVersionConditionAttribute, instead
// of just the test cases. This is necessary, if a fixture is database server version dependent.
[assembly: TestFramework("PulseSql.EntityFrameworkCore.MySql.FunctionalTests.TestUtilities.Xunit.MySqlXunitTestFramework", "PulseSql.EntityFrameworkCore.MySql.FunctionalTests")]
