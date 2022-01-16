namespace Strickland.Validators
{
    public class Min<T, ValidationContext, ValidatorProperties> : Validator<T, ValidationContext, ValidatorProperties> where T : IComparisonOperators<T, T>
    {
        private readonly Min<T, ValidationContext> _validator;
        public readonly Func<ValidationResult<T, ValidationContext>, ValidatorProperties?> GetProperties;

        public Min(Min<T, ValidationContext> validator, Func<ValidationResult<T, ValidationContext>, ValidatorProperties?> getProperties) : base()
        {
            _validator = validator;
            GetProperties = getProperties;
        }

        public override ValidationResult<T, ValidationContext, ValidatorProperties> Validate(T value, ValidationContext? context = default)
        {
            var result = _validator.Validate(value, context);
            return new ValidationResult<T, ValidationContext, ValidatorProperties>(result.IsValid, value, result.Context, GetProperties(result));
        }
    }

    public class Min<T, ValidationContext> : Validator<T, ValidationContext> where T : IComparisonOperators<T, T>
    {
        private Func<ValidationContext?, T> _getMinValue;

        public Min(Func<ValidationContext?, T> getMinValue) => _getMinValue = getMinValue;
        public Min(Func<T> getMinValue) : this((context) => getMinValue()) { }
        public Min(T minValue) : this((context) => minValue) { }

        public override ValidationResult<T, ValidationContext> Validate(T value, ValidationContext? context = default)
        {
            var isValid = value >= _getMinValue(context);

            return new ValidationResult<T, ValidationContext>(isValid, value, context);
        }

        public virtual Min<T, ValidationContext, ValidatorProperties> With<ValidatorProperties>(ValidatorProperties? properties)
            => new(this, (context) => properties);

        public virtual Min<T, ValidationContext, ValidatorProperties> With<ValidatorProperties>(Func<ValidationResult<T, ValidationContext>, ValidatorProperties?> getProperties)
            => new(this, getProperties);
    }

    public static class Min
    {
        public static Min<T, object?> Of<T>(T minValue) where T : IComparisonOperators<T, T>
            => new(minValue);

        public static Min<T, object?> Of<T>(Func<T> getMinValue) where T : IComparisonOperators<T, T>
            => new(getMinValue);

        public static Min<T, ValidationContext> Of<T, ValidationContext>(Func<ValidationContext?, T> getMinValue) where T : IComparisonOperators<T, T>
            => new(getMinValue);
    }
}
