namespace Strickland.Validators
{
    public class MaxValidator<T> : IValidatorFunction<T> where T : IComparisonOperators<T, T>
    {
        public T Max { get; init; }
        public MaxValidator(T max) => Max = max;
        public bool IsValid(T value) => value <= Max;
    }
}
