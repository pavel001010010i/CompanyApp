
using Contracts.Managers;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Managers;

namespace CompanyApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCORS(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });


        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
                services.AddDbContext<RepositoryContext>(opts =>
                    opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>
                        b.MigrationsAssembly("CompanyApp")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}
