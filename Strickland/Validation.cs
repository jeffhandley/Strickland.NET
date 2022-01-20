namespace Strickland
{
    public static class Validation
    {
        public static ValidationResult<T, object?> Validate<T>(T value, Func<T, bool> validator)
        {
            var isValid = validator(value);
            return new(isValid, value, null);
        }

        public static ValidationResult<T, V, object?> Validate<T, V>(T value, V validator) where V : IValidatorFunction<T>
        {
            var isValid = validator.IsValid(value);
            return new(isValid, value, validator, null);
        }

        public static ValidationResult<T, P> Validate<T, P>(T value, Func<T, (bool IsValid, P Properties)> validator)
        {
            var result = validator(value);
            return new(result.IsValid, value, result.Properties);
        }

        public static ValidationResult<T, P> Validate<T, P>(T value, Validator<T, P> validator)
        {
            var isValid = validator.Validate(value);
            var result = new ValidationResult<T>(isValid, value);
            var properties = validator.ResolveProperties(result);

            return new(isValid, value, properties);
        }
    }
}
