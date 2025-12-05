using Domain.Models.Service;

namespace Application.UseCases.Service
{
    public interface IUpdateServiceUseCase
    {
        Task<bool> ExecuteAsync(ServiceModel model);
    }
}
