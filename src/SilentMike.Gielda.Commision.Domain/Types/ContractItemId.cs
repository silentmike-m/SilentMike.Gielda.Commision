namespace SilentMike.Gielda.Commision.Domain.Types;

public readonly record struct ContractItemId : IEntityId
{
    public Guid Value { get; private init; }

    public ContractItemId(Guid value)
        => this.Value = value;

    public static implicit operator ContractItemId(Guid value)
        => new(value);
}
