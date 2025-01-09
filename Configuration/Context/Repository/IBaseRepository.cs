using System.Linq.Expressions;

namespace AttendanceEpiisBk.Configuration.Context.Repository;

public interface IBaseRepository
{
    Task<TEntity?> GetAsync<TEntity>(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null) where TEntity : class;

    Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
        where TEntity : class;

    Task AddAsync<TEntity>(TEntity entity) where TEntity : class;
    Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
    Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
}