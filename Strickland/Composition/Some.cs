namespace Strickland.Composition
{
    public class Some<T> : Strickland.IValidator<T>
    {
        private IEnumerable<Strickland.IValidator<T>> _validators;

        public Some(params Strickland.IValidator<T>[] validators)
        {
            _validators = validators;
        }

        public bool IsValid(T value)
        {
            foreach (var validator in _validators)
            {
                if (validator.IsValid(value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
