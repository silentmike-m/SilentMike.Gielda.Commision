namespace SilentMike.Gielda.Commision.Infrastructure;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SilentMike.Gielda.Commision.Infrastructure.Contracts;
using SilentMike.Gielda.Commision.Infrastructure.Customers;
using SilentMike.Gielda.Commision.Infrastructure.RepositoryMock;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        services
            .AddRepositoryMock()
            .AddContracts()
            .AddCustomers();

        return services;
    }
}
