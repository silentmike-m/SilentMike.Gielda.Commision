namespace SilentMike.Gielda.Commision.Application.UnitTests.Customers.Validators;

using SilentMike.Gielda.Commision.Application.Customers.Constants;
using SilentMike.Gielda.Commision.Application.Customers.Queries;
using SilentMike.Gielda.Commision.Application.Customers.Validators;

[TestClass]
public sealed class GetCustomerValidatorTests
{
    private readonly GetCustomerValidator validator = new();

    [TestMethod]
    public async Task Validation_Should_Fail_When_CustomerIdIsEmpty()
    {
        // Arrange
        var request = new GetCustomer
        {
            CustomerId = Guid.Empty,
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
                error.PropertyName == nameof(GetCustomer.CustomerId)
                && error.ErrorCode == ValidationErrorCodes.CUSTOMER_EMPTY_ID
                && error.ErrorMessage == ValidationErrorCodes.CUSTOMER_EMPTY_ID_MESSAGE);
    }

    [TestMethod]
    public async Task Validation_Should_Pass()
    {
        // Arrange
        var request = new GetCustomer
        {
            CustomerId = Guid.NewGuid(),
        };

        // Act
        var result = await this.validator.ValidateAsync(request, CancellationToken.None);

        // Assert
        result.IsValid.Should()
            .BeTrue();
    }
}
