namespace Application.UseCases.SupplierAttribute
{
    public interface IDeleteSupplierAttributeByIdUseCase
    {
        Task ExecuteAsync(int id);
    }
}
