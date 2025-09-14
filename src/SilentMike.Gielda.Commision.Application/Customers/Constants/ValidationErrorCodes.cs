namespace SilentMike.Gielda.Commision.Application.Customers.Constants;

internal static class ValidationErrorCodes
{
    public static readonly string CUSTOMER_EMAIL_WRONG_FORMAT = nameof(CUSTOMER_EMAIL_WRONG_FORMAT);
    public static readonly string CUSTOMER_EMAIL_WRONG_FORMAT_MESSAGE = "Customer email has wrong format.";
    public static readonly string CUSTOMER_EMPTY_CITY = nameof(CUSTOMER_EMPTY_CITY);
    public static readonly string CUSTOMER_EMPTY_CITY_MESSAGE = "Customer address city can not be empty.";
    public static readonly string CUSTOMER_EMPTY_CONTACT = nameof(CUSTOMER_EMPTY_CONTACT);
    public static readonly string CUSTOMER_EMPTY_CONTACT_MESSAGE = "Customer contact e-mail or phone has to be provided.";
    public static readonly string CUSTOMER_EMPTY_DOCUMENT_NUMBER = nameof(CUSTOMER_EMPTY_DOCUMENT_NUMBER);
    public static readonly string CUSTOMER_EMPTY_DOCUMENT_NUMBER_MESSAGE = "Customer document number can not be empty.";
    public static readonly string CUSTOMER_EMPTY_FIRST_NAME = nameof(CUSTOMER_EMPTY_FIRST_NAME);
    public static readonly string CUSTOMER_EMPTY_FIRST_NAME_MESSAGE = "Customer first name can not be empty.";
    public static readonly string CUSTOMER_EMPTY_ID = nameof(CUSTOMER_EMPTY_ID);
    public static readonly string CUSTOMER_EMPTY_ID_MESSAGE = "Customer identifier can not be empty.";
    public static readonly string CUSTOMER_EMPTY_LAST_NAME = nameof(CUSTOMER_EMPTY_LAST_NAME);
    public static readonly string CUSTOMER_EMPTY_LAST_NAME_MESSAGE = "Customer last name can not be empty.";
    public static readonly string CUSTOMER_EMPTY_STREET = nameof(CUSTOMER_EMPTY_STREET);
    public static readonly string CUSTOMER_EMPTY_STREET_MESSAGE = "Customer address street can not be empty.";
    public static readonly string CUSTOMER_EMPTY_ZIP_CODE = nameof(CUSTOMER_EMPTY_ZIP_CODE);
    public static readonly string CUSTOMER_EMPTY_ZIP_CODE_MESSAGE = "Customer address zip code can not be empty.";
}
