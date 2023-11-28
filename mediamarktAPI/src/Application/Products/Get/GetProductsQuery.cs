using Application.Products.Common;
using ErrorOr;
using MediatR;

namespace Application.Products.Get
{
    public record GetProductsQuery(string? SearchText) : IRequest<ErrorOr<IReadOnlyList<ProductResponse>>>;
}
