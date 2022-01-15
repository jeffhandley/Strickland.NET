namespace Strickland.Validators
{
    public abstract class Validator<T, ValidationContext>
    {
        public abstract ValidationResult<ValidationContext> Validate(T value, ValidationContext? context = default);
    }
}
