using Blog.CQRS.Application.Common.DTOs;
using Blog.CQRS.Domain.Interfaces;
using MediatR;

namespace Blog.CQRS.Application.Product.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var blog = await _productRepository.GetProductByIdAsync(request.Id);
        var entity = new ProductDTO
        {
            Id = blog.Id,
            Name = blog.Name,
            Description = blog.Description,
            Price = blog.Price
        };
        return entity;
    }
}
