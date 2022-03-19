using FluentValidation;
using Order.API.OrderOperations.CreateOrder;

namespace Order.API.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            //RuleFor(command => command.Model.CustomerId).NotEmpty();
            RuleFor(command => command.Model.Quantity).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.Price).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.Address).NotEmpty();
            RuleFor(command => command.Model.ProductId).NotEmpty();
            RuleFor(command => command.Model.Status).NotEmpty();          
        }
    }
}
