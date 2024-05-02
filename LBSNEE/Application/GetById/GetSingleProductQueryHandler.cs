using LBSNEE.Domain;
using LBSNEE.Infrastructure;
using MediatR;

namespace LBSNEE.Application.GetById;

public class GetSingleProductQueryHandler(
    IProductRepository _productRepository) : IRequestHandler<GetSingleProductQuery, Product>
{
    public async Task<Product> Handle(GetSingleProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.Get(request.Id);

        if (product is null)
        {
            throw new Exception($"Product with id {request.Id} not found!");
        }

        return product;
    }
}
