namespace SilentMike.Gielda.Commision.Domain.Contracts.Entities;

using SilentMike.Gielda.Commision.Domain.Common.Interfaces;
using SilentMike.Gielda.Commision.Domain.Contracts.Exceptions;
using SilentMike.Gielda.Commision.Domain.Types;

public sealed class ContractEntity : IEntity<ContractId>
{
    private readonly List<ContractItemEntity> items = [];

    public decimal Commission { get; private set; }
    public CustomerId CustomerId { get; }
    public ContractId Id { get; }
    public IReadOnlyList<ContractItemEntity> Items => this.items.AsReadOnly();
    public ContractNumber Number { get; }

    public ContractEntity(ContractId id, CustomerId customerId, decimal commission, ContractNumber number)
    {
        this.Id = id;
        this.CustomerId = customerId;

        this.SetCommission(commission);

        if (string.IsNullOrWhiteSpace(number.Value))
        {
            throw new ContractEmptyNumberException();
        }

        this.Number = number;
    }

    public void AddItem(ContractItemEntity itemEntityToAdd)
    {
        if (this.items.Any(item => item.Id == itemEntityToAdd.Id))
        {
            throw new ContractItemAlreadyExistsException(itemEntityToAdd.Id);
        }

        this.items.Add(itemEntityToAdd);
    }

    public void RemoveItem(ContractItemId itemId)
    {
        var itemToRemove = this.items.FirstOrDefault(item => item.Id == itemId);

        if (itemToRemove is not null)
        {
            this.items.Remove(itemToRemove);
        }
    }

    public void SetCommission(decimal commission)
    {
        if (commission < 0)
        {
            throw new ContractInvalidCommisionValueException();
        }

        this.Commission = commission;
    }
}
