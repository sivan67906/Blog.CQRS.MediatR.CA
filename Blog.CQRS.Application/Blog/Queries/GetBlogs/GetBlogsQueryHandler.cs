using Blog.CQRS.Application.Common.DTOs;
using Blog.CQRS.Domain.Entities;
using Blog.CQRS.Domain.Interfaces;
using MediatR;

namespace Blog.CQRS.Application.Blog.Queries.GetBlogs;

public class GetBlogsQueryHandler : IRequestHandler<GetBlogsQuery, List<BlogDTO>>
{
    private readonly IBlogRepository _blogRepository;
    public GetBlogsQueryHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }
    public async Task<List<BlogDTO>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
    {
        var blog = await _blogRepository.GetAllBlogsAsync();
        //var blogDTO = new List<BlogDTO>();

        //var result = blogDTO.Join(blog, d => d.Id, s => s.Id, (d, s) =>
        //{
        //    d.Id = s.Id;
        //    d.Name = s.Name;
        //    d.Description = s.Description;
        //    d.Author = s.Author;
        //    return d;
        //}).ToList();
        //return result;
        var blogList = blog.Select(x => new BlogDTO
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Author = x.Author
        }).ToList();

        return blogList;

    }
}
