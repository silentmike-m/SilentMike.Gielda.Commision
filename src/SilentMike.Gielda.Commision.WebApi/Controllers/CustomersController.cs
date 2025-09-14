namespace SilentMike.Gielda.Commision.WebApi.Controllers;

using MediatR;
using SilentMike.Gielda.Commision.Application.Customers.Commands;
using SilentMike.Gielda.Commision.Application.Customers.Queries;
using SilentMike.Gielda.Commision.WebApi.Mappers.Interfaces;
using SilentMike.Gielda.Commision.WebApi.Models.Customers.Requests;

internal static class CustomersController
{
    public static IEndpointRouteBuilder MapCustomers(this IEndpointRouteBuilder app)
        => app
            .MapGetCustomers();

    private static IEndpointRouteBuilder MapGetCustomers(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/customers/{customerId:guid}", async (Guid customerId, ISender mediator) =>
            {
                await mediator.Send(new DeleteCustomer
                {
                    CustomerId = customerId,
                });
            })
            .WithName("DeleteCustomer")
            .WithOpenApi();

        app.MapGet("/customers", async (ICustomerMapper customerMapper, ISender mediator) =>
            {
                var customers = await mediator.Send(new GetCustomers());

                return customers.Select(customerMapper.ToResponse);
            })
            .WithName("GetCustomers")
            .WithOpenApi();

        app.MapGet("/customers/{customerId:guid}", async (Guid customerId, ICustomerMapper customerMapper, ISender mediator) =>
            {
                var customer = await mediator.Send(new GetCustomer
                {
                    CustomerId = customerId,
                });

                return customer is not null
                    ? Results.Ok(customerMapper.ToResponse(customer))
                    : Results.NotFound();
            })
            .WithName("GetCustomer")
            .WithOpenApi();

        app.MapPost("/customers", async (AddCustomer addRequest, ISender mediator) =>
            {
                var request = new UpsertCustomer
                {
                    City = addRequest.City,
                    DocumentNumber = addRequest.DocumentNumber,
                    DocumentType = addRequest.DocumentType,
                    Email = addRequest.Email,
                    FirstName = addRequest.FirstName,
                    Id = addRequest.Id,
                    LastName = addRequest.LastName,
                    PhoneNumber = addRequest.PhoneNumber,
                    Street = addRequest.Street,
                    ZipCode = addRequest.ZipCode,
                };

                await mediator.Send(request);
            })
            .WithName("AddCustomer")
            .WithOpenApi();

        app.MapPut("/customers/{customerId:guid}", async (Guid customerId, UpdateCustomer updateRequest, ISender mediator) =>
            {
                var request = new UpsertCustomer
                {
                    City = updateRequest.City,
                    DocumentNumber = updateRequest.DocumentNumber,
                    DocumentType = updateRequest.DocumentType,
                    Email = updateRequest.Email,
                    FirstName = updateRequest.FirstName,
                    Id = customerId,
                    LastName = updateRequest.LastName,
                    PhoneNumber = updateRequest.PhoneNumber,
                    Street = updateRequest.Street,
                    ZipCode = updateRequest.ZipCode,
                };

                await mediator.Send(request);
            })
            .WithName("UpdateCustomer")
            .WithOpenApi();

        return app;
    }
}
