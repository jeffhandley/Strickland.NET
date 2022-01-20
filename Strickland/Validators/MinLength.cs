namespace Strickland.Validators
{
    public class MinLength<E, T> : IValidator<E> where E : IEnumerable<T>
    {
        public int Limit { get; init; }
        public MinLength(int limit) => Limit = limit;

        public bool IsValid(E value) => value.Count() >= Limit;
    }
}
