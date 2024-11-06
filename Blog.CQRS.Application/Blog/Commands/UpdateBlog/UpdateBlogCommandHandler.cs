using Blog.CQRS.Domain.Entities;
using Blog.CQRS.Domain.Interfaces;
using MediatR;

namespace Blog.CQRS.Application.Blog.Commands.UpdateBlog;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
{
    private readonly IBlogRepository _blogRepository;

    public UpdateBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var entity = new Blogs
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            Author = request.Author
        };

        var updateBlog = await _blogRepository.UpdateAsync(request.Id, entity);
        return updateBlog;
    }
}
