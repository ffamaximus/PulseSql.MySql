using System;
using System.Threading.Tasks;

namespace PulseSql.EntityFrameworkCore.MySql.IntegrationTests.Commands
{

    public interface ITestPerformanceRunner
    {
        Task ConnectionTask(Func<AppDb, Task> cb, int ops);
    }

}
