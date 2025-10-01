using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Domain.Interfaces;
using WebApp.Infrastructure.Persistance;
using WebApp.Infrastructure.Repositories;
using WebApp.Infrastructure.Seeders;

namespace WebApp.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
          services.AddDbContext<WebAppDbContext>(options => options.UseSqlServer(
              configuration.GetConnectionString("WebApp"),
              b=>b.MigrationsAssembly("WebApp.Infrastructure")
              ));

            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IDSLRepository, DSLRepository>();
            services.AddScoped<ModemSeeder>();
            services.AddScoped<DSLSeeder>();

                
        }
    }
}
