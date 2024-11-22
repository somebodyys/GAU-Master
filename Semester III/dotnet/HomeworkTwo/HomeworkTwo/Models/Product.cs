using System.ComponentModel.DataAnnotations;
using HomeworkTwo.Validators;

namespace HomeworkTwo.Models;

[ProductValidation]
public class Product
{
    [Required]
    [StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters.")]
    public string ProductName { get; set; }

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string? Description { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative.")]
    public decimal Price { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Stock must be a positive number.")]
    public int Stock { get; set; }
}