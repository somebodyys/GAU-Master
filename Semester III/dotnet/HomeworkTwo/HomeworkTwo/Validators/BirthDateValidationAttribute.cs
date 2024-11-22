using System.ComponentModel.DataAnnotations;

namespace HomeworkTwo.Validators;

public class BirthDateValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (birthDate.Date > DateTime.Now.AddYears(-age)) age--;

            if (age < 18)
                return new ValidationResult(ErrorMessage ?? "User must be at least 18 years old.");
        }

        return ValidationResult.Success;
    }
}