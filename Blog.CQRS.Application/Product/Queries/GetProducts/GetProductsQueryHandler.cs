using Blog.CQRS.Application.Common.DTOs;
using Blog.CQRS.Domain.Interfaces;
using MediatR;

namespace Blog.CQRS.Application.Product.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDTO>>
{
    private readonly IProductRepository _productRepository;
    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<List<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var blog = await _productRepository.GetAllProductsAsync();
        //var blogDTO = new List<BlogDTO>();

        //var result = blogDTO.Join(blog, d => d.Id, s => s.Id, (d, s) =>
        //{
        //    d.Id = s.Id;
        //    d.Name = s.Name;
        //    d.Description = s.Description;
        //    d.Author = s.Author;
        //    return d;
        //}).ToList();
        //return result;
        var blogList = blog.Select(x => new ProductDTO
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Price = x.Price
        }).ToList();

        return blogList;

    }
}
