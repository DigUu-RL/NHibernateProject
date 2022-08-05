using NHibernateProject.Infra.DataStruct.Data.Entities;
using NHibernateProject.Infra.DataStruct.Repostirory.Helpers;

namespace NHibernateProject.Infra.DataStruct.Repostirory.Interfaces;

public interface IActorRepository
{
	Task<Actor?> GetByIdAsync(long id);
	Task<Paginated<Actor>> GetAllAsync(int page, int quantity);
	Task CreateAsync(Actor actor);
	Task UpdateAsync(Actor actor);
	Task DeleteAsync(Actor actor);
}
