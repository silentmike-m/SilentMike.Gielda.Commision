namespace SilentMike.Gielda.Commision.Domain.UnitTests.Contracts.Entities;

using SilentMike.Gielda.Commision.Domain.Contracts.Constants;
using SilentMike.Gielda.Commision.Domain.Contracts.Entities;
using SilentMike.Gielda.Commision.Domain.Contracts.Exceptions;
using SilentMike.Gielda.Commision.Domain.Contracts.ValueObjects;

[TestClass]
public sealed class ContractEntityTests
{
    [TestMethod]
    public void AddItem_Should_AddItem()
    {
        // Arrange
        const decimal commission = 25.5m;
        const string contractNumber = "PX2025/01";

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        var contract = new ContractEntity(id, customerId, commission, contractNumber);

        var item = new ContractItemEntity(Guid.NewGuid(), "Item name", new ContractItemValue(customerValue: 5.5m, price: 10.5m));

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

        contract.Number.Value.Should()
            .Be(contractNumber);
    }

    [TestMethod]
    public void AddItem_Should_ThrowContractItemAlreadyExistsException_When_ItemAlreadyExists()
    {
        // Arrange
        const decimal commission = 25.5m;
        const string contractNumber = "PX2025/01";

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        var contract = new ContractEntity(id, customerId, commission, contractNumber);

        var item = new ContractItemEntity(Guid.NewGuid(), "Item name", new ContractItemValue(customerValue: 5.5m, price: 10.5m));

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

        contract.Number.Value.Should()
            .Be(contractNumber);
    }

    [TestMethod]
    public void RemoveItem_Should_NotThrowException_When_ItemNotExists()
    {
        // Arrange
        const decimal commission = 25.5m;
        const string contractNumber = "PX2025/01";

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        var contract = new ContractEntity(id, customerId, commission, contractNumber);

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

        contract.Number.Value.Should()
            .Be(contractNumber);
    }

    [TestMethod]
    public void RemoveItem_Should_RemoveItem()
    {
        // Arrange
        const decimal commission = 25.5m;
        const string contractNumber = "PX2025/01";

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        var contract = new ContractEntity(id, customerId, commission, contractNumber);

        var item = new ContractItemEntity(Guid.NewGuid(), "Item name", new ContractItemValue(customerValue: 5.5m, price: 10.5m));

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

        contract.Number.Value.Should()
            .Be(contractNumber);
    }

    [TestMethod]
    public void SetCommission_Should_ChangeCommision()
    {
        // Arrange
        const decimal commission = 25.5m;
        const string contractNumber = "PX2025/01";

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        var contract = new ContractEntity(id, customerId, commission: 2.3m, contractNumber);

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

        contract.Number.Value.Should()
            .Be(contractNumber);
    }

    [TestMethod]
    public void SetCommission_Should_ThrowContractInvalidCommisionValueException_When_CommissionIsLessThanZero()
    {
        // Arrange
        const decimal commission = 25.5m;
        const string contractNumber = "PX2025/01";

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        var contract = new ContractEntity(id, customerId, commission, contractNumber);

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
        const string contractNumber = "PX2025/01";

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        // Act
        var contract = new ContractEntity(id, customerId, commission, contractNumber);

        // Assert
        contract.Commission.Should()
            .Be(commission);

        contract.CustomerId.Value.Should()
            .Be(customerId);

        contract.Id.Value.Should()
            .Be(id);

        contract.Items.Should()
            .BeEmpty();

        contract.Number.Value.Should()
            .Be(contractNumber);
    }

    [TestMethod] [DataRow("")] [DataRow("   ")]
    public void Should_Throw(string contractNumber)
    {
        // Arrange
        const decimal commission = 25.5m;

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        // Act
        var action = () => new ContractEntity(id, customerId, commission, contractNumber);

        // Assert
        action.Should()
            .Throw<ContractEmptyNumberException>()
            .Where(exception => exception.Code == ErrorCodes.CONTRACT_EMPTY_NUMBER);
    }

    [TestMethod]
    public void Should_ThrowContractInvalidCommisionValueException_When_CommissionIsLessThanZero()
    {
        // Arrange
        const decimal commission = -25.5m;
        const string contractNumber = "PX2025/01";

        var customerId = Guid.NewGuid();
        var id = Guid.NewGuid();

        // Act
        var action = () => new ContractEntity(id, customerId, commission, contractNumber);

        // Assert
        action.Should()
            .Throw<ContractInvalidCommisionValueException>()
            .Where(exception => exception.Code == ErrorCodes.CONTRACT_INVALID_COMMISION_VALUE);
    }
}
