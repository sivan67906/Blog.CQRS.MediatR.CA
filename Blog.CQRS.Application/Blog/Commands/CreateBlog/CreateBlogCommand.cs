﻿using Blog.CQRS.Application.Common.DTOs;
using MediatR;
namespace Blog.CQRS.Application.Blog.Commands.CreateBlog;

public class CreateBlogCommand : IRequest<BlogDTO>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
}