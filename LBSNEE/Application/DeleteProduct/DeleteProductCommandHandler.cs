using LBSNEE.Domain;
using LBSNEE.Infrastructure;
using MediatR;
using Microsoft.Identity.Client;

namespace LBSNEE.Application.DeleteProduct;

public class DeleteProductCommandHandler(
    IProductRepository _productRepository,
    ApplicationDbContext _context) : IRequestHandler<DeleteProductCommand, Unit>
{
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.Get(request.Id);

        if (product is null)
        {
            throw new Exception($"Product with id {request.Id} not found!");
        }

        _productRepository.Delete(product);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
