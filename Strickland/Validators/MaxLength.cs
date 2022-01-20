namespace Strickland.Validators
{
    public class MaxLength<E, T> : IValidator<E> where E : IEnumerable<T>
    {
        public int Limit { get; init; }
        public MaxLength(int limit) => Limit = limit;

        public bool IsValid(E value) => value.Count() <= Limit;
    }
}
