using Aspire.PostgreSQLSample.MigrationEntry.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Aspire.PostgreSQLSample.Migrations;

public class MigrationsContextFactory : IDesignTimeDbContextFactory<PostgresContext>
{
    public PostgresContext CreateDbContext(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(builder => builder
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables())
            .ConfigureServices(services => services
                .AddDbContext<PostgresContext>(
                dbOptions => dbOptions
                    .EnableSensitiveDataLogging()
                    .UseSnakeCaseNamingConvention()
                    .UseNpgsql(
                        "Name=NpgsqlConnection",
                        serverOption => serverOption
                            .MigrationsHistoryTable("__migrations_history", "dbo")
                            .MigrationsAssembly("Aspire.PostgreSQLSample.MigrationEntry")),
                ServiceLifetime.Singleton,
                ServiceLifetime.Singleton))
            .Build();
        
        var dbContext = host.Services.GetRequiredService<PostgresContext>();

        return dbContext;
    }
}
