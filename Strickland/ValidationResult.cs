namespace Strickland
{
    public record ValidationResult<T, ValidationContext>(bool IsValid, T Value, ValidationContext? Context = default);
    public record ValidationResult<T, ValidationContext, ValidatorProperties>(bool IsValid, T Value, ValidationContext? Context = default, ValidatorProperties? Properties = default);
}
