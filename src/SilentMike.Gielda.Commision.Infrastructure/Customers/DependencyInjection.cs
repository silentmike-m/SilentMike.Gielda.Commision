namespace SilentMike.Gielda.Commision.Infrastructure.Customers;

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using SilentMike.Gielda.Commision.Application.Customers.Interfaces;
using SilentMike.Gielda.Commision.Domain.Customers.Interfaces;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Services;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddCustomers(this IServiceCollection services)
    {
        services
            .AddSingleton<ICustomerRepository, CustomerRepositoryMock>()
            .AddSingleton<ICustomerValidationService, CustomerValidationServiceMock>();

        return services;
    }
}
