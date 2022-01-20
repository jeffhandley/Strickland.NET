using Strickland.Composition;

namespace Strickland.Validators
{
    public class Range<T> : Every<T> where T : IComparisonOperators<T, T>
    {
        public T MinLimit { get; init; }
        public T MaxLimit { get; init; }

        public Range(T minLimit, T maxLimit) : base(new Min<T>(minLimit), new Max<T>(maxLimit))
        {
            MinLimit = minLimit;
            MaxLimit = maxLimit;
        }
    }
}
