namespace SilentMike.Gielda.Commision.Infrastructure.Customers.Services;

using Riok.Mapperly.Abstractions;
using SilentMike.Gielda.Commision.Application.Customers.Models;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Interfaces;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Models;

[Mapper]
internal sealed partial class CustomerMapper : ICustomerMapper
{
    public partial CustomerDto ToDto(CustomerReadModel customer);
}
