namespace SilentMike.Gielda.Commision.Application.Customers.Validators;

using SilentMike.Gielda.Commision.Application.Customers.Commands;
using SilentMike.Gielda.Commision.Application.Customers.Constants;
using SilentMike.Gielda.Commision.Application.Customers.Interfaces;

internal sealed class DeleteCustomerValidator : AbstractValidator<DeleteCustomer>
{
    private readonly ICustomerValidationService validationService;

    public DeleteCustomerValidator(ICustomerValidationService validationService)
    {
        this.validationService = validationService;

        this.RuleFor(request => request.CustomerId)
            .NotEmpty()
            .WithErrorCode(ValidationErrorCodes.CUSTOMER_EMPTY_ID)
            .WithMessage(ValidationErrorCodes.CUSTOMER_EMPTY_ID_MESSAGE);

        this.RuleFor(request => request.CustomerId)
            .MustAsync(this.ContractNotExistsAsync)
            .WithErrorCode(ValidationErrorCodes.DELETE_CUSTOMER_WITH_EXISTSING_CONTRACT)
            .WithMessage(ValidationErrorCodes.DELETE_CUSTOMER_WITH_EXISTSING_CONTRACT_MESSAGE);
    }

    private async Task<bool> ContractNotExistsAsync(Guid customerId, CancellationToken cancellationToken)
        => await this.validationService.ContractExistsAsync(customerId, cancellationToken) is false;
}
