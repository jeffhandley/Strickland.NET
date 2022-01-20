using Strickland.Composition;

namespace Strickland.Validators
{
    public class Length<E, T> : Every<E> where E : IEnumerable<T>
    {
        public int MinLimit { get; init; }
        public int MaxLimit { get; init; }

        public Length(int minLimit, int maxLimit) : base(new MinLength<E, T>(minLimit), new MaxLength<E, T>(maxLimit))
        {
            MinLimit = minLimit;
            MaxLimit = maxLimit;
        }
    }
}
