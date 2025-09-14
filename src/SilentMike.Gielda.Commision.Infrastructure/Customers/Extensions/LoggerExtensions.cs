namespace SilentMike.Gielda.Commision.Infrastructure.Customers.Extensions;

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;

[ExcludeFromCodeCoverage]
internal static class LoggerExtensions
{
    private static readonly Action<ILogger, Guid, Exception?> LOG_GETTING_CUSTOMER
        = LoggerMessage.Define<Guid>(LogLevel.Information, eventId: 1, "Try to get customer with id '{CustomerId}'");

    private static readonly Action<ILogger, Exception?> LOG_GETTING_CUSTOMERS
        = LoggerMessage.Define(LogLevel.Information, eventId: 1, "Try to get customers");

    public static void LogGettingCustomer(this ILogger logger, Guid customerId)
        => LOG_GETTING_CUSTOMER(logger, customerId, arg3: null);

    public static void LogGettingCustomers(this ILogger logger)
        => LOG_GETTING_CUSTOMERS(logger, arg2: null);
}
