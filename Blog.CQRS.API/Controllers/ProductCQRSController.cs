using Blog.CQRS.Application.Product.Commands.CreateProduct;
using Blog.CQRS.Application.Product.Commands.DeleteProduct;
using Blog.CQRS.Application.Product.Commands.UpdateProduct;
using Blog.CQRS.Application.Product.Queries.GetProductById;
using Blog.CQRS.Application.Product.Queries.GetProducts;
using Blog.CQRS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog.CQRS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductCQRSController : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productList = await Mediator.Send(new GetProductsQuery());
        return Ok(productList);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var product = await Mediator.Send(new GetProductByIdQuery(id));
        return Ok(product);
    }

    //[HttpPost]
    //public async Task<IActionResult> Create(CreateBlogCommand entity)
    //{
    //    var newBlog = await Mediator.Send(entity);

    //    return CreatedAtAction(nameof(GetById), new { id = newBlog.Id }, newBlog);
    //}

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Products products)
    {
        var product = await Mediator.Send(new CreateProductCommand(products.Name, products.Description, products.Price));
        return Ok(product);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Products products)
    {
        int productId = await Mediator.Send(new UpdateProductCommand(
            id, products.Name, products.Description, products.Price));
        return Ok(productId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        int productId = await Mediator.Send(new DeleteProductCommand(id));
        return Ok(productId);
    }
}