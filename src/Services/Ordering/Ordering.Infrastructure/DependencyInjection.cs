using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");
        // Add servicess to the container.
        //services.AddDbContext<ApplicationDbContex>(options =>
        //options.UseSqlServer(connectionString));

        //services.AddScoped<IApplicationDbContex, ApplicationDbContex>();

        return services;
    }
}
