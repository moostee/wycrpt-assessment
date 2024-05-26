using Microsoft.Extensions.DependencyInjection;
using TransactionService.Domain;

namespace TransactionService.Infrastructure.Domain
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITransactionHistoryRepository, TransactionHistoryRepository>();
            return services;
        }
    }
}