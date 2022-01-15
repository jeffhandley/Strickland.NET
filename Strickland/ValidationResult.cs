namespace Strickland
{
    public record ValidationResult<ValidationContext>(bool IsValid, ValidationContext? Context = default);
}
