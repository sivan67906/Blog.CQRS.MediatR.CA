using Blog.CQRS.Domain.Entities;

namespace Blog.CQRS.Domain.Interfaces;

public interface IBlogRepository
{
    Task<List<Blogs>> GetAllBlogsAsync();
    Task<Blogs> GetBlogByIdAsync(int id);
    Task<Blogs> CreateAsync(Blogs entity);
    Task<int> UpdateAsync(int id, Blogs entity);
    Task<int> DeleteAsync(int id);
}
