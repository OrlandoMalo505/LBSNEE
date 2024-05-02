using FluentValidation;

namespace LBSNEE.Application.AddProduct;

public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
{
    public AddProductCommandValidator()
    {
        RuleFor(x => x.AddProductDto.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.AddProductDto.Description).NotEmpty();
        RuleFor(x => x.AddProductDto.Quantity).NotNull().GreaterThan(0);
        RuleFor(x => x.AddProductDto.Price).NotNull()
            .GreaterThan(0)
            .PrecisionScale(10, 2, true);
    }
}
