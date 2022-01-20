namespace Strickland
{
    public record ValidationResult<T>(bool IsValid, T Value);
    public record ValidationResult<T, P>(bool IsValid, T Value, P Properties) : ValidationResult<T>(IsValid, Value);
    public record ValidationResult<T, V, P>(bool IsValid, T Value, V Validator, P Properties) : ValidationResult<T, P>(IsValid, Value, Properties) where V : IValidatorFunction<T>;
}
