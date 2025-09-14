namespace SilentMike.Gielda.Commision.Infrastructure;

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using SilentMike.Gielda.Commision.Infrastructure.Customers;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddCustomers();

        return services;
    }
}
