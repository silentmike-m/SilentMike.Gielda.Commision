namespace SilentMike.Gielda.Commision.Domain.Contracts.ValueObjects;

using SilentMike.Gielda.Commision.Domain.Contracts.Exceptions;

public sealed record ContractItemValue
{
    public decimal CustomerValue { get; }
    public decimal Price { get; }

    public ContractItemValue(decimal customerValue, decimal price)
    {
        if (customerValue > price)
        {
            throw new ContractItemInvalidPriceException();
        }

        this.CustomerValue = customerValue;
        this.Price = price;
    }
}
