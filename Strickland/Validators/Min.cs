namespace Strickland.Validators
{
    public class Min<T, ValidationContext> : Validator<T, ValidationContext> where T : IComparisonOperators<T, T>
    {
        private Func<ValidationContext?, T> _getMinValue;

        public Min(Func<ValidationContext?, T> getMinValue) => _getMinValue = getMinValue;
        public Min(Func<T> getMinValue) : this((context) => getMinValue()) { }
        public Min(T minValue) : this((context) => minValue) { }

        public override bool Validate(T value, ValidationContext? context = default) => (value >= _getMinValue(context));
    }

    public static class Min
    {
        public static Min<T, object?> Of<T>(T minValue) where T : IComparisonOperators<T, T>
            => new(minValue);

        public static Min<T, object?> Of<T>(Func<T> getMinValue) where T : IComparisonOperators<T, T>
            => new(getMinValue);

        public static Min<T, ValidationContext> Of<T, ValidationContext>(Func<ValidationContext?, T> getMinValue) where T : IComparisonOperators<T, T>
            => new(getMinValue);
    }
}
