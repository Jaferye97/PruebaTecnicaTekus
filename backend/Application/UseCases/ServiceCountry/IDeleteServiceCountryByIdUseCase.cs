namespace Application.UseCases.ServiceCountry
{
    public interface IDeleteServiceCountryByIdUseCase
    {
        Task ExecuteAsync(int id);
    }
}
