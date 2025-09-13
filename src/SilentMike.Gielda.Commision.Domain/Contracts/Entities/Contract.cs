namespace SilentMike.Gielda.Commision.Domain.Contracts.Entities;

using SilentMike.Gielda.Commision.Domain.Common.Interfaces;
using SilentMike.Gielda.Commision.Domain.Contracts.Exceptions;
using SilentMike.Gielda.Commision.Domain.Types;

public sealed class Contract : IEntity<ContractId>
{
    private readonly List<ContractItem> items = [];

    public decimal Commission { get; private set; }
    public CustomerId CustomerId { get; }
    public ContractId Id { get; }
    public IReadOnlyList<ContractItem> Items => this.items.AsReadOnly();

    public Contract(ContractId id, CustomerId customerId, decimal commission)
    {
        this.Id = id;
        this.CustomerId = customerId;

        this.SetCommission(commission);
    }

    public void AddItem(ContractItem itemToAdd)
    {
        if (this.items.Any(item => item.Id == itemToAdd.Id))
        {
            throw new ContractItemAlreadyExistsException(itemToAdd.Id);
        }

        this.items.Add(itemToAdd);
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
