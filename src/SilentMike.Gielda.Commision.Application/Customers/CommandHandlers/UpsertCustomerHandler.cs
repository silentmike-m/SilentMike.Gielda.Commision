namespace SilentMike.Gielda.Commision.Application.Customers.CommandHandlers;

using Microsoft.Extensions.Logging;
using SilentMike.Gielda.Commision.Application.Customers.Commands;
using SilentMike.Gielda.Commision.Application.Customers.Extensions;
using SilentMike.Gielda.Commision.Domain.Customers.Entities;
using SilentMike.Gielda.Commision.Domain.Customers.Interfaces;
using SilentMike.Gielda.Commision.Domain.Customers.ValueObjects;

internal sealed class UpsertCustomerHandler : IRequestHandler<UpsertCustomer>
{
    private readonly ICustomerRepository customerRepository;
    private readonly ILogger<UpsertCustomerHandler> logger;

    public UpsertCustomerHandler(ICustomerRepository customerRepository, ILogger<UpsertCustomerHandler> logger)
    {
        this.customerRepository = customerRepository;
        this.logger = logger;
    }

    public async Task Handle(UpsertCustomer request, CancellationToken cancellationToken)
    {
        this.logger.LogUpsertingCustomer(request.Id);

        var customer = await this.customerRepository.GetCustomerAsync(request.Id, cancellationToken);

        if (customer is null)
        {
            await this.CreateCustomerAsync(request, cancellationToken);
        }
        else
        {
            await this.UpdateCustomerAsync(customer, request, cancellationToken);
        }
    }

    private async Task CreateCustomerAsync(UpsertCustomer request, CancellationToken cancellationToken)
    {
        var address = CreateAddress(request);

        var contact = CreateContact(request);

        var document = CreateDocument(request);

        var customer = new CustomerEntity(request.Id, address, contact, document, request.FirstName, request.LastName);

        await this.customerRepository.AddCustomerAsync(customer, cancellationToken);
    }

    private async Task UpdateCustomerAsync(CustomerEntity customer, UpsertCustomer request, CancellationToken cancellationToken)
    {
        customer.SetFirstName(request.FirstName);
        customer.SetLastName(request.LastName);

        customer.Address = CreateAddress(request);
        customer.Contact = CreateContact(request);
        customer.Document = CreateDocument(request);

        await this.customerRepository.UpdateCustomerAsync(customer, cancellationToken);
    }

    private static Address CreateAddress(UpsertCustomer request)
        => new(request.City, request.Street, request.ZipCode);

    private static Contact CreateContact(UpsertCustomer request)
        => new(request.Email, request.PhoneNumber);

    private static Document CreateDocument(UpsertCustomer request)
        => new(request.DocumentNumber, request.DocumentType);
}
