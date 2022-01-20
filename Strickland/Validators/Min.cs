namespace Strickland.Validators
{
    public class Min<T> : IValidator<T> where T : IComparisonOperators<T, T>
    {
        public T Limit { get; init; }
        public Min(T limit) => Limit = limit;
        public bool IsValid(T value) => value >= Limit;
    }
}
