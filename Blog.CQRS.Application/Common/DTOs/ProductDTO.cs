using Blog.CQRS.Application.Common.Mappings;
using Blog.CQRS.Domain.Entities;

namespace Blog.CQRS.Application.Common.DTOs;

public class ProductDTO : IMapFrom<Products>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}
