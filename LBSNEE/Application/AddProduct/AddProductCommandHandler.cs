using LBSNEE.Application.Abstractions;
using LBSNEE.Domain;
using LBSNEE.Infrastructure;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LBSNEE.Application.AddProduct;

public class AddProductCommandHandler(
    IProductRepository _productRepository,
    ApplicationDbContext _context,
    TimeProvider _timeProvider) : IRequestHandler<AddProductCommand, int>
{
    public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new AddProductCommandValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            throw new CustomValidationException(result.Errors);
        }

        var product = Product.Create(
            request.AddProductDto.Name,
            request.AddProductDto.Description,
            request.AddProductDto.Price,
            request.AddProductDto.Quantity,
            _timeProvider.GetUtcNow().DateTime);

        _productRepository.Add(product);

        await _context.SaveChangesAsync(cancellationToken);

        return product.Id;

    }
}
