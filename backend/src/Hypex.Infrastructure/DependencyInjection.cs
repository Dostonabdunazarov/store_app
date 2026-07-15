using Hypex.Application.Auth;
using Hypex.Application.Catalog;
using Hypex.Infrastructure.Auth;
using Hypex.Infrastructure.Catalog;
using Hypex.Application.Commerce;
using Hypex.Infrastructure.Commerce;
using Hypex.Infrastructure.Persistence;
using Hypex.Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hypex.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres")
            ?? throw new InvalidOperationException("Connection string 'Postgres' is not configured.");

        services.AddDbContext<HypexDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));

        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        services.AddSingleton<ITokenService, TokenService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICatalogService, CatalogService>();
        services.AddScoped<ICommerceService, CommerceService>();
        services.AddScoped<DataSeeder>();

        return services;
    }
}
