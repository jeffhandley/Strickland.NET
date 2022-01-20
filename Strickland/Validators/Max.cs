namespace Strickland.Validators
{
    public class Max<T> : IValidator<T> where T : IComparisonOperators<T, T>
    {
        public T MaxValue { get; init; }
        public Max(T maxValue) => MaxValue = maxValue;
        public bool IsValid(T value) => value <= MaxValue;
    }
}
