using Microsoft.Extensions.Configuration;
using NHibernateProject.Infra.DataStruct.Data.Contexts;
using NHibernateProject.Infra.DataStruct.Data.Entities;
using NHibernateProject.Infra.DataStruct.Repostirory.Helpers;
using NHibernateProject.Infra.DataStruct.Repostirory.Interfaces;

namespace NHibernateProject.Infra.DataStruct.Repostirory.Repositories;

public class ActorRepository : IActorRepository
{
	private readonly Context context;

	public ActorRepository(IConfiguration configuration)
	{
		context = new Context(configuration.GetConnectionString("Sakila"));
	}

	public async Task<Actor?> GetByIdAsync(long id)
	{
		Actor? data = await context.Session.GetAsync<Actor>(id);
		return data;
	}

	public async Task<Paginated<Actor>> GetAllAsync(int page, int quantity)
	{
		IQueryable<Actor> query = context.Session.Query<Actor>();

		Paginated<Actor> data = await Paginated<Actor>.CreateAsync(query, page, quantity);
		return data;
	}

	public async Task CreateAsync(Actor actor)
	{
		await context.Session.SaveAsync(actor);
	}

	public async Task UpdateAsync(Actor actor)
	{
		await context.Session.UpdateAsync(actor);
	}

	public async Task DeleteAsync(Actor actor)
	{
		await context.Session.DeleteAsync(actor);
	}
}
