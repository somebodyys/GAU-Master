using System.ComponentModel.DataAnnotations;
using HomeworkTwo.Validators;

namespace HomeworkTwo.Models;

public class User
{
    [Required]
    [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    [Required]
    [BirthDateValidation(ErrorMessage = "User must be at least 18 years old.")]
    public DateTime BirthDate { get; set; }

    [Phone(ErrorMessage = "Invalid phone number.")]
    [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Phone number must be a valid mobile number format.")]
    public string? PhoneNumber { get; set; }
}