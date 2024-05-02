using MediatR;

namespace LBSNEE.Application.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest<Unit>;