using Blog.CQRS.Domain.Entities;
using Blog.CQRS.Domain.Interfaces;
using MediatR;

namespace Blog.CQRS.Application.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Products
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };

        var updateBlog = await _productRepository.UpdateAsync(request.Id, entity);
        return updateBlog;
    }
}
