using NHibernate;
using NHibernateProject.Infra.DataStruct.Data.Contexts;
using NHibernateProject.Infra.DataStruct.Data.Interfaces;
using NHibernateProject.Infra.DataStruct.Repostirory.Helpers;
using NHibernateProject.Infra.DataStruct.Repostirory.Interfaces;

namespace NHibernateProject.Infra.DataStruct.Repostirory.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly IContext _context;

    protected BaseRepository(Context context)
    {
        _context = context;
    }

    protected ISession Session => _context.Session;
    protected IQueryable<TEntity> Query => _context.Session.Query<TEntity>();

    public abstract Task<Paginated<TEntity>> GetAllAsync(int page, int quantity);

    public virtual async Task<TEntity?> GetByIdAsync(long id)
    {
        TEntity? entity = await _context.Session.GetAsync(typeof(TEntity), id) as TEntity;
        return entity;
    }

    public virtual async Task CreateAsync(TEntity entity)
    {
        await _context.Session.SaveAsync(entity);
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        await _context.Session.UpdateAsync(entity);
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        await _context.Session.DeleteAsync(entity);
    }
}
