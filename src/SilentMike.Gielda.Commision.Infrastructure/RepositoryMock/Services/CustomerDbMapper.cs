namespace SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Services;

using Riok.Mapperly.Abstractions;
using SilentMike.Gielda.Commision.Domain.Customers.Entities;
using SilentMike.Gielda.Commision.Domain.Types;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Models;
using SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Interfaces;
using SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Models;

[Mapper]
internal sealed partial class CustomerDbMapper : ICustomerDbMapper
{
    [MapProperty(nameof(CustomerEntity.Address.City), nameof(CustomerDbEntity.City))]
    [MapProperty(nameof(CustomerEntity.Address.Street), nameof(CustomerDbEntity.Street))]
    [MapProperty(nameof(CustomerEntity.Address.ZipCode), nameof(CustomerDbEntity.ZipCode))]
    [MapProperty(nameof(CustomerEntity.Contact.Email), nameof(CustomerDbEntity.Email))]
    [MapProperty(nameof(CustomerEntity.Contact.PhoneNumber), nameof(CustomerDbEntity.PhoneNumber))]
    [MapProperty(nameof(CustomerEntity.Document.DocumentNumber), nameof(CustomerDbEntity.DocumentNumber))]
    [MapProperty(nameof(CustomerEntity.Document.DocumentType), nameof(CustomerDbEntity.DocumentType))]
    public partial CustomerDbEntity ToDbModel(CustomerEntity coordinates);

    public partial CustomerReadModel ToReadModel(CustomerDbEntity coordinates);

    private Guid CustomerIdToGuid(CustomerId id) => id.Value;
}
