using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace TeduMicroservices.IDP.Infrastructure.Domains;

public interface IRepositoryBase<T, TK> where T : EntityBase<TK>
{
    #region Query

    IQueryable<T> FindAll(bool trackChanges = false);
    IQueryable<T> FindAll(bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false);

    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false,
        params Expression<Func<T, object>>[] includeProperties);

    Task<T?> GetByIdAsync(TK id);
    Task<T?> GetByIdAsync(TK id, params Expression<Func<T, object>>[] includeProperties);

    #endregion

    #region Action

    Task<TK> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task UpdateListAsync(IEnumerable<T> entities);
    Task DeleteAsync(T entity);
    Task DeleteListAsync(IEnumerable<T> entities);

    #endregion

    Task<int> SaveChangesAsync();
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task EndTransactionAsync();
    Task RollbackTransactionAsync();
}