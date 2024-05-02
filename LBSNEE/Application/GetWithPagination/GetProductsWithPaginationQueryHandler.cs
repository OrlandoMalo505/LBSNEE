using LBSNEE.Application.Abstractions;
using LBSNEE.Domain;
using LBSNEE.Infrastructure;
using MediatR;

namespace LBSNEE.Application.GetWithPagination;

public class GetProductsWithPaginationQueryHandler(
    ApplicationDbContext _context) : IRequestHandler<GetProductsWithPaginationQuery, PaginatedList<Product>>
{
    public async Task<PaginatedList<Product>> Handle(
        GetProductsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Products
            .PaginatedListAsync((int)request.Filter.PageNumber, (int)request.Filter.PageSize);
    }
}
