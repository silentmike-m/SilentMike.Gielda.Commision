namespace SilentMike.Gielda.Commision.Infrastructure;

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using SilentMike.Gielda.Commision.Infrastructure.Customers;
using SilentMike.Gielda.Commision.Infrastructure.RepositoryMock;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddRepositoryMock()
            .AddCustomers();

        return services;
    }
}
