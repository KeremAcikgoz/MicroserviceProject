using FluentValidation;

namespace Customer.API.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(2);
        }
    }
}
