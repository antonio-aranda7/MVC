//using CompanyEmployees.Contracts;
using Microsoft.EntityFrameworkCore;
//using CompanyEmployees.Repository;
using MVC.Data;

namespace CompanyEmployees.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("MyPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        /*public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });*/

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<MVCContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("MVCContext"), b => b.MigrationsAssembly("MVC")));

        /*public static void ConfigureRepositoryManager(this IServiceCollection services) =>
           services.AddScoped<IRepositoryManager, RepositoryManager>();*/

    }
}
