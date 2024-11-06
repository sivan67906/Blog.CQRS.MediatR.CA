using Blog.CQRS.Domain.Entities;
using Blog.CQRS.Domain.Interfaces;
using Blog.CQRS.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.CQRS.Persistence.Repositories;

public class BlogRepository : IBlogRepository
{
    private readonly BlogCQRSDbContext _blogCQRSDbContext;

    public BlogRepository(BlogCQRSDbContext blogCQRSDbContext)
    {
        _blogCQRSDbContext = blogCQRSDbContext;
    }
    public async Task<Blogs> CreateAsync(Blogs entity)
    {
        var result = _blogCQRSDbContext.BlogList.Add(entity);
        await _blogCQRSDbContext.SaveChangesAsync();
        return result.Entity;
    }
    public async Task<int> DeleteAsync(int id)
    {
        var result = await _blogCQRSDbContext.BlogList.Where(i => i.Id == id).ExecuteDeleteAsync();
        return result;
    }
    public async Task<List<Blogs>> GetAllBlogsAsync()
    {
        List<Blogs> result = await _blogCQRSDbContext.BlogList.ToListAsync();
        return result;
    }
    public async Task<Blogs> GetBlogByIdAsync(int id)
    {
        var result = await _blogCQRSDbContext.BlogList.Where(emp => emp.Id == id).FirstOrDefaultAsync();
        return result;
    }
    public async Task<int> UpdateAsync(int id, Blogs entity)
    {
        var result = await _blogCQRSDbContext.BlogList.Where(i => i.Id == id)
            .ExecuteUpdateAsync(b => b
            .SetProperty(b => b.Name, entity.Name)
            .SetProperty(b => b.Description, entity.Description)
            .SetProperty(b => b.Author, entity.Author)
            );
        return result;
    }
}
