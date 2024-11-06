using MediatR;

namespace Blog.CQRS.Application.Product.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<int>
{
    //public DeleteProductCommand(int id)
    //{
    //    Id = id;
    //}
    public DeleteProductCommand()
    {
        
    }
    public int Id { get; set; }
}
