using HomeworkThree.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkThree.Controllers;

public class ProductController : Controller
{
    private static List<Product> Products = [
        new Product { Id = 1, Name = "Laptop", Description = "15 inch Laptop", Price = 799.99m, Category = "Electronics" },
        new Product { Id = 2, Name = "Headphones", Description = "Noise Cancelling Headphones", Price = 199.99m, Category = "Electronics" }
    ];

    [HttpGet]
    public ActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    public ActionResult AddProduct(Product product)
    {
        if (ModelState.IsValid)
        {
            product.Id = Products.Max(p => p.Id) + 1;
            Products.Add(product);
            return RedirectToAction("ProductList");
        }
        return View(product);
    }

    public ActionResult ProductDetails(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();
        return View(product);
    }

    public ActionResult ProductList()
    {
        return View(Products);
    }

    [HttpGet]
    public ActionResult EditProduct(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();
        return View(product);
    }

    [HttpPost]
    public ActionResult EditProduct(Product updatedProduct)
    {
        var existingProduct = Products.FirstOrDefault(p => p.Id == updatedProduct.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Category = updatedProduct.Category;
            return RedirectToAction("ProductList");
        }
        return NotFound();
    }
}