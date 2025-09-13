namespace SilentMike.Gielda.Commision.Domain.UnitTests.Contracts.ValueObjects;

using SilentMike.Gielda.Commision.Domain.Contracts.Constants;
using SilentMike.Gielda.Commision.Domain.Contracts.Exceptions;
using SilentMike.Gielda.Commision.Domain.Contracts.ValueObjects;

[TestClass]
public sealed class ContractItemValueTests
{
    [TestMethod]
    public void Should_CreateContractItemValue()
    {
        // Arrange
        const decimal customerValue = 5.60m;
        const decimal price = 10.50m;

        // Act
        var contractItemValue = new ContractItemValue(customerValue, price);

        // Assert
        contractItemValue.CustomerValue.Should()
            .Be(customerValue);

        contractItemValue.Price.Should()
            .Be(price);
    }

    [TestMethod]
    public void Should_ThrowContractItemInvalidPriceException_When_PriceIsLessThanCustomerValue()
    {
        // Arrange
        const decimal customerValue = 25.60m;
        const decimal price = 10.50m;

        // Act
        var action = () => new ContractItemValue(customerValue, price);

        // Assert
        action.Should()
            .Throw<ContractItemInvalidPriceException>()
            .Where(exception => exception.Code == ErrorCodes.CONTRACT_ITEM_INVALID_PRICE);
    }
}
