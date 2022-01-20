namespace Strickland
{
    public class Validator<T, P>
    {
        public Func<T, bool> Validate { get; init; }
        public Func<ValidationResult<T>, P> ResolveProperties { get; init; }

        public Validator(Func<T, bool> validate, Func<ValidationResult<T>, P> resolveProperties)
        {
            Validate = validate;
            ResolveProperties = resolveProperties;
        }

        public static implicit operator (Func<T, bool> Validate, Func<ValidationResult<T>, P> ResolveProperties)(Validator<T, P> validator) => (validator.Validate, validator.ResolveProperties);
        public static implicit operator Validator<T, P>((Func<T, bool> Validate, Func<ValidationResult<T>, P> ResolveProperties) validator) => new(validator.Validate, validator.ResolveProperties);
    }

    public static class Validator
    {
        public static Validator<T, P> From<T, P>(Func<T, bool> validate, Func<ValidationResult<T>, P> resolveProperties)
            => new Validator<T, P>(validate, resolveProperties);
    }
}
