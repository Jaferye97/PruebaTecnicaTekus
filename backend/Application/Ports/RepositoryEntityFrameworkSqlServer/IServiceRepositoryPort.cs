using Domain.Models.Service;

namespace Application.Ports.RepositoryEntityFrameworkSqlServer
{
    public interface IServiceRepositoryPort
    {
        Task<bool> AddAsync(ServiceWithCountryModel model);
    }
}
