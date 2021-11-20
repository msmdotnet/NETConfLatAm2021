namespace NorthWind.Entities.Validators
{
    public interface IValidatorService<T>
    {
        void Validate(T instance, IEnumerable<IValidator<T>> validators,
            IApplicationStatusLogger logger);
    }
}
