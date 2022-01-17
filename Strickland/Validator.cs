namespace Strickland
{
    public class Validator<T> : IValidator<T>
    {
        private readonly Func<T, ValidationResult<T>> _validate;

        private Validator(Func<T, ValidationResult<T>> validator) => _validate = validator;

        public ValidationResult<T> Validate(T value) => _validate(value);

        public static Validator<T> From(Func<T, ValidationResult<T>> validator)
            => new(validator);

        public static Validator<T> From(Func<T, bool> validator)
            => new((value) => new ValidationResult<T>(value, validator(value)));

        public static Validator<T> From(IValidatorFunction<T> validator)
            => new((value) => new ValidationResult<T>(value, validator.IsValid(value)));

        public static Validator<T> From(IValidator<T> validator)
            => new(validator.Validate);
    }

    public class Validator<T, P> : IValidator<T, P>
    {
        private readonly Func<T, ValidationResult<T, P>> _validate;

        private Validator(Func<T, ValidationResult<T, P>> validator) => _validate = validator;

        public ValidationResult<T, P> Validate(T value) => _validate(value);

        public static Validator<T, P> From(Func<T, ValidationResult<T, P>> validator)
            => new(validator);

        public static Validator<T, P> From(Func<T, ValidationResult<T>> validator, P properties)
            => new((value) => new(validator(value), properties));

        public static Validator<T, P> From(Func<T, bool> validator, P properties)
            => new((value) => new(value, validator(value), properties));

        public static Validator<T, P> From(IValidator<T, P> validator)
            => new(validator.Validate);

        public static Validator<T, P> From(IValidator<T> validator, P properties)
            => new((value) => new(validator.Validate(value), properties));

        public static Validator<T, P> From(IValidatorFunction<T> validator, P properties)
            => new((value) => new(value, validator.IsValid(value), properties));
    }
}
