namespace SilentMike.Gielda.Commision.Application.UnitTests.Customers.Validators;

using SilentMike.Gielda.Commision.Application.Customers.Commands;
using SilentMike.Gielda.Commision.Application.Customers.Constants;
using SilentMike.Gielda.Commision.Application.Customers.Validators;
using SilentMike.Gielda.Commision.Domain.Customers.Enums;

[TestClass]
public sealed class UpsertCustomerValidatorTests
{
    private const string CITY = "New York";
    private const string DOCUMENT_NUMBER = "APX14553";
    private const DocumentType DOCUMENT_TYPE = DocumentType.IdentityCard;
    private const string EMAIL = "user@domain.com";
    private const string FIRST_NAME = "John";
    private const string LAST_NAME = "Doe";
    private const string PHONE_NUMBER = "691 875 2258";
    private const string STREET = "23 Main street";
    private const string ZIP_CODE = "78-113";
    private static readonly Guid ID = Guid.NewGuid();

    private readonly UpsertCustomerValidator validator = new();

    [TestMethod, DataRow(""), DataRow("   ")]
    public async Task Validation_Should_Fail_When_DocumentNumberIsEmpty(string documentNumber)
    {
        // Arrange
        var request = new UpsertCustomer
        {
            City = CITY,
            DocumentNumber = documentNumber,
            DocumentType = DOCUMENT_TYPE,
            Email = EMAIL,
            FirstName = FIRST_NAME,
            Id = ID,
            LastName = LAST_NAME,
            PhoneNumber = PHONE_NUMBER,
            Street = STREET,
            ZipCode = ZIP_CODE,
        };

        // Act
        var result = await this.validator.ValidateAsync(request, CancellationToken.None);

        // Assert
        result.IsValid.Should()
            .BeFalse();

        result.Errors.Should()
            .HaveCount(1)
            .And
            .Contain(error =>
                error.PropertyName == nameof(UpsertCustomer.DocumentNumber)
                && error.ErrorCode == ValidationErrorCodes.CUSTOMER_EMPTY_DOCUMENT_NUMBER
                && error.ErrorMessage == ValidationErrorCodes.CUSTOMER_EMPTY_DOCUMENT_NUMBER_MESSAGE);
    }

    [TestMethod, DataRow("", ""), DataRow("   ", "   ")]
    public async Task Validation_Should_Fail_When_EmailAndPhoneNumberAreEmpty(string email, string phoneNumber)
    {
        // Arrange
        var request = new UpsertCustomer
        {
            City = CITY,
            DocumentNumber = DOCUMENT_NUMBER,
            DocumentType = DOCUMENT_TYPE,
            Email = email,
            FirstName = FIRST_NAME,
            Id = ID,
            LastName = LAST_NAME,
            PhoneNumber = phoneNumber,
            Street = STREET,
            ZipCode = ZIP_CODE,
        };

        // Act
        var result = await this.validator.ValidateAsync(request, CancellationToken.None);

        // Assert
        result.IsValid.Should()
            .BeFalse();

        result.Errors.Should()
            .HaveCount(1)
            .And
            .Contain(error =>
                error.ErrorCode == ValidationErrorCodes.CUSTOMER_EMPTY_CONTACT
                && error.ErrorMessage == ValidationErrorCodes.CUSTOMER_EMPTY_CONTACT_MESSAGE);
    }

    [TestMethod, DataRow("user2domain.com"), DataRow("user-domain")]
    public async Task Validation_Should_Fail_When_EmailHasWrongFormat(string email)
    {
        // Arrange
        var request = new UpsertCustomer
        {
            City = CITY,
            DocumentNumber = DOCUMENT_NUMBER,
            DocumentType = DOCUMENT_TYPE,
            Email = email,
            FirstName = FIRST_NAME,
            Id = ID,
            LastName = LAST_NAME,
            PhoneNumber = PHONE_NUMBER,
            Street = STREET,
            ZipCode = ZIP_CODE,
        };

        // Act
        var result = await this.validator.ValidateAsync(request, CancellationToken.None);

        // Assert
        result.IsValid.Should()
            .BeFalse();

        result.Errors.Should()
            .HaveCount(1)
            .And
            .Contain(error =>
                error.PropertyName == nameof(UpsertCustomer.Email)
                && error.ErrorCode == ValidationErrorCodes.CUSTOMER_EMAIL_WRONG_FORMAT
                && error.ErrorMessage == ValidationErrorCodes.CUSTOMER_EMAIL_WRONG_FORMAT_MESSAGE);
    }

    [TestMethod, DataRow(""), DataRow("   ")]
    public async Task Validation_Should_Fail_When_FirstNameIsEmpty(string firstName)
    {
        // Arrange
        var request = new UpsertCustomer
        {
            City = CITY,
            DocumentNumber = DOCUMENT_NUMBER,
            DocumentType = DOCUMENT_TYPE,
            Email = EMAIL,
            FirstName = firstName,
            Id = ID,
            LastName = LAST_NAME,
            PhoneNumber = PHONE_NUMBER,
            Street = STREET,
            ZipCode = ZIP_CODE,
        };

        // Act
        var result = await this.validator.ValidateAsync(request, CancellationToken.None);

        // Assert
        result.IsValid.Should()
            .BeFalse();

        result.Errors.Should()
            .HaveCount(1)
            .And
            .Contain(error =>
                error.PropertyName == nameof(UpsertCustomer.FirstName)
                && error.ErrorCode == ValidationErrorCodes.CUSTOMER_EMPTY_FIRST_NAME
                && error.ErrorMessage == ValidationErrorCodes.CUSTOMER_EMPTY_FIRST_NAME_MESSAGE);
    }

