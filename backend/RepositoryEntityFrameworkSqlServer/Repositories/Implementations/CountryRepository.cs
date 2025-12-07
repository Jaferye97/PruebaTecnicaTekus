using Domain.Models.Country;
using RepositoryEntityFrameworkSqlServer.Context;
using RepositoryEntityFrameworkSqlServer.Entities;
using RepositoryEntityFrameworkSqlServer.Mappers;

namespace RepositoryEntityFrameworkSqlServer.Repositories.Implementations
{
    public class CountryRepository : BaseRepository<CountryEntity, CountryModel, int>, ICountryRepository
    {
        public CountryRepository(EntityDbContext context) : base(context, entity => entity.ToDomain(), entity => entity.ToEntity())
        {
        }

        public async Task<List<CountryEntity>> AddAsync(List<CountryEntity> entities)
        {
            var result = new List<CountryEntity>();

            foreach (var entity in entities)
            {
                var existing = await base.CountAsync(x => x.Code == entity.Code) > 0;

                if (existing)
                {
                    var entityExisting = await GetAsync(x => x.Code == entity.Code);
                    result.Add(CountryMapper.ToEntity(entityExisting.FirstOrDefault()));
                }
                else
                {
                    var newCountry = new CountryEntity
                    {
                        Name = entity.Name,
                        Code = entity.Code
                    };

                    newCountry = await base.AddAsync(CountryMapper.ToDomain(newCountry));

                    result.Add(newCountry);
                }
            }

            return result;
        }
    }
}
