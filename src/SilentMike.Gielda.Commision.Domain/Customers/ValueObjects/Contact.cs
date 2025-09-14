namespace SilentMike.Gielda.Commision.Domain.Customers.ValueObjects;

using System.Text.RegularExpressions;
using SilentMike.Gielda.Commision.Domain.Customers.Exceptions;

public sealed record Contact
{
    private const int DEFAULT_REGEX_TIMEOUT = 100;
    private const string EMAIL_REGEX = @"^\S+@\S+\.\S+$";

    public string? Email { get; }
    public string? PhoneNumber { get; }

    public Contact(string? email, string? phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new ContactEmptyException();
        }

        if (string.IsNullOrWhiteSpace(email) is false)
        {
            var regex = new Regex(EMAIL_REGEX, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(DEFAULT_REGEX_TIMEOUT));

            if (regex.IsMatch(email) is false)
            {
                throw new ContactInvalidEmailFormatException(email);
            }
        }

        this.Email = email;
        this.PhoneNumber = phoneNumber;
    }
}
