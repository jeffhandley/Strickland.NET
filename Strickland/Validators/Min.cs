namespace Strickland.Validators
{
    public class Min<T> : Validator<T> where T : IComparisonOperators<T, T>
    {
        public T MinValue { get; }

        public Min(T minValue)
        {
            MinValue = minValue;
        }

        public override bool Validate(T value)
        {
            if (value >= MinValue)
            {
                return true;
            }

            return false;
        }
    }
}
