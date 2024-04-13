using System.ComponentModel.DataAnnotations;
using courses_dotnet_api.Src.Validations;

namespace courses_dotnet_api.Src.DTOs.Account;

public class RegisterDto
{
    [Rut]
    public required string Rut { get; set; }

    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
    public required string Name { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    [StringLength(
        20,
        MinimumLength = 8,
        ErrorMessage = "Password must be between 8 and 20 characters"
    )]
    public required string Password { get; set; }

    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public required string ConfirmPassword { get; set; }
}
