using Domain.Models.Commons;
using Domain.Models.Service;

namespace Application.Ports.RepositoryEntityFrameworkSqlServer
{
    public interface IServiceRepositoryPort
    {
        Task<bool> AddAsync(ServiceWithCountryModel model);
        Task<ServiceWithCountryModel> GetAsync(int id);
        Task<bool> ExistRecordAsync(int id);
        Task<ServiceModel> UpdateAsync(ServiceModel model);
        Task<PagedResult<ServiceWithCountryModel>> GetAllAsync(ServiceFilterModel filter);
    }
}
