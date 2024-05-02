using LBSNEE.Application.Abstractions;
using LBSNEE.Application.AddProduct;
using LBSNEE.Application.DeleteProduct;
using LBSNEE.Application.GetById;
using LBSNEE.Application.GetWithPagination;
using LBSNEE.Application.UpdateProduct;
using LBSNEE.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LBSNEE.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] Filter filter)
    {
        var query = new GetProductsWithPaginationQuery(filter);

        var result = await sender.Send(query);

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetSingleProductQuery(id);

        var result = await sender.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDto productDto)
    {
        var command = new AddProductCommand(productDto);

        var result = await sender.Send(command);

        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductDto productDto)
    {
        var command = new UpdateProductCommand(productDto, id);

        var result = await sender.Send(command);

        return NoContent();
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProductCommand(id);

        var result = await sender.Send(command);

        return NoContent();
    }
}
