namespace Strickland.Validators
{
    public class Min<T> : Validator<T> where T : IComparisonOperators<T, T>
    {
        public T MinValue { get; }

        public Min(T minValue, IDictionary<string, object?>? properties = null) : base(properties)
        {
            MinValue = minValue;
            Properties[nameof(MinValue)] = minValue;
        }

        public override bool Validate<C>(T value, C context)
        {
            if (value >= MinValue)
            {
                return true;
            }

            return false;
        }
    }
}
