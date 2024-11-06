using Blog.CQRS.Application.Product.Commands.CreateProduct;
using Blog.CQRS.Application.Product.Commands.DeleteProduct;
using Blog.CQRS.Application.Product.Commands.UpdateProduct;
using Blog.CQRS.Application.Product.Queries.GetProductById;
using Blog.CQRS.Application.Product.Queries.GetProducts;
using Microsoft.AspNetCore.Mvc;

namespace Blog.CQRS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductCQRSController : ApiBaseController
{
    //[HttpGet]
    //public async Task<IActionResult> GetAll()
    //{
    //    var productList = await Mediator.Send(new GetProductsQuery());
    //    return Ok(productList);
    //}

    //[HttpGet("{id}")]
    //public async Task<IActionResult> Get(int id)
    //{
    //    var product = await Mediator.Send(new GetProductByIdQuery(id));
    //    return Ok(product);
    //}

    //[HttpPost]
    //public async Task<IActionResult> Post([FromBody] Products products)
    //{
    //    var product = await Mediator.Send(new CreateProductCommand(products.Name, products.Description, products.Price));
    //    return Ok(product);
    //}
    //[HttpPut("{id}")]
    //public async Task<IActionResult> Put(int id, [FromBody] Products products)
    //{
    //    int productId = await Mediator.Send(new UpdateProductCommand(
    //        id, products.Name, products.Description, products.Price));
    //    return Ok(productId);
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(int id)
    //{
    //    int productId = await Mediator.Send(new DeleteProductCommand(id));
    //    return Ok(productId);
    //}

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productList = await Mediator.Send(new GetProductsQuery());
        return Ok(productList);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand entity)
    {
        var newProduct = await Mediator.Send(entity);

        return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await Mediator.Send(new GetProductByIdQuery() { Id = id });

        return Ok(product);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProductCommand entity)
    {
        if (id != entity.Id)
            return BadRequest();

        var upProduct = await Mediator.Send(entity);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var delProduct = await Mediator.Send(new DeleteProductCommand() { Id = id });

        return NoContent();
    }
}