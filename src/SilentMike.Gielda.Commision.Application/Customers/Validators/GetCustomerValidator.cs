namespace SilentMike.Gielda.Commision.Application.Customers.Validators;

using SilentMike.Gielda.Commision.Application.Customers.Constants;
using SilentMike.Gielda.Commision.Application.Customers.Queries;

internal sealed class GetCustomerValidator : AbstractValidator<GetCustomer>
{
    public GetCustomerValidator()
    {
        this.RuleFor(x => x.CustomerId)
            .NotEmpty()
            .WithErrorCode(ValidationErrorCodes.CUSTOMER_EMPTY_ID)
            .WithMessage(ValidationErrorCodes.CUSTOMER_EMPTY_ID_MESSAGE);
    }
}
