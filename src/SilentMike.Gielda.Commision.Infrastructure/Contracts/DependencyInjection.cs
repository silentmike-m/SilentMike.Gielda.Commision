namespace SilentMike.Gielda.Commision.Infrastructure.Contracts;

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using SilentMike.Gielda.Commision.Infrastructure.Contracts.Interfaces;

[ExcludeFromCodeCoverage]
internal static class DependencyInjection
{
    public static IServiceCollection AddContracts(this IServiceCollection services)
    {
        services.AddSingleton<IContractMapper, IContractMapper>();

        return services;
    }
}
