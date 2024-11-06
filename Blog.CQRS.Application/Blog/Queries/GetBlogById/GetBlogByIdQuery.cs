using Blog.CQRS.Application.Common.DTOs;
using MediatR;

namespace Blog.CQRS.Application.Blog.Queries.GetBlogById;

public class GetBlogByIdQuery : IRequest<BlogDTO>
{
    public GetBlogByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
