using Microsoft.EntityFrameworkCore;
using RepositoryEntityFrameworkSqlServer.Entities;

namespace RepositoryEntityFrameworkSqlServer.Context
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext()
        {
        }

        public EntityDbContext(DbContextOptions<EntityDbContext> options)
        : base(options)
        { }

        public DbSet<SupplierEntity> Supplier { get; set; }
        public DbSet<SupplierAttributeEntity> SupplierAttribute { get; set; }
    }
}
