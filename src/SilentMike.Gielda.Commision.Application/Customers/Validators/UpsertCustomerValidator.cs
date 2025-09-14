namespace SilentMike.Gielda.Commision.Application.Customers.Validators;

using SilentMike.Gielda.Commision.Application.Customers.Commands;
using SilentMike.Gielda.Commision.Application.Customers.Constants;

internal sealed class UpsertCustomerValidator : AbstractValidator<UpsertCustomer>
{
    public UpsertCustomerValidator()
    {
        this.RuleFor(request => request.City)
            .NotEmpty()
            .WithErrorCode(ValidationErrorCodes.CUSTOMER_EMPTY_CITY)
            .WithMessage(ValidationErrorCodes.CUSTOMER_EMPTY_CITY_MESSAGE);

        this.RuleFor(request => request.DocumentNumber)
            .NotEmpty()
            .WithErrorCode(ValidationErrorCodes.CUSTOMER_EMPTY_DOCUMENT_NUMBER)
            .WithMessage(ValidationErrorCodes.CUSTOMER_EMPTY_DOCUMENT_NUMBER_MESSAGE);

        this.RuleFor(request => request.FirstName)
            .NotEmpty()
            .WithErrorCode(ValidationErrorCodes.CUSTOMER_EMPTY_FIRST_NAME)
            .WithMessage(ValidationErrorCodes.CUSTOMER_EMPTY_FIRST_NAME_MESSAGE);

        this.RuleFor(request => request.LastName)
            .NotEmpty()
            .WithErrorCode(ValidationErrorCodes.CUSTOMER_EMPTY_LAST_NAME)
            .WithMessage(ValidationErrorCodes.CUSTOMER_EMPTY_LAST_NAME_MESSAGE);

        this.RuleFor(request => request.Id)
            .NotEmpty()
            .WithErrorCode(ValidationErrorCodes.CUSTOMER_EMPTY_ID)
            .WithMessage(ValidationErrorCodes.CUSTOMER_EMPTY_ID_MESSAGE);

        this.RuleFor(request => request.Street)
            .NotEmpty()
            .WithErrorCode(ValidationErrorCodes.CUSTOMER_EMPTY_STREET)
            .WithMessage(ValidationErrorCodes.CUSTOMER_EMPTY_STREET_MESSAGE);

        this.RuleFor(request => request.ZipCode)
            .NotEmpty()
            .WithErrorCode(ValidationErrorCodes.CUSTOMER_EMPTY_ZIP_CODE)
            .WithMessage(ValidationErrorCodes.CUSTOMER_EMPTY_ZIP_CODE_MESSAGE);

        this.RuleFor(request => new
            {
                request.Email,
                request.PhoneNumber,
            })
            .Must(contact => IsNotEmpty(contact.Email, contact.PhoneNumber))
            .WithErrorCode(ValidationErrorCodes.CUSTOMER_EMPTY_CONTACT)
            .WithMessage(ValidationErrorCodes.CUSTOMER_EMPTY_CONTACT_MESSAGE);

        this.RuleFor(request => request.Email)
            .EmailAddress()
            .When(request => string.IsNullOrWhiteSpace(request.Email) is false)
            .WithErrorCode(ValidationErrorCodes.CUSTOMER_EMAIL_WRONG_FORMAT)
            .WithMessage(ValidationErrorCodes.CUSTOMER_EMAIL_WRONG_FORMAT_MESSAGE);
    }

    private static bool IsNotEmpty(string email, string phoneNumber)
        => string.IsNullOrWhiteSpace(email) is false
           || string.IsNullOrWhiteSpace(phoneNumber) is false;
}
