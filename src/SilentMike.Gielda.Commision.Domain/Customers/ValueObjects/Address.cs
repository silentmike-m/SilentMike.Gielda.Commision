namespace SilentMike.Gielda.Commision.Domain.Customers.ValueObjects;

using SilentMike.Gielda.Commision.Domain.Customers.Exceptions;

public sealed record Address
{
    public string City { get; }
    public string Street { get; }
    public string ZipCode { get; }

    public Address(string city, string street, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            throw new AddressEmptyCityException();
        }

        if (string.IsNullOrWhiteSpace(street))
        {
            throw new AddressEmptyStreetException();
        }

        if (string.IsNullOrWhiteSpace(zipCode))
        {
            throw new AddressEmptyZipCodeException();
        }

        this.City = city;
        this.Street = street;
        this.ZipCode = zipCode;
    }
}
