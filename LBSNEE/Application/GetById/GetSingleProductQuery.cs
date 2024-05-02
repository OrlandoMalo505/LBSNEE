using LBSNEE.Domain;
using MediatR;

namespace LBSNEE.Application.GetById;

public record GetSingleProductQuery(int Id) : IRequest<Product>;
