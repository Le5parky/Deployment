using Deployment.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Deployment.DAL.Repositories.Interface;

public interface IRepository<T> where T : BaseEntity
{
    T GetById(int id); 
    ValueTask<T> GetByIdAsync(int id);
    IEnumerable<T> GetAll();
    Task<T[]> GetAllAsync();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    void Add(T entity);
    ValueTask<EntityEntry<T>> AddAsync(T entity);
    void AddRange(IEnumerable<T> entities);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken token);
    void BeginTransaction();
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken token);
    void CommitTransaction();
    Task CommitTransactionAsync(CancellationToken token);
    void RollbackTransaction();
    Task RollbackTransactionAsync(CancellationToken token);


}
