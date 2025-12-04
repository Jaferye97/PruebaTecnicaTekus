using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Supplier;
using RepositoryEntityFrameworkSqlServer.Context;
using RepositoryEntityFrameworkSqlServer.Entities;
using RepositoryEntityFrameworkSqlServer.Mappers;

namespace RepositoryEntityFrameworkSqlServer.Repositories.Implementations
{
    public class SupplierRepository : BaseRepository<SupplierEntity, SupplierModel, int>, ISupplierRepositoryPort
    {
        private readonly ISupplierAttributeRepository _supplierAttributeRepository;

        public SupplierRepository(
            EntityDbContext context,
            ISupplierAttributeRepository supplierAttributeRepository
        ) : base(context, entity => entity.ToDomain(), entity => entity.ToEntity())
        {
            _supplierAttributeRepository = supplierAttributeRepository;
        }

        public async Task<bool> ExistRecordAsync(int id) => await base.CountAsync(x => x.Id == id) > 0;

        public async Task<SupplierModel> AddAsync(SupplierModel model) => SupplierMapper.ToDomain(await base.AddAsync(model));

        public async Task<SupplierModel> GetAsync(int id)
        {
            var model = await base.GetUniqueAsync(
                filter: s => s.Id == id,
                includes: s => s.SupplierAttribute
            );

            return model;
        }

        public async Task<bool> UpdateAsync(SupplierModel model)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var oldsRecords = model.SupplierAttribute?
                                        .Where(item => item.Id != 0)
                                        .ToList();
                var newsRecords = model.SupplierAttribute?
                                        .Where(item => item.Id == 0)
                                        .Select(x =>
                                        {
                                            x.SupplierId = model.Id;
                                            return x;
                                        })
                                        .ToList();
                model.SupplierAttribute = null;

                await base.UpdateAsync(model);

                if (newsRecords.Count > 0)
                {
                    await _supplierAttributeRepository.AddAsync(newsRecords);
                }

                if (oldsRecords.Count > 0)
                {
                    await _supplierAttributeRepository.UpdateAsync(oldsRecords);
                }

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
