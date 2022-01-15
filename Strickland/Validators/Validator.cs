namespace Strickland.Validators
{
    public abstract class Validator<T, ValidationContext>
    {
        public abstract bool Validate(T value, ValidationContext? context = default);
    }
}
