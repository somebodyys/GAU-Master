using System.ComponentModel.DataAnnotations;
using HomeworkTwo.Models;

namespace HomeworkTwo.Validators;

public class ProductValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var product = (Product)validationContext.ObjectInstance;
        
        if (product.Price == 0 && product.Stock > 0)
            return new ValidationResult("If the price is 0, the stock must also be 0.");

        return ValidationResult.Success;
    }
}