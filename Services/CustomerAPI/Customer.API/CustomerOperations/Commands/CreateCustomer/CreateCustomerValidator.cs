using FluentValidation;

namespace Customer.API.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Address.City).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Address.Country).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Address.CityCode).NotEmpty().GreaterThan(0);
        }
    }
}
