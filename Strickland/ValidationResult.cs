namespace Strickland
{
    public class ValidationResult<T>
    {
        public T Value { get; }
        public bool IsValid { get; }

        public ValidationResult(T value, bool isValid)
        {
            Value = value;
            IsValid = isValid;
        }
    }

    public class ValidationResult<T, P> : ValidationResult<T>
    {
        public P Properties { get; }

        public ValidationResult(ValidationResult<T> result, P properties) : this(result.Value, result.IsValid, properties) { }

        public ValidationResult(T value, bool isValid, P properties) : base(value, isValid)
            => Properties = properties;
    }
}
