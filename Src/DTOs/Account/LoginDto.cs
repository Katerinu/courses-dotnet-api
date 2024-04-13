using System.ComponentModel.DataAnnotations;

namespace courses_dotnet_api.Src.DTOs.Account;

public class LoginDto
{
    [EmailAddress]
    public required string Email { get; set; }

    [StringLength(
        20,
        MinimumLength = 8,
        ErrorMessage = "Password must be between 8 and 20 characters"
    )]
    public required string Password { get; set; }
}
