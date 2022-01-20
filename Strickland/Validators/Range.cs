using Strickland.Composition;

namespace Strickland.Validators
{
    public class Range<T> : Every<T> where T : IComparisonOperators<T, T>
    {
        public T MinValue { get; init; }
        public T MaxValue { get; init; }

        public Range(T minValue, T maxValue) : base(new Min<T>(minValue), new Max<T>(maxValue))
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }
}
