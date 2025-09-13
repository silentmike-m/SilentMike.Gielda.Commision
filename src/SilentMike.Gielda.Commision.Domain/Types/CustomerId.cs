namespace SilentMike.Gielda.Commision.Domain.Types;

public readonly record struct CustomerId : IEntityId
{
    public Guid Value { get; private init; }

    public CustomerId(Guid value)
        => this.Value = value;

    public static implicit operator CustomerId(Guid value)
        => new(value);
}
