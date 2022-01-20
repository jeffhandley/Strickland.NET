using Strickland.Composition;

namespace Strickland.Validators
{
    public class RangeValidator<T> : EveryValidator<T> where T : IComparisonOperators<T, T>
    {
        public T Min { get; init; }
        public T Max { get; init; }

        public RangeValidator(T min, T max) : base(new MinValidator<T>(min), new MaxValidator<T>(max))
        {
            Min = min;
            Max = max;
        }
    }
}
