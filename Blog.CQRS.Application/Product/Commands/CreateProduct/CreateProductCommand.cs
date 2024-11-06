using Blog.CQRS.Application.Common.DTOs;
using MediatR;
namespace Blog.CQRS.Application.Product.Commands.CreateProduct;

public class CreateProductCommand : IRequest<ProductDTO>
{
    //public CreateProductCommand(string name, string description, double price)
    //{
    //    Name = name;
    //    Description = description;
    //    Price = price;
    //}
    public CreateProductCommand()
    {
        
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}