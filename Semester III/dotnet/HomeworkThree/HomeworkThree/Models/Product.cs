using System.ComponentModel.DataAnnotations;

namespace HomeworkThree.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Product Name is required.")]
    [StringLength(100, ErrorMessage = "Product Name cannot exceed 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Category is required.")]
    public string Category { get; set; }
}