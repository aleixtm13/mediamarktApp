using MediatR;
using ErrorOr;

namespace Application.Products.Create;

public record CreateProductCommand(
    string Name,
    string Descritpion,
    double Price,
    Guid ProductFamilyId
) : IRequest<ErrorOr<Unit>>;