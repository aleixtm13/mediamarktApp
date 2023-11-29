using MediatR;
using ErrorOr;

namespace Application.Products.Create;

public record CreateProductCommand(
    string Name,
    string Description,
    double Price,
    Guid ProductFamily
) : IRequest<ErrorOr<Unit>>;