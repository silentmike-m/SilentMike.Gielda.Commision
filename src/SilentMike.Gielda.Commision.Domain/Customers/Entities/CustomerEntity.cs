namespace SilentMike.Gielda.Commision.Domain.Customers.Entities;

using SilentMike.Gielda.Commision.Domain.Common.Interfaces;
using SilentMike.Gielda.Commision.Domain.Customers.Exceptions;
using SilentMike.Gielda.Commision.Domain.Customers.ValueObjects;
using SilentMike.Gielda.Commision.Domain.Types;

public sealed class CustomerEntity : IEntity<CustomerId>
{
    public Address Address { get; private set; }

    public Contact Contact { get; private set; }
    public Document Document { get; private set; }
    public string FirstName { get; private set; } = null!;
    public CustomerId Id { get; }
    public string LastName { get; private set; } = null!;

    public CustomerEntity(CustomerId id, Address address, Contact contact, Document document, string firstName, string lastName)
    {
        this.Id = id;
        this.Address = address;
        this.Contact = contact;
        this.Document = document;

        this.SetFirstName(firstName);
        this.SetLastName(lastName);
    }

    public void SetFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new CustomerFirstNameException();
        }

        this.FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new CustomerLastNameException();
        }

        this.LastName = lastName;
    }
}
