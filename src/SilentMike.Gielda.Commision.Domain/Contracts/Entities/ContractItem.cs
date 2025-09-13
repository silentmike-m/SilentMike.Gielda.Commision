namespace SilentMike.Gielda.Commision.Domain.Contracts.Entities;

using SilentMike.Gielda.Commision.Domain.Common.Interfaces;
using SilentMike.Gielda.Commision.Domain.Contracts.Exceptions;
using SilentMike.Gielda.Commision.Domain.Contracts.ValueObjects;
using SilentMike.Gielda.Commision.Domain.Types;

public sealed class ContractItem : IEntity<ContractItemId>
{
    public ContractItemId Id { get; }
    public string Name { get; private set; } = null!;
    public ContractItemValue Value { get; private set; }

    public ContractItem(ContractItemId id, string name, ContractItemValue value)
    {
        this.Id = id;
        this.Value = value;

        this.SetName(name);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ContractItemEmptyNameException();
        }

        this.Name = name;
    }
}
