using Application.Products.Create;
using Application.Products.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("products")]
public class ProductsController : APIController 
{
    private readonly ISender _mediator;

    public ProductsController(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var createdProductResult = await _mediator.Send(command);
        return createdProductResult.Match(
            product => Ok(),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<IActionResult> Get(string? searchText)
    {
        var productsResult = await _mediator.Send(new GetProductsQuery(searchText));
        return productsResult.Match(
            products => Ok(products), 
            errors => Problem(errors)
            );
    }
}