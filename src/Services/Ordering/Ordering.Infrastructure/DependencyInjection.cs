using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
 using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");
        //Add servicess to the container.

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInertceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        services.AddDbContext<ApplicationDbContext>( (sp, options) =>
       {
           options.AddInterceptors(sp.GetService<ISaveChangesInterceptor>());
           options.UseSqlServer(connectionString);

       });

        //services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}
