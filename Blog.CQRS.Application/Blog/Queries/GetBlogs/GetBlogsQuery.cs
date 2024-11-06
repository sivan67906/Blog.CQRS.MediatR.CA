using Blog.CQRS.Application.Common.DTOs;
using MediatR;

namespace Blog.CQRS.Application.Blog.Queries.GetBlogs;

public class GetBlogsQuery : IRequest<List<BlogDTO>>
{

}
