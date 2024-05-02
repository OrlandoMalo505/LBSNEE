using LBSNEE.Application.Abstractions;
using LBSNEE.Controllers;
using LBSNEE.Domain;
using MediatR;

namespace LBSNEE.Application.GetWithPagination;

public record GetProductsWithPaginationQuery(Filter Filter) : IRequest<PaginatedList<Product>>;
