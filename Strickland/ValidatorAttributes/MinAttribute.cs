using Strickland.Validators;

namespace Strickland.ValidatorAttributes
{
    public class MinAttribute<T> : ValidatorAttribute<T> where T : IComparisonOperators<T, T>
    {
        public T MinValue { get; set; }
        public MinAttribute(T minValue) => MinValue = minValue;

        public override Validator<T, object?> CreateValidator()
            => new Min<T, object?>(MinValue);

        public override Validator<T, ValidationContext> CreateValidator<ValidationContext>()
            => new Min<T, ValidationContext>(MinValue);
    }
}