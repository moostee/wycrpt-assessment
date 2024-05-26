using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TransactionService.Infrastructure.Domain;
using Microsoft.Extensions.DependencyInjection;
using TransactionService.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Builder;

namespace TransactionService.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString, IConfiguration configuration)
        {
            services.AddDbContext<TransactionServiceContext>(option =>
           {
               option.UseSqlServer(connectionString, b =>
                {
                    b.MigrationsAssembly("TransactionService.Infrastructure");
                    b.EnableRetryOnFailure();
                });
           });

            services.AddScoped<ISqlConnectionFactory>(c =>
            {
                return new SqlConnectionFactory(connectionString);
            });

            services.AddRepositories();

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            try
            {
                var context = app.ApplicationServices.GetService<TransactionServiceContext>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                // TODO
            }
            return app;
        }
    }
}