using Strickland.Composition;

namespace Strickland.Validators
{
    public class LengthValidator<E, T> : EveryValidator<E> where E : IEnumerable<T>
    {
        public int MinLength { get; init; }
        public int MaxLength { get; init; }

        public LengthValidator(int minLength, int maxLength) : base(new MinLengthValidator<E, T>(minLength), new MaxLengthValidator<E, T>(maxLength))
        {
            MinLength = minLength;
            MaxLength = maxLength;
        }
    }
}
