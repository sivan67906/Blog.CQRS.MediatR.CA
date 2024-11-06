using Blog.CQRS.Application.Common.DTOs;
using Blog.CQRS.Domain.Entities;
using Blog.CQRS.Domain.Interfaces;
using MediatR;

namespace Blog.CQRS.Application.Blog.Queries.GetBlogById;

public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogDTO>
{
    private readonly IBlogRepository _blogRepository;

    public GetBlogByIdQueryHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<BlogDTO> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var blog = await _blogRepository.GetBlogByIdAsync(request.Id);
        var entity = new BlogDTO
        {
            Id = blog.Id,
            Name = blog.Name,
            Description = blog.Description,
            Author = blog.Author
        };
        return entity;
    }
}
