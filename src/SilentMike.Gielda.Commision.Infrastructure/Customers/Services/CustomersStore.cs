namespace SilentMike.Gielda.Commision.Infrastructure.Customers.Services;

using System.Diagnostics.CodeAnalysis;
using SilentMike.Gielda.Commision.Domain.Customers.Entities;
using SilentMike.Gielda.Commision.Domain.Types;

[ExcludeFromCodeCoverage]
internal static class CustomersStore
{
    public static Dictionary<CustomerId, CustomerEntity> Customers { get; } = new();
}
