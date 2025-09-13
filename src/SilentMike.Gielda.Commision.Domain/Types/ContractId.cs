namespace SilentMike.Gielda.Commision.Domain.Types;

public readonly record struct ContractId : IEntityId
{
    public Guid Value { get; private init; }

    public ContractId(Guid value)
        => this.Value = value;

    public static implicit operator ContractId(Guid value)
        => new(value);
}
