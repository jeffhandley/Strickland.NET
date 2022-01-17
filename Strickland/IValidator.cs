namespace Strickland
{
    public interface IValidatorFunction<T>
    {
        bool IsValid(T value);
    }

    public interface IValidator<T>
    {
        ValidationResult<T> Validate(T value);
    }

    public interface IValidator<T, P>
    {
        ValidationResult<T, P> Validate(T value);
    }

    public interface IValidatorFunctionFactory<V, T> where V : IValidatorFunction<T>
    {
        V GetValidator();
    }

    public interface IValidatorFactory<V, T> where V : IValidator<T>
    {
        V GetValidator();
    }

    public interface IValidatorFactory<C, V, T> where V : IValidatorFunction<T>
    {
        V GetValidator(C context);
    }
}
