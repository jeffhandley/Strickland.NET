namespace Strickland.Validators
{
    public abstract class Validator<T>
    {
        public IDictionary<string, object?> Properties { get; protected init; }

        public Validator(IDictionary<string, object?>? properties)
        {
            Properties = properties ?? new Dictionary<string, object?>();
        }

        public virtual bool Validate(T value)
        {
            return Validate(value, (object?)null);
        }

        public abstract bool Validate<C>(T value, C context);
    }
}
