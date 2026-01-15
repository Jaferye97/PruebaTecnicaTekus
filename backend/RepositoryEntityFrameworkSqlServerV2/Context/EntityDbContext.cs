using Microsoft.EntityFrameworkCore;

namespace RepositoryEntityFrameworkSqlServerV2.Context;

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

