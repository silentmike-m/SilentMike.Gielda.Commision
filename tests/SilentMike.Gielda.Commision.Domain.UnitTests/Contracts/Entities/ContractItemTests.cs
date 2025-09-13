namespace SilentMike.Gielda.Commision.Domain.UnitTests.Contracts.Entities;

using SilentMike.Gielda.Commision.Domain.Contracts.Constants;
using SilentMike.Gielda.Commision.Domain.Contracts.Entities;
using SilentMike.Gielda.Commision.Domain.Contracts.Exceptions;
using SilentMike.Gielda.Commision.Domain.Contracts.ValueObjects;

[TestClass]
public sealed class ContractItemTests
{
    [TestMethod]
    public void SetName_Should_ChangeName()
    {
        // Arrange
        const string name = "Item name";

        var id = Guid.NewGuid();
        var value = new ContractItemValue(customerValue: 5.67m, price: 10.45m);

        var contractItem = new ContractItem(id, "old name", value);

        // Act
        contractItem.SetName(name);

        // Assert
        contractItem.Id.Value.Should()
            .Be(id);

        contractItem.Name.Should()
            .Be(name);

        contractItem.Value.Should()
            .Be(value);
    }

    [TestMethod, DataRow(""), DataRow(" ")]
    public void SetName_Should_ContractItemEmptyNameException_When_NameIsEmpty(string name)
    {
        // Arrange
        var id = Guid.NewGuid();
        var value = new ContractItemValue(customerValue: 5.67m, price: 10.45m);

        var contractItem = new ContractItem(id, "old name", value);

        // Act
        var action = () => contractItem.SetName(name);

        // Assert
        action.Should()
            .Throw<ContractItemEmptyNameException>()
            .Where(exception => exception.Code == ErrorCodes.CONTRACT_ITEM_EMPTY_NAME);
    }

    [TestMethod, DataRow(""), DataRow("  ")]
    public void Should_ContractItemEmptyNameException_When_NameIsEmpty(string name)
    {
        // Arrange

        var id = Guid.NewGuid();
        var value = new ContractItemValue(customerValue: 5.67m, price: 10.45m);

        // Act
        var action = () => new ContractItem(id, name, value);

        // Assert
        action.Should()
            .Throw<ContractItemEmptyNameException>()
            .Where(exception => exception.Code == ErrorCodes.CONTRACT_ITEM_EMPTY_NAME);
    }

    [TestMethod]
    public void Should_CreateContractItem()
    {
        // Arrange
        const string name = "Item name";

        var id = Guid.NewGuid();
        var value = new ContractItemValue(customerValue: 5.67m, price: 10.45m);

        // Act
        var contractItem = new ContractItem(id, name, value);

        // Assert
        contractItem.Id.Value.Should()
            .Be(id);

        contractItem.Name.Should()
            .Be(name);

        contractItem.Value.Should()
            .Be(value);
    }
}
