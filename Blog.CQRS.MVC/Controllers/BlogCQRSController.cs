using Blog.CQRS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog.CQRS.MVC.Controllers;

public class BlogCQRSController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product blogs)
    {
        return View(blogs);
    }

    [HttpPost]
    public IActionResult Update(Product blogs)
    {
        return View(blogs);
    }

    [HttpPost]
    public IActionResult Delete(Product blogs)
    {
        return View();
    }
}
