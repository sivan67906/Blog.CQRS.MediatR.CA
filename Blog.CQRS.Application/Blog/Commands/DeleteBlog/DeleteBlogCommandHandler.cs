using Blog.CQRS.Domain.Interfaces;
using MediatR;

namespace Blog.CQRS.Application.Blog.Commands.DeleteBlog;

public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, int>
{
    private readonly IBlogRepository _blogRepository;

    public DeleteBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        var result = await _blogRepository.DeleteAsync(request.Id);
        return result;
    }
}
