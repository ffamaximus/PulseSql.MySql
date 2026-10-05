namespace PulseSql.EntityFrameworkCore.MySql.IntegrationTests.Commands
{

    public interface ICommandRunner
    {
        int Run(string[] args);
    }

}
