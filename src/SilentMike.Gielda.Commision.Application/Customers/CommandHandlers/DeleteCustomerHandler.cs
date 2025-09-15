namespace SilentMike.Gielda.Commision.Application.Customers.CommandHandlers;

using Microsoft.Extensions.Logging;
using SilentMike.Gielda.Commision.Application.Customers.Commands;
using SilentMike.Gielda.Commision.Application.Customers.Extensions;
using SilentMike.Gielda.Commision.Domain.Customers.Interfaces;

internal sealed class DeleteCustomerHandler : IRequestHandler<DeleteCustomer>
{
    private readonly ICustomerRepository customerRepository;
    private readonly ILogger<DeleteCustomerHandler> logger;

    public DeleteCustomerHandler(ICustomerRepository customerRepository, ILogger<DeleteCustomerHandler> logger)
    {
        this.customerRepository = customerRepository;
        this.logger = logger;
    }

    public async Task Handle(DeleteCustomer request, CancellationToken cancellationToken)
    {
        this.logger.LogDeletingCustomer(request.CustomerId);

        var customer = await this.customerRepository.GetAsync(request.CustomerId, cancellationToken);

        if (customer is not null)
        {
            await this.customerRepository.DeleteAsync(customer, cancellationToken);
        }
    }
}
