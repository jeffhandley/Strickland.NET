namespace Strickland.Validators
{
    public class Min : IValidator<int>
    {
        public int MinValue { get; init; }
        public Min(int minValue) => MinValue = minValue;
        public bool IsValid(int value) => value >= MinValue;

        public static Min<T> Of<T>(T minValue) where T : IComparisonOperators<T, T> => new(minValue);
    }

    public class Min<T> : IValidator<T> where T : IComparisonOperators<T, T>
    {
        public T MinValue { get; init; }
        public Min(T minValue) => MinValue = minValue;
        public bool IsValid(T value) => value >= MinValue;
    }
}
