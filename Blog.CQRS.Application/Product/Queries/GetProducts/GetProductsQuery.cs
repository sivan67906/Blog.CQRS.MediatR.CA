using Blog.CQRS.Application.Common.DTOs;
using MediatR;

namespace Blog.CQRS.Application.Product.Queries.GetProducts;

public class GetProductsQuery : IRequest<List<ProductDTO>>
{
}
