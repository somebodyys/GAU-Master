using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeworkThree.Models;

namespace HomeworkThree.Controllers;

public class HomeController : Controller
{
    private static List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Description = "15 inch Laptop", Price = 799.99m, Category = "Electronics" },
        new Product { Id = 2, Name = "Headphones", Description = "Noise Cancelling Headphones", Price = 199.99m, Category = "Electronics" }
    };

    public IActionResult Index()
    {
        return View(Products);
    }
}