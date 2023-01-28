using ItraMessenger.WEB.Data.Contexts;
using ItraMessenger.WEB.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace ItraMessenger.WEB.Data.Configuration;

public static class PersistenceConfiguration
{
    public static IServiceCollection ConfigurePersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(ConnectionHelper.GetConnectionString(configuration)));
        return services;
    }
}