using LBSNEE.Application.Abstractions;
using LBSNEE.Application.AddProduct;
using LBSNEE.Domain;
using LBSNEE.Infrastructure;
using MediatR;

namespace LBSNEE.Application.UpdateProduct;

public class UpdateProductCommandHandler(
    IProductRepository _productRepository,
    ApplicationDbContext _context,
    TimeProvider _timeProvider) : IRequestHandler<UpdateProductCommand, Unit>
{
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductCommandValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            throw new CustomValidationException(result.Errors);
        }

        var product = await _productRepository.Get(request.Id);

        if (product is null)
        {
            throw new Exception($"Product with id {request.Id} not found!");
        }

        product.Update(
            request.ProductDto.Name,
            request.ProductDto.Description,
            request.ProductDto.Price,
            request.ProductDto.Quantity,
            _timeProvider.GetUtcNow().DateTime);

        _productRepository.Update(product);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
