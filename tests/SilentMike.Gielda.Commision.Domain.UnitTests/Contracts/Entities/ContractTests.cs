namespace SilentMike.Gielda.Commision.Domain.UnitTests.Contracts.Entities;

using SilentMike.Gielda.Commision.Domain.Contracts.Constants;
using SilentMike.Gielda.Commision.Domain.Contracts.Entities;
using SilentMike.Gielda.Commision.Domain.Contracts.Exceptions;
using SilentMike.Gielda.Commision.Domain.Contracts.ValueObjects;
using Contract = SilentMike.Gielda.Commision.Domain.Contracts.Entities.Contract;

[TestClass]
public sealed class ContractTests
{
    [TestMethod]
    public void AddItem_Should_AddItem()
    {
        // Arrange
        const decimal commission = 25.5m;

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        var contract = new Contract(id, customerId, commission);

        var item = new ContractItem(Guid.NewGuid(), "Item name", new ContractItemValue(customerValue: 5.5m, price: 10.5m));

        // Act
        contract.AddItem(item);

        // Assert
        contract.Commission.Should()
            .Be(commission);

        contract.CustomerId.Value.Should()
            .Be(customerId);

        contract.Id.Value.Should()
            .Be(id);

        contract.Items.Should()
            .HaveCount(1)
            .And
            .Contain(item);
    }

    [TestMethod]
    public void AddItem_Should_ThrowContractItemAlreadyExistsException_When_ItemAlreadyExists()
    {
        // Arrange
        const decimal commission = 25.5m;

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        var contract = new Contract(id, customerId, commission);

        var item = new ContractItem(Guid.NewGuid(), "Item name", new ContractItemValue(customerValue: 5.5m, price: 10.5m));

        contract.AddItem(item);

        // Act
        var action = () => contract.AddItem(item);

        // Assert
        action.Should()
            .Throw<ContractItemAlreadyExistsException>()
            .Where(exception => exception.Code == ErrorCodes.CONTRACT_ITEM_ALREADY_EXISTS);

        contract.Commission.Should()
            .Be(commission);

        contract.CustomerId.Value.Should()
            .Be(customerId);

        contract.Id.Value.Should()
            .Be(id);

        contract.Items.Should()
            .HaveCount(1)
            .And
            .Contain(item);
    }

    [TestMethod]
    public void RemoveItem_Should_NotThrowException_When_ItemNotExists()
    {
        // Arrange
        const decimal commission = 25.5m;

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        var contract = new Contract(id, customerId, commission);

        // Act
        var action = () => contract.RemoveItem(id);

        // Assert
        action.Should()
            .NotThrow();

        contract.Commission.Should()
            .Be(commission);

        contract.CustomerId.Value.Should()
            .Be(customerId);

        contract.Id.Value.Should()
            .Be(id);

        contract.Items.Should()
            .BeEmpty();
    }

    [TestMethod]
    public void RemoveItem_Should_RemoveItem()
    {
        // Arrange
        const decimal commission = 25.5m;

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        var contract = new Contract(id, customerId, commission);

        var item = new ContractItem(Guid.NewGuid(), "Item name", new ContractItemValue(customerValue: 5.5m, price: 10.5m));

        contract.AddItem(item);

        // Act
        contract.RemoveItem(item.Id);

        // Assert
        contract.Commission.Should()
            .Be(commission);

        contract.CustomerId.Value.Should()
            .Be(customerId);

        contract.Id.Value.Should()
            .Be(id);

        contract.Items.Should()
            .BeEmpty();
    }

    [TestMethod]
    public void SetCommission_Should_ChangeCommision()
    {
        // Arrange
        const decimal commission = 25.5m;

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        var contract = new Contract(id, customerId, commission: 2.3m);

        // Act
        contract.SetCommission(commission);

        // Assert
        contract.Commission.Should()
            .Be(commission);

        contract.CustomerId.Value.Should()
            .Be(customerId);

        contract.Id.Value.Should()
            .Be(id);

        contract.Items.Should()
            .BeEmpty();
    }

    [TestMethod]
    public void SetCommission_Should_ThrowContractInvalidCommisionValueException_When_CommissionIsLessThanZero()
    {
        // Arrange
        const decimal commission = 25.5m;

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        var contract = new Contract(id, customerId, commission);

        // Act
        var action = () => contract.SetCommission(-23.5m);

        // Assert
        action.Should()
            .Throw<ContractInvalidCommisionValueException>()
            .Where(exception => exception.Code == ErrorCodes.CONTRACT_INVALID_COMMISION_VALUE);
    }

    [TestMethod]
    public void Should_CreateContract()
    {
        // Arrange
        const decimal commission = 25.5m;

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        // Act
        var contract = new Contract(id, customerId, commission);

        // Assert
        contract.Commission.Should()
            .Be(commission);

        contract.CustomerId.Value.Should()
            .Be(customerId);

        contract.Id.Value.Should()
            .Be(id);

        contract.Items.Should()
            .BeEmpty();
    }

    [TestMethod]
    public void Should_ThrowContractInvalidCommisionValueException_When_CommissionIsLessThanZero()
    {
        // Arrange
        const decimal commission = -25.5m;

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        // Act
        var action = () => new Contract(id, customerId, commission);

        // Assert
        action.Should()
            .Throw<ContractInvalidCommisionValueException>()
            .Where(exception => exception.Code == ErrorCodes.CONTRACT_INVALID_COMMISION_VALUE);
    }
}
