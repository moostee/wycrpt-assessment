using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TransactionService.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(assemblies: Assemblies.Application);
        return services;
    }
}