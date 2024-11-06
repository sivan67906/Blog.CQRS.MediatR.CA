using Blog.CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.CQRS.Persistence.Data;

public class BlogCQRSDbContext : DbContext
{
    public BlogCQRSDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Blogs> BlogList { get; set; }
    public DbSet<Products> ProductList { get; set; }
}
