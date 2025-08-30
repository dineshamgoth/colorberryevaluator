using System.ComponentModel.DataAnnotations;
using BerryTestProject1.Berry.Core;
public class UserRegistrationVM
{
    [Required]
    [Display(Name = "Full Name")]
    public required string FullName { get; set; }

    [Required]
    [MinLength(6, ErrorMessage = "Username must be at least 6 characters.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*\d)[a-z0-9\.]+$",
    ErrorMessage = "Username must contain at least one lowercase letter, one digit, and may only include '.' as a special character.")]
    public required string Username { get; set; }

    [Required]
    public required string Gender{ get; set; }

    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        ErrorMessage = "Please enter a valid email address.")]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
    public required string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public required string ConfirmPassword { get; set; }
}
