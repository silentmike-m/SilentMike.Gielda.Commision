namespace SilentMike.Gielda.Commision.Infrastructure.RepositoryMock;

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using SilentMike.Gielda.Commision.Domain.Customers.Interfaces;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Interfaces;
using SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Interfaces;
using SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Services;

[ExcludeFromCodeCoverage]
internal static class DependencyInjection
{
    public static IServiceCollection AddRepositoryMock(this IServiceCollection services)
    {
        services.AddSingleton<ICustomerDbMapper, CustomerDbMapper>();

        services
            .AddSingleton<ICustomerRepository, CustomerRepositoryMock>()
            .AddSingleton<ICustomerReadService, CustomerReadServiceMock>();

        return services;
    }
}
