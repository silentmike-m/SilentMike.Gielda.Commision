namespace SilentMike.Gielda.Commision.Infrastructure.Customers.QueryHandlers;

using MediatR;
using Microsoft.Extensions.Logging;
using SilentMike.Gielda.Commision.Application.Customers.Models;
using SilentMike.Gielda.Commision.Application.Customers.Queries;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Extensions;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Interfaces;

internal sealed class GetCustomerHandler : IRequestHandler<GetCustomer, CustomerDto?>
{
    private readonly ICustomerMapper customerMapper;
    private readonly ICustomerReadService customerReadService;
    private readonly ILogger<GetCustomerHandler> logger;

    public GetCustomerHandler(ICustomerMapper customerMapper, ICustomerReadService customerReadService, ILogger<GetCustomerHandler> logger)
    {
        this.customerMapper = customerMapper;
        this.customerReadService = customerReadService;
        this.logger = logger;
    }

    public async Task<CustomerDto?> Handle(GetCustomer request, CancellationToken cancellationToken)
    {
        this.logger.LogGettingCustomer(request.CustomerId);

        var customer = await this.customerReadService.GetCustomerAsync(request.CustomerId, cancellationToken);

        return customer is null
            ? null
            : this.customerMapper.ToDto(customer);
    }
}
