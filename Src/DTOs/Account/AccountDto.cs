using System.ComponentModel.DataAnnotations;
using courses_dotnet_api.Src.Validations;

namespace courses_dotnet_api.Src.DTOs.Account;

public class AccountDto
{
    [Rut]
    public required string Rut { get; set; }

    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
    public required string Name { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    public required string Token { get; set; }
}
