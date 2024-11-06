using Blog.CQRS.Domain.Entities;

namespace Blog.CQRS.Domain.Interfaces;

public interface IProductRepository { 
    Task<List<Products>> GetAllProductsAsync();
    Task<Products> GetProductByIdAsync(int id);
    Task<Products> CreateAsync(Products entity);
    Task<int> UpdateAsync(int id, Products entity);
    Task<int> DeleteAsync(int id);
}
