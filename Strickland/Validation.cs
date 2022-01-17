using Strickland.Validators;

namespace Strickland
{
    public static class Validation
    {
        // Bool from a Validator Function
        public static bool IsValid<T>(Func<T, bool> validator, T value)
            => validator(value);

        // Bool from a Validator Function Interface
        public static bool IsValid<T>(IValidatorFunction<T> validator, T value)
            => validator.IsValid(value);

        // Bool from a Validator
        public static bool IsValid<T>(IValidator<T> validator, T value)
            => validator.Validate(value).IsValid;

        // Bool from a Validator Factory Function
        public static bool IsValid<C, T>(C context, Func<C, IValidatorFunction<T>> validator, T value)
            => validator(context).IsValid(value);

        // Bool from a Validator Factory Interface
        public static bool IsValid<C, V, T>(C context, IValidatorFactory<C, V, T> factory, T value)
            where V : IValidatorFunction<T>
            => factory.GetValidator(context).IsValid(value);

        // ValidationResult from a Validator Function
        public static ValidationResult<T> Validate<T>(Func<T, bool> validator, T value)
            => Validator<T>.From(validator).Validate(value);

        // ValidationResult from a Validator Function Interface
        public static ValidationResult<T> Validate<T>(IValidatorFunction<T> validator, T value)
            => Validator<T>.From(validator).Validate(value);

        // ValidationResult from a Validator Function
        public static ValidationResult<T> Validate<T>(Func<T, ValidationResult<T>> validator, T value)
            => Validator<T>.From(validator).Validate(value);

        // ValidationResult from a Validator
        public static ValidationResult<T> Validate<T>(IValidator<T> validator, T value)
            => validator.Validate(value);

        // ValidationResult (with properties) from a Validator
        public static ValidationResult<T, P> Validate<T, P>(IValidator<T, P> validator, T value)
            => validator.Validate(value);
    }
}
