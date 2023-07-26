using System.Data;
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
    
    #region Dapper

    Task<IReadOnlyList<TModel>> QueryAsync<TModel>(string sql, object? param, 
        CommandType? commandType, IDbTransaction? transaction, int? commandTimeout) where TModel : EntityBase<TK>;

    Task<TModel> QueryFirstOrDefaultAsync<TModel>(string sql, object? param, 
        CommandType? commandType, IDbTransaction? transaction, int? commandTimeout) where TModel : EntityBase<TK>;

    Task<TModel> QuerySingleAsync<TModel>(string sql, object? param, 
        CommandType? commandType, IDbTransaction? transaction, int? commandTimeout) where TModel : EntityBase<TK>;

    Task<int> ExecuteAsync(string sql, object? param, 
        CommandType? commandType, IDbTransaction? transaction, int? commandTimeout);

    #endregion Dapper

    Task<int> SaveChangesAsync();
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task EndTransactionAsync();
    Task RollbackTransactionAsync();
}