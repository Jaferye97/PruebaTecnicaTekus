using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Commons;
using Domain.Models.Service;
using Microsoft.EntityFrameworkCore;
using RepositoryEntityFrameworkSqlServer.Context;
using RepositoryEntityFrameworkSqlServer.Entities;
using RepositoryEntityFrameworkSqlServer.Mappers;

namespace RepositoryEntityFrameworkSqlServer.Repositories.Implementations
{
    public class ServiceRepository : BaseRepository<ServiceEntity, ServiceModel, int>, IServiceRepositoryPort
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IServiceCountryRepository _serviceCountryRepository;

        public ServiceRepository(
            EntityDbContext context,
            ICountryRepository countryRepository,
            IServiceCountryRepository serviceCountryRepository
        ) : base(context, entity => entity.ToDomain(), entity => entity.ToEntity())
        {
            _countryRepository = countryRepository;
            _serviceCountryRepository = serviceCountryRepository;
        }

        public async Task<bool> AddAsync(ServiceWithCountryModel model)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var serviceEntity = ServiceMapper.ToDomain(await base.AddAsync(model));

                var countryList = model.ServiceCountry
                                        .Select(x =>
                                            new CountryEntity()
                                            {
                                                Name = x.Name,
                                                Code = x.Code,
                                            }
                                        ).ToList();

                var entityCountryList = await _countryRepository.AddAsync(countryList);

                var newServiceCountryList = entityCountryList
                                                .Select(x =>
                                                    new ServiceCountryModel()
                                                    {
                                                        CountryId = x.Id,
                                                        ServiceId = serviceEntity.Id,
                                                    }
                                                ).ToList();

                var entityServiceCountryList = await _serviceCountryRepository.AddAsync(newServiceCountryList);

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

        public async Task<bool> ExistRecordAsync(int id) => await base.CountAsync(x => x.Id == id) > 0;

        public async Task<ServiceWithCountryModel> GetAsync(int id)
        {
            IQueryable<ServiceEntity> query = _dbSet;

            query = query.Include(x => x.ServiceCountry).ThenInclude(x => x.Country);
            query = query.Where(x => x.Id == id);

            var resultQuery = await query.ToListAsync().ConfigureAwait(false);

            var result = resultQuery.Select(ServiceWithCountryMapper.ToDomain).ToList();

            return result.FirstOrDefault();
        }

        public async Task<ServiceModel> UpdateAsync(ServiceModel model) => ServiceMapper.ToDomain(await base.UpdateAsync(model));

        public async Task<PagedResult<ServiceWithCountryModel>> GetAllAsync(ServiceFilterModel filter)
        {
            IQueryable<ServiceEntity> query = _dbSet;

            query = query.Where(t => t.SupplierId == filter.SupplierId);

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(t => t.Name.Contains(filter.Name));

            if (filter.MinHourlyRate > 0)
                query = query.Where(t => t.HourlyRate >= filter.MinHourlyRate);

            if (filter.MaxHourlyRate > 0)
                query = query.Where(t => t.HourlyRate <= filter.MinHourlyRate);

            var totalItems = await query.CountAsync();

            query = query.Include(x => x.ServiceCountry).ThenInclude(x => x.Country);

            filter.Page = filter.Page <= 0 ? 1 : filter.Page;
            filter.PageSize = filter.PageSize <= 0 ? 10 : filter.PageSize;

            var entities = await query
                .OrderByDescending(t => t.Name)
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResult<ServiceWithCountryModel>
            {
                Items = entities.Select(ServiceWithCountryMapper.ToDomain).ToList(),
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / filter.PageSize),
                CurrentPage = filter.Page
            };
        }
    }
}
