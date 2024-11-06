using MediatR;

namespace Blog.CQRS.Application.Blog.Commands.DeleteBlog;

public class DeleteBlogCommand : IRequest<int>
{
    public DeleteBlogCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
