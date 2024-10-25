using HomeworkOne.Filters;
using HomeworkOne.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkOne.Controllers;

[ApiController]
[Route("api/[controller]")]
[ServiceFilter(typeof(LoggingFilter))]
[ServiceFilter(typeof(BasicAuthorizationFilter))]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "IPhone 16 Pro", Price = 9.99M },
        new Product { Id = 2, Name = "Dreame X40 Ultra", Price = 19.99M }
    };
    
    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok(Products);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetProductById(int id)
    {
        var product = Products.FirstOrDefault(item => item.Id == id);
        
        if (product == null)
            return NotFound(new { message = $"Product with ID {id} not found" });
        
        return Ok(product);
    }
    
    [HttpPost]
    public IActionResult CreateProduct([FromBody] Product newProduct)
    {
        newProduct.Id = Products.Max(p => p.Id) + 1;
        Products.Add(newProduct);
    
        var resourceUrl = Url.Action("GetProductById", new { id = newProduct.Id });
        return Created(resourceUrl, newProduct);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
    {
        var existingProduct = Products.FirstOrDefault(p => p.Id == id);
        
        if (existingProduct == null) 
            return NotFound(new { message = $"Product with ID {id} not found" });
    
        if (id != updatedProduct.Id)
            return BadRequest(new { message = "Invalid product data" });
        
        existingProduct.Name = updatedProduct.Name;
        existingProduct.Price = updatedProduct.Price;
    
        return Ok(existingProduct);
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound(new { message = $"Product with ID {id} not found" });
    
        Products.Remove(product);
        
        return NoContent();
    }
}