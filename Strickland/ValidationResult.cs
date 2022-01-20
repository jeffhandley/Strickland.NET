namespace Strickland
{
    public record ValidationResult<T>(bool IsValid, T Value);
    public record ValidationResult<T, V>(bool IsValid, T Value, V Validator) where V : IValidator<T>;
}
