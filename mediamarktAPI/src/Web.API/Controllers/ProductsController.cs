using Application.Products.Create;
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
    
}