using System.Linq.Expressions;

namespace Education.Repositories;
public interface IGenericRepository<TEntity> where TEntity : class 
{
    TEntity? GetById (int id);
    IEnumerable<TEntity> GetAll();
    IQueryable<TEntity> Find(Expression<Func<TEntity,bool>> expression);
    ValueTask<TEntity> AddAsync(TEntity entity);
    ValueTask AddRange(IEnumerable<TEntity> entities);
    ValueTask<TEntity> Remove(TEntity entity);
    ValueTask RemoveRange(IEnumerable<TEntity> entities);
    ValueTask<TEntity> Update(TEntity entity);
}