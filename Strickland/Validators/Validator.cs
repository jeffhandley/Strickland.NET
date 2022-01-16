namespace Strickland.Validators
{
    public abstract class Validator<T, ValidationContext, ValidatorProperties>
    {
        public abstract ValidationResult<T, ValidationContext, ValidatorProperties> Validate(T value, ValidationContext? context = default);
    }

    public abstract class Validator<T, ValidationContext>
    {
        public abstract ValidationResult<T, ValidationContext> Validate(T value, ValidationContext? context = default);
    }
}
