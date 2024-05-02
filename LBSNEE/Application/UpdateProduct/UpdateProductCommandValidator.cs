using FluentValidation;

namespace LBSNEE.Application.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.ProductDto.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.ProductDto.Description).NotEmpty();
        RuleFor(x => x.ProductDto.Quantity).NotNull().GreaterThan(0);
        RuleFor(x => x.ProductDto.Price).NotNull()
            .GreaterThan(0)
            .PrecisionScale(10, 2, true);
    }
}
