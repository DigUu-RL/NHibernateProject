using NHibernateProject.Infra.DataStruct.Data.Contexts;
using NHibernateProject.Infra.DataStruct.Data.Entities;
using NHibernateProject.Infra.DataStruct.Repostirory.Helpers;
using NHibernateProject.Infra.DataStruct.Repostirory.Interfaces;

namespace NHibernateProject.Infra.DataStruct.Repostirory.Repositories;

public class ActorRepository : BaseRepository<Actor>, IActorRepository
{
	public ActorRepository(Context context) : base(context)
	{
	}

	public override async Task<Paginated<Actor>> GetAllAsync(int page, int quantity)
	{
		Paginated<Actor> data = await Paginated<Actor>.CreateInstanceAsync(Query, page, quantity);
		return data;
	}
}
