namespace SilentMike.Gielda.Commision.WebApi.Mappers;

using System.Diagnostics.CodeAnalysis;
using SilentMike.Gielda.Commision.WebApi.Mappers.Interfaces;
using SilentMike.Gielda.Commision.WebApi.Mappers.Services;

[ExcludeFromCodeCoverage]
internal static class DependencyInjection
{
    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        services.AddSingleton<ICustomerMapper, CustomerMapper>();

        return services;
    }
}
