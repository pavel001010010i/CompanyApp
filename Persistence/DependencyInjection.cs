using Application.Interfaces;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {


        public static IServiceCollection AddPersistence(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts =>
                  opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>
                      b.MigrationsAssembly("WebApi")));

            services.AddScoped<IDbContext>(provider =>
                provider.GetService<AppDbContext>());

            return services;
        }
              
    }
}
