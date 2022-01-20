namespace Strickland
{
    public interface IValidator<T>
    {
        bool IsValid(T value);
    }

    public interface IValidator<T, P> : IValidator<T>
    {
        P Properties { get; init; }
    }
}
