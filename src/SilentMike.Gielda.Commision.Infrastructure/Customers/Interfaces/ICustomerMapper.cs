namespace SilentMike.Gielda.Commision.Infrastructure.Customers.Interfaces;

using SilentMike.Gielda.Commision.Application.Customers.Models;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Models;

internal interface ICustomerMapper
{
    CustomerDto ToDto(CustomerReadModel customer);
}