    [TestMethod]
    public async Task Validation_Should_Fail_When_IdIsEmpty()
    {
        // Arrange
        var request = new UpsertCustomer
        {
            City = CITY,
            DocumentNumber = DOCUMENT_NUMBER,
            DocumentType = DOCUMENT_TYPE,
            Email = EMAIL,
            FirstName = FIRST_NAME,
            Id = Guid.Empty,
            LastName = LAST_NAME,
            PhoneNumber = PHONE_NUMBER,
            Street = STREET,
            ZipCode = ZIP_CODE,
        };

        // Act
        var result = await this.validator.ValidateAsync(request, CancellationToken.None);

        // Assert
        result.IsValid.Should()
            .BeFalse();

        result.Errors.Should()
            .HaveCount(1)
            .And
            .Contain(error =>
                error.PropertyName == nameof(UpsertCustomer.Id)
                && error.ErrorCode == ValidationErrorCodes.CUSTOMER_EMPTY_ID
                && error.ErrorMessage == ValidationErrorCodes.CUSTOMER_EMPTY_ID_MESSAGE);
    }

    [TestMethod, DataRow(""), DataRow("   ")]
    public async Task Validation_Should_Fail_When_LastNameIsEmpty(string lastName)
    {
        // Arrange
        var request = new UpsertCustomer
        {
            City = CITY,
            DocumentNumber = DOCUMENT_NUMBER,
            DocumentType = DOCUMENT_TYPE,
            Email = EMAIL,
            FirstName = FIRST_NAME,
            Id = ID,
            LastName = lastName,
            PhoneNumber = PHONE_NUMBER,
            Street = STREET,
            ZipCode = ZIP_CODE,
        };

        // Act
        var result = await this.validator.ValidateAsync(request, CancellationToken.None);

        // Assert
        result.IsValid.Should()
            .BeFalse();

        result.Errors.Should()
            .HaveCount(1)
            .And
            .Contain(error =>
                error.PropertyName == nameof(UpsertCustomer.LastName)
                && error.ErrorCode == ValidationErrorCodes.CUSTOMER_EMPTY_LAST_NAME
                && error.ErrorMessage == ValidationErrorCodes.CUSTOMER_EMPTY_LAST_NAME_MESSAGE);
    }

    [TestMethod, DataRow(""), DataRow("   ")]
    public async Task Validation_Should_Fail_When_StreetIsEmpty(string street)
    {
        // Arrange
        var request = new UpsertCustomer
        {
            City = CITY,
            DocumentNumber = DOCUMENT_NUMBER,
            DocumentType = DOCUMENT_TYPE,
            Email = EMAIL,
            FirstName = FIRST_NAME,
            Id = ID,
            LastName = LAST_NAME,
            PhoneNumber = PHONE_NUMBER,
            Street = street,
            ZipCode = ZIP_CODE,
        };

        // Act
        var result = await this.validator.ValidateAsync(request, CancellationToken.None);

        // Assert
        result.IsValid.Should()
            .BeFalse();

        result.Errors.Should()
            .HaveCount(1)
            .And
            .Contain(error =>
                error.PropertyName == nameof(UpsertCustomer.Street)
                && error.ErrorCode == ValidationErrorCodes.CUSTOMER_EMPTY_STREET
                && error.ErrorMessage == ValidationErrorCodes.CUSTOMER_EMPTY_STREET_MESSAGE);
    }

    [TestMethod, DataRow(""), DataRow("   ")]
    public async Task Validation_Should_Fail_When_ZipCodeIsEmpty(string zipCode)
    {
        // Arrange
        var request = new UpsertCustomer
        {
            City = CITY,
            DocumentNumber = DOCUMENT_NUMBER,
            DocumentType = DOCUMENT_TYPE,
            Email = EMAIL,
            FirstName = FIRST_NAME,
            Id = ID,
            LastName = LAST_NAME,
            PhoneNumber = PHONE_NUMBER,
            Street = STREET,
            ZipCode = zipCode,
        };

        // Act
        var result = await this.validator.ValidateAsync(request, CancellationToken.None);

        // Assert
        result.IsValid.Should()
            .BeFalse();

        result.Errors.Should()
            .HaveCount(1)
            .And
            .Contain(error =>
                error.PropertyName == nameof(UpsertCustomer.ZipCode)
                && error.ErrorCode == ValidationErrorCodes.CUSTOMER_EMPTY_ZIP_CODE
                && error.ErrorMessage == ValidationErrorCodes.CUSTOMER_EMPTY_ZIP_CODE_MESSAGE);
    }

    [TestMethod]
    public async Task Validation_Should_Pass()
    {
        // Arrange
        var request = new UpsertCustomer
        {
            City = CITY,
            DocumentNumber = DOCUMENT_NUMBER,
            DocumentType = DOCUMENT_TYPE,
            Email = EMAIL,
            FirstName = FIRST_NAME,
            Id = ID,
            LastName = LAST_NAME,
            PhoneNumber = PHONE_NUMBER,
            Street = STREET,
            ZipCode = ZIP_CODE,
        };

        // Act
        var result = await this.validator.ValidateAsync(request, CancellationToken.None);

        // Assert
        result.IsValid.Should()
            .BeTrue();
    }
}
