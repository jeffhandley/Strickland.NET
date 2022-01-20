namespace Strickland
{
    public static class Validation
    {
        public static ValidationResult<T> Validate<T>(T value, Func<T, bool> validator)
        {
            var isValid = validator(value);
            return new(isValid, value);
        }

        public static ValidationResult<T, V> Validate<T, V>(T value, V validator) where V : IValidator<T>
        {
            var isValid = validator.IsValid(value);
            return new(isValid, value, validator);
        }
    }
}
