namespace Strickland.Validators
{
    public class Min<T> : IValidatorFunction<T> where T : IComparisonOperators<T, T>
    {
        private readonly T _minValue;
        public Min(T minValue) => _minValue = minValue;
        public bool IsValid(T value) => value >= _minValue;
    }

    public static class Min
    {
        public static Min<T> Of<T>(T minValue) where T : IComparisonOperators<T, T> => new(minValue);
    }
}