using Exile_Pinboard.Shared;

namespace Exile_Pinboard.TestAppHost;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        builder
            .AddSqlite(Services.TestDatabase);

        builder.Build().Run();
    }
}
