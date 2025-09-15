namespace SilentMike.Gielda.Commision.Domain.Types;

public readonly record struct ContractNumber
{
    public string Value { get; private init; }

    public ContractNumber(string value)
        => this.Value = value;

    public static implicit operator ContractNumber(string value)
        => new(value);
}
