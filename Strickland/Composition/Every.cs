namespace Strickland.Composition
{
    public class All<T> : Strickland.IValidator<T>
    {
        private IEnumerable<Strickland.IValidator<T>> _validators;

        public All(params Strickland.IValidator<T>[] validators)
        {
            _validators = validators;
        }

        public bool IsValid(T value)
        {
            var isValid = true;

            foreach (var validator in _validators)
            {
                if (!validator.IsValid(value))
                {
                    isValid = false;
                }
            }
            return isValid;
        }
    }
}
