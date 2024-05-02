using MediatR;

namespace LBSNEE.Application.AddProduct;

public record AddProductCommand(ProductDto AddProductDto) : IRequest<int>;
