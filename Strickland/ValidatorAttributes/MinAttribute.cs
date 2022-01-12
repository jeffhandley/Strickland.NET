using Strickland.Validators;

namespace Strickland.ValidatorAttributes
{
    public class MinAttribute<T> : ValidatorAttribute<T> where T : IComparisonOperators<T, T>
    {
        public T MinValue { get; }

        public MinAttribute(T minValue)
        {
            MinValue = minValue;
        }

        public override Validator<T> CreateValidator(IDictionary<string, object?> properties)
        {
            return new Min<T>(MinValue, properties);
        }
    }
}