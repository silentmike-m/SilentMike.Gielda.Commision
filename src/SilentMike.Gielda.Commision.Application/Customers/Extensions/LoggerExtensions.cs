namespace SilentMike.Gielda.Commision.Application.Customers.Extensions;

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;

[ExcludeFromCodeCoverage]
internal static class LoggerExtensions
{
    private static readonly Action<ILogger, Guid, Exception?> LOG_UPSERTING_CUSTOMER
        = LoggerMessage.Define<Guid>(LogLevel.Information, eventId: 1, "Try to upsert customer with id '{CustomerId}'");

    public static void LogUpsertingCustomer(this ILogger logger, Guid customerId)
        => LOG_UPSERTING_CUSTOMER(logger, customerId, arg3: null);
}
