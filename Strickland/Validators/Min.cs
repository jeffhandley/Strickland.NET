namespace Strickland.Validators
{
    public class Min<T> : IValidator<T> where T : IComparisonOperators<T, T>
    {
        public T MinValue { get; init; }
        public Min(T minValue) => MinValue = minValue;
        public bool IsValid(T value) => value >= MinValue;
    }
}
