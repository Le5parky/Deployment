using System.Linq.Expressions;
using System.Transactions;
using Deployment.DAL.Entities;
using Deployment.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using IsolationLevel = System.Data.IsolationLevel;

namespace Deployment.DAL.Repositories;

public class AbstractRepository<T> : IDisposable, IRepository<T> where T : BaseEntity
{
    private readonly DeploymentDbContext _context;

    public AbstractRepository(DeploymentDbContext context)
    {
        _context = context;
      
    }

    public T GetById(int id) => _context.Set<T>().Find(id);
    public IEnumerable<T> GetAll() => _context.Set<T>().ToArray();
    public Task<T[]> GetAllAsync() => _context.Set<T>().ToArrayAsync();
    public ValueTask<T> GetByIdAsync(int id) => _context.Set<T>().FindAsync(id);
    public IEnumerable<T> Find(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression);
    public void Add(T entity) => _context.Set<T>().Add(entity);
    public ValueTask<EntityEntry<T>> AddAsync(T entity) => _context.Set<T>().AddAsync(entity);
    public void AddRange(IEnumerable<T> entities) => _context.Set<T>().AddRange(entities);
    public Task AddRangeAsync(IEnumerable<T> entities) => _context.AddRangeAsync(entities);
    public void Remove(T entity) => _context.Set<T>().Remove(entity);
    public void RemoveRange(IEnumerable<T> entities) => _context.Set<T>().RemoveRange(entities);
    public int SaveChanges() => _context.SaveChanges();
    public Task<int> SaveChangesAsync(CancellationToken token) => _context.SaveChangesAsync(token);
    public void BeginTransaction() => _context.Database.BeginTransaction(IsolationLevel.ReadCommitted);
    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken token) 
        => _context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted, token);
    public void CommitTransaction() => _context.Database.CommitTransaction();
    public Task CommitTransactionAsync(CancellationToken token) => _context.Database.CommitTransactionAsync(token);
    public void RollbackTransaction()
    {
        if (_context.Database.CurrentTransaction == null)
            throw new TransactionException("There no active transaction");
        _context.Database.RollbackTransaction();
    }

    public Task RollbackTransactionAsync(CancellationToken token) => _context.Database.RollbackTransactionAsync(token);
    public void Dispose() => _context.Dispose();
}