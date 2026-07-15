using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Hypex.Infrastructure.Persistence;

/// <summary>
/// Design-time factory so `dotnet ef` can build the context without booting the API.
/// Uses the local dev connection (Postgres on port 5440). Override with the
/// HYPEX_CONNECTION environment variable when running migrations elsewhere.
/// </summary>
public class HypexDbContextFactory : IDesignTimeDbContextFactory<HypexDbContext>
{
    public HypexDbContext CreateDbContext(string[] args)
    {
        var connection = Environment.GetEnvironmentVariable("HYPEX_CONNECTION")
            ?? "Host=127.0.0.1;Port=5440;Database=hypex;Username=hypex;Password=hypex_dev_pw";

        var options = new DbContextOptionsBuilder<HypexDbContext>()
            .UseNpgsql(connection)
            .Options;

        return new HypexDbContext(options);
    }
}
