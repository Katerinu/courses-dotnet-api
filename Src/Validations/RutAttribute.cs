using System.ComponentModel.DataAnnotations;

namespace courses_dotnet_api.Src.Validations;

public class RutAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrEmpty(value.ToString()))
        {
            return new ValidationResult("Rut is required");
        }

        string? rut = value.ToString();

        if (!IsValidRut(rut))
        {
            return new ValidationResult("Invalid Rut");
        }

        return ValidationResult.Success;
    }

    private static bool IsValidRut(string? rut)
    {
        if (string.IsNullOrEmpty(rut))
        {
            return false;
        }

        rut = rut.Replace(".", "").Replace("-", "").ToLower();
        if (!int.TryParse(rut.AsSpan(0, rut.Length - 1), out int number))
        {
            return false;
        }

        char dv = rut[^1];
        return dv == GetDV(number);
    }

    private static char GetDV(int number)
    {
        int m = 0,
            s = 1;
        for (; number != 0; number /= 10)
        {
            s = (s + number % 10 * (9 - m++ % 6)) % 11;
        }

        return (char)(s != 0 ? s + 47 : 75);
    }
}
