using Domain.Models.Service;

namespace Application.Ports.RepositoryEntityFrameworkSqlServer
{
    public interface IServiceCountryRepositoryPort
    {
        Task<ServiceCountryModel> GetAsync(int id);
        Task DeleteAsync(ServiceCountryModel model);
        Task<bool> ExistRecordAsync(int id);
    }
}
