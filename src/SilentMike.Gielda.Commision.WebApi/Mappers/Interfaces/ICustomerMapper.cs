namespace SilentMike.Gielda.Commision.WebApi.Mappers.Interfaces;

using SilentMike.Gielda.Commision.Application.Customers.Models;
using SilentMike.Gielda.Commision.WebApi.Models.Customers.Responses;

internal interface ICustomerMapper
{
    Customer ToResponse(CustomerDto customer);
}
