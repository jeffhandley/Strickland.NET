namespace Strickland.Validators
{
    public class MaxLengthValidator<E, T> : IValidatorFunction<E> where E : IEnumerable<T>
    {
        public int MaxLength { get; init; }
        public MaxLengthValidator(int maxLength) => MaxLength = maxLength;

        public bool IsValid(E value) => value.Count() <= MaxLength;
    }
}
