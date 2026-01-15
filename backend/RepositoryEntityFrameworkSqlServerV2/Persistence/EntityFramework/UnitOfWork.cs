using Application.Ports.Persistence;
using Microsoft.EntityFrameworkCore.Storage;
using RepositoryEntityFrameworkSqlServer.Context;

namespace RepositoryEntityFrameworkSqlServerV2.Persistence.EntityFramework;

public class UnitOfWork(EntityDbContext context) : IUnitOfWork
{
    private readonly EntityDbContext _context = context;
    private IDbContextTransaction? _transaction;

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task CommitAsync()
    {
        if (_transaction is not null)
            await _transaction.CommitAsync();
    }

    public async Task RollbackAsync()
    {
        if (_transaction is not null)
            await _transaction.RollbackAsync();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
    }
}

