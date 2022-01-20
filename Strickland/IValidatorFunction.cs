namespace Strickland
{
    public interface IValidatorFunction<T>
    {
        bool IsValid(T value);
    }

    public interface IValidator<T, P> : IValidatorFunction<T>
    {
        P Properties { get; init; }
    }
}
