using MediatR;

namespace Blog.CQRS.Application.Product.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<int>
{
    //public UpdateProductCommand(int id, string name, string description, double price)
    //{
    //    Id = id;
    //    Name = name;
    //    Description = description;
    //    Price = price;
    //}
    public UpdateProductCommand()
    {
        
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}
