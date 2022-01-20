namespace Strickland
{
    public interface IValidator<T>
    {
        bool IsValid(T value);
    }
}
