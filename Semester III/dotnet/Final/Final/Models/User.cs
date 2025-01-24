using System.ComponentModel.DataAnnotations;

namespace Final.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    [StringLength(11, ErrorMessage = "ID Number must be 11 digits", MinimumLength = 11)]
    public string IDNumber { get; set; }

    [Required]
    [Phone]
    public string MobilePhone { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    public string? PasswordHash { get; set; }
}