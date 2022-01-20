namespace Strickland.Validators
{
    public class MinValidator<T> : IValidatorFunction<T> where T : IComparisonOperators<T, T>
    {
        public T Min { get; init; }
        public MinValidator(T min) => Min = min;
        public bool IsValid(T value) => value >= Min;
    }
}
