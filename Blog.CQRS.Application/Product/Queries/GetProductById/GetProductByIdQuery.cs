using Blog.CQRS.Application.Common.DTOs;
using MediatR;

namespace Blog.CQRS.Application.Product.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<ProductDTO>
{
    //public GetProductByIdQuery(int id)
    //{
    //    Id = id;
    //}
    public GetProductByIdQuery()
    {
        
    }
    public int Id { get; set; }
}
