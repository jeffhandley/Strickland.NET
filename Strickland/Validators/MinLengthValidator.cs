namespace Strickland.Validators
{
    public class MinLengthValidator<E, T> : IValidatorFunction<E> where E : IEnumerable<T>
    {
        public int MinLength { get; init; }
        public MinLengthValidator(int minLength) => MinLength = minLength;
        public bool IsValid(E value) => value.Count() >= MinLength;
    }
}
