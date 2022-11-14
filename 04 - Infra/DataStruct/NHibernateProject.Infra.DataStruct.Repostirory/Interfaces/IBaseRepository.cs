using NHibernateProject.Infra.DataStruct.Repostirory.Helpers;

namespace NHibernateProject.Infra.DataStruct.Repostirory.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<Paginated<TEntity>> GetAllAsync(int page, int quantity);
    Task<TEntity?> GetByIdAsync(long id);
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}
