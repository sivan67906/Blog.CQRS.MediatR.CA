using Blog.CQRS.Domain.Interfaces;
using Blog.CQRS.Persistence.Data;
using Blog.CQRS.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.CQRS.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BlogCQRSDbContext>(opt => opt.UseSqlite(configuration.GetConnectionString("blogCQRSCS") ?? throw new InvalidOperationException("Connection string not found")));
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}
