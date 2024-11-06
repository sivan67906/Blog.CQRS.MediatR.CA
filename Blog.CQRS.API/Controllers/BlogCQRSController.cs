using Blog.CQRS.Application.Blog.Commands.CreateBlog;
using Blog.CQRS.Application.Blog.Commands.DeleteBlog;
using Blog.CQRS.Application.Blog.Commands.UpdateBlog;
using Blog.CQRS.Application.Blog.Queries.GetBlogById;
using Blog.CQRS.Application.Blog.Queries.GetBlogs;
using Blog.CQRS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog.CQRS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogCQRSController : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var blogList = await Mediator.Send(new GetBlogsQuery());
        return Ok(blogList);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var blog = await Mediator.Send(new GetBlogByIdQuery(id));
        return Ok(blog);
    }

    //[HttpPost]
    //public async Task<IActionResult> Create(CreateBlogCommand entity)
    //{
    //    var newBlog = await Mediator.Send(entity);

    //    return CreatedAtAction(nameof(GetById), new { id = newBlog.Id }, newBlog);
    //}

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Blogs blogs)
    {
        var blog = await Mediator.Send(new CreateBlogCommand(blogs.Name, blogs.Description, blogs.Author));
        return Ok(blog);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Blogs blogs)
    {
        int blogId = await Mediator.Send(new UpdateBlogCommand(
            id, blogs.Name, blogs.Description, blogs.Author));
        return Ok(blogId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        int blogId = await Mediator.Send(new DeleteBlogCommand(id));
        return Ok(blogId);
    }
}