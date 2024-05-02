using LBSNEE.Application.AddProduct;
using MediatR;

namespace LBSNEE.Application.UpdateProduct;

public record UpdateProductCommand(ProductDto ProductDto, int Id) : IRequest<Unit>;
