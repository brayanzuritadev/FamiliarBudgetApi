namespace FamiliarBudgetApi.Services.Validation
{
    public interface IValidator<T> where T : class
    {
        public bool Validate(T validatonObject);
    }
}
