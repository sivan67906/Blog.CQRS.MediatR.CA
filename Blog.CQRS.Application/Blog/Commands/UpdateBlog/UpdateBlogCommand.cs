using MediatR;

namespace Blog.CQRS.Application.Blog.Commands.UpdateBlog;

public class UpdateBlogCommand : IRequest<int>
{
    public UpdateBlogCommand(int id, string name, string description, string author)
    {
        Id = id;
        Name = name;
        Description = description;
        Author = author;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }

}
