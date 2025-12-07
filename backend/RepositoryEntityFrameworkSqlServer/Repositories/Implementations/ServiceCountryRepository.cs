using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Service;
using RepositoryEntityFrameworkSqlServer.Context;
using RepositoryEntityFrameworkSqlServer.Entities;
using RepositoryEntityFrameworkSqlServer.Mappers;

namespace RepositoryEntityFrameworkSqlServer.Repositories.Implementations
{
    public class ServiceCountryRepository : BaseRepository<ServiceCountryEntity, ServiceCountryModel, int>, IServiceCountryRepository, IServiceCountryRepositoryPort
    {
        private readonly ICountryRepository _countryRepository;

        public ServiceCountryRepository(
            EntityDbContext context,
            ICountryRepository countryRepository
        ) : base(context, entity => entity.ToDomain(), entity => entity.ToEntity())
        {
            _countryRepository = countryRepository;
        }

        public async Task<bool> ExistRecordAsync(int id) => await base.CountAsync(x => x.Id == id) > 0;

        public async Task<bool> AddAsync(int serviceId, List<ServiceCountryDetailModel> models)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var countryList = models.Select(x =>
                                            new CountryEntity()
                                            {
                                                Name = x.Name,
                                                Code = x.Code,
                                            }
                                        ).ToList();

                var codeCountryList = models.Select(x => x.Code).ToList();

                var countryExisting = await base.CountAsync(x => x.ServiceId == serviceId && codeCountryList.Contains(x.Country.Code));

                if (countryExisting > 0)
                    return false;

                var entityCountryList = await _countryRepository.AddAsync(countryList);

                var newServiceCountryList = entityCountryList
                                                .Select(x =>
                                                    new ServiceCountryModel()
                                                    {
                                                        CountryId = x.Id,
                                                        ServiceId = serviceId,
                                                    }
                                                ).ToList();

                var entityServiceCountryList = await base.AddAsync(newServiceCountryList);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}
