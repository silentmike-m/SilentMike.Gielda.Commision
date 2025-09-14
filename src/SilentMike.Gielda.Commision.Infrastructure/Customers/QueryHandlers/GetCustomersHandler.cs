namespace SilentMike.Gielda.Commision.Infrastructure.Customers.QueryHandlers;

using MediatR;
using Microsoft.Extensions.Logging;
using SilentMike.Gielda.Commision.Application.Customers.Models;
using SilentMike.Gielda.Commision.Application.Customers.Queries;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Extensions;
using SilentMike.Gielda.Commision.Infrastructure.Customers.Interfaces;

internal sealed class GetCustomersHandler : IRequestHandler<GetCustomers, IReadOnlyList<CustomerDto>>
{
    private readonly ICustomerMapper customerMapper;
    private readonly ICustomerReadService customerReadService;
    private readonly ILogger<GetCustomerHandler> logger;

    public GetCustomersHandler(ICustomerMapper customerMapper, ICustomerReadService customerReadService, ILogger<GetCustomerHandler> logger)
    {
        this.customerMapper = customerMapper;
        this.customerReadService = customerReadService;
        this.logger = logger;
    }

    public async Task<IReadOnlyList<CustomerDto>> Handle(GetCustomers request, CancellationToken cancellationToken)
    {
        this.logger.LogGettingCustomers();

        var customers = await this.customerReadService.GetCustomersAsync(cancellationToken);

        return customers
            .Select(customer => this.customerMapper.ToDto(customer))
            .ToList();
    }
}
