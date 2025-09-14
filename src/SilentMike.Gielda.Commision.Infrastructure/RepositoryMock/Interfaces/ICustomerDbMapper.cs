namespace SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Interfaces;

using SilentMike.Gielda.Commision.Domain.Customers.Entities;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Models;
using SilentMike.Gielda.Commision.Infrastructure.RepositoryMock.Models;

internal interface ICustomerDbMapper
{
    CustomerDbEntity ToDbModel(CustomerEntity customer);
    CustomerReadModel ToReadModel(CustomerDbEntity customer);
}
