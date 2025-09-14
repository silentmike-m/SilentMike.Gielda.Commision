namespace SilentMike.Gielda.Commision.WebApi.Mappers.Services;

using Riok.Mapperly.Abstractions;
using SilentMike.Gielda.Commision.Application.Customers.Models;
using SilentMike.Gielda.Commision.WebApi.Mappers.Interfaces;
using SilentMike.Gielda.Commision.WebApi.Models.Customers.Responses;

[Mapper]
internal sealed partial class CustomerMapper : ICustomerMapper
{
    public partial Customer ToResponse(CustomerDto customer);
}
