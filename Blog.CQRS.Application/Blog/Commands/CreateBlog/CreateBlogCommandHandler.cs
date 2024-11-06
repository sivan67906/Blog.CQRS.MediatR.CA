using Blog.CQRS.Application.Common.DTOs;
using Blog.CQRS.Domain.Entities;
using Blog.CQRS.Domain.Interfaces;
using MediatR;

namespace Blog.CQRS.Application.Blog.Commands.CreateBlog;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogDTO>
{
    private readonly IBlogRepository _blogRepository;
    public CreateBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<BlogDTO> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var entity = new Blogs
        {
            Name = request.Name,
            Description = request.Description,
            Author = request.Author
        };
        var createBlog = await _blogRepository.CreateAsync(entity);
        var result = new BlogDTO
        {
            Name = createBlog.Name,
            Description = createBlog.Description,
            Author = createBlog.Author
        };
        return result;
    }
}
