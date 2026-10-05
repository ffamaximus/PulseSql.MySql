using System;
using PulseSql.EntityFrameworkCore.MySql.Tests;

namespace PulseSql.EntityFrameworkCore.MySql.IntegrationTests.Commands
{
    public class ConnectionStringCommand : IConnectionStringCommand
    {
        public void Run()
        {
            Console.Write(AppConfig.ConnectionString);
        }
    }
}
