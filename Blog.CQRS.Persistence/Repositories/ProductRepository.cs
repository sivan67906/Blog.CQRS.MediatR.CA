using Blog.CQRS.Domain.Entities;
using Blog.CQRS.Domain.Interfaces;
using Blog.CQRS.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.CQRS.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly BlogCQRSDbContext _blogCQRSDbContext;

    public ProductRepository(BlogCQRSDbContext blogCQRSDbContext)
    {
        _blogCQRSDbContext = blogCQRSDbContext;
    }
    public async Task<Products> CreateAsync(Products entity)
    {
        var result = _blogCQRSDbContext.ProductList.Add(entity);
        await _blogCQRSDbContext.SaveChangesAsync();
        return result.Entity;
    }


    public async Task<int> DeleteAsync(int id)
    {
        var result = await _blogCQRSDbContext.ProductList.Where(i => i.Id == id).ExecuteDeleteAsync();
        return result;
    }
    public async Task<List<Products>> GetAllProductsAsync()
    {
        List<Products> result = await _blogCQRSDbContext.ProductList.ToListAsync();
        return result;
    }
    public async Task<Products> GetProductByIdAsync(int id)
    {
        var result = await _blogCQRSDbContext.ProductList.Where(emp => emp.Id == id).FirstOrDefaultAsync();
        return result;
    }
    public async Task<int> UpdateAsync(int id, Products entity)
    {
        var result = await _blogCQRSDbContext.ProductList.Where(i => i.Id == id)
            .ExecuteUpdateAsync(b => b
            .SetProperty(b => b.Name, entity.Name)
            .SetProperty(b => b.Description, entity.Description)
            .SetProperty(b => b.Price, entity.Price)
            );
        return result;
    }

}
