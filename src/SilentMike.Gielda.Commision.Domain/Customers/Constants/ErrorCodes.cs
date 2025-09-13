namespace SilentMike.Gielda.Commision.Domain.Customers.Constants;

internal static class ErrorCodes
{
    public static readonly string ADDRESS_EMPTY_CITY = nameof(ADDRESS_EMPTY_CITY);
    public static readonly string ADDRESS_EMPTY_STREET = nameof(ADDRESS_EMPTY_STREET);
    public static readonly string ADDRESS_EMPTY_ZIP_CODE = nameof(ADDRESS_EMPTY_ZIP_CODE);
    public static readonly string CONTACT_EMPTY = nameof(CONTACT_EMPTY);
    public static readonly string CONTACT_INVALID_EMAIL_FORMAT = nameof(CONTACT_INVALID_EMAIL_FORMAT);
    public static readonly string CUSTOMER_EMPTY_FIRST_NAME = nameof(CUSTOMER_EMPTY_FIRST_NAME);
    public static readonly string CUSTOMER_EMPTY_LAST_NAME = nameof(CUSTOMER_EMPTY_LAST_NAME);
    public static readonly string DOCUMENT_EMPTY_NUMBER = nameof(DOCUMENT_EMPTY_NUMBER);
}
