using Blog.CQRS.Application.Common.DTOs;
using Blog.CQRS.Domain.Entities;
using Blog.CQRS.Domain.Interfaces;
using MediatR;

namespace Blog.CQRS.Application.Product.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDTO>
{
    private readonly IProductRepository _productRepository;
    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Products
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };
        var createProduct = await _productRepository.CreateAsync(entity);
        var result = new ProductDTO
        {
            Name = createProduct.Name,
            Description = createProduct.Description,
            Price = createProduct.Price
        };
        return result;
    }
}
