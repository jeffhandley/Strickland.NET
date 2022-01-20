namespace Strickland.Validators
{
    public class Max<T> : IValidator<T> where T : IComparisonOperators<T, T>
    {
        public T Limit { get; init; }
        public Max(T limit) => Limit = limit;
        public bool IsValid(T value) => value <= Limit;
    }
}
