using AutoMapper;
using NHibernateProject.Domain.Interfaces;
using NHibernateProject.Domain.Models;
using NHibernateProject.Domain.Request;
using NHibernateProject.Infra.DataStruct.Data.Entities;
using NHibernateProject.Infra.DataStruct.Repostirory.Helpers;
using NHibernateProject.Infra.DataStruct.Repostirory.Interfaces;
using NHibernateProject.Infra.Middleware.Exceptions;
using System.Net;

namespace NHibernateProject.Domain.Services;

public class DomainActorService : IDomainActorService
{
	private readonly IActorRepository actorRepository;
	private readonly IMapper mapper;

	public DomainActorService(IActorRepository actorRepository, IMapper mapper)
	{
		this.actorRepository = actorRepository;
		this.mapper = mapper;
	}

	public async Task<ActorModel> GetById(long id)
	{
		Actor? data = await actorRepository.GetByIdAsync(id);

		if (data is null)
			throw new GlobalException("Data not found!", HttpStatusCode.NotFound);

		ActorModel model = mapper.Map<ActorModel>(data);
		return model;
	}

	public async Task<PaginatedModel<ActorModel>> GetAllAsync(int page, int quantity)
	{
		Paginated<Actor> data = await actorRepository.GetAllAsync(page, quantity);

		var model = new PaginatedModel<ActorModel>
		{
			Page = data.Page,
			Pages = data.Pages,
			Total = data.Total,
			Data = mapper.Map<List<ActorModel>>(data)
		};

		return model;
	}

	public async Task CreateAsync(ActorRequest request)
	{
		var actor = new Actor
		{
			FirstName = request.FirstName ?? throw new GlobalException("First name is mandatory!", HttpStatusCode.BadRequest),
			LastName = request.LastName ?? throw new GlobalException("Last name is mandatory!", HttpStatusCode.BadRequest),
			LastUpdate = DateTime.Now
		};

		await actorRepository.CreateAsync(actor);
	}

	public async Task UpdateAsync(ActorRequest request)
	{
		Actor? data = await actorRepository.GetByIdAsync(request.ActorId);

		if (data is null)
			throw new GlobalException("Data not found!", HttpStatusCode.NotFound);

		data.FirstName = request.FirstName ?? throw new GlobalException("First name is mandatory!", HttpStatusCode.BadRequest);
		data.LastName = request.LastName ?? throw new GlobalException("Last name is mandatory!", HttpStatusCode.BadRequest);
		data.LastUpdate = DateTime.Now;

		await actorRepository.UpdateAsync(data);
	}

	public async Task DeleteAsync(long id)
	{
		Actor? data = await actorRepository.GetByIdAsync(id);

		if (data is null)
			throw new GlobalException("Data not found!", HttpStatusCode.NotFound);

		await actorRepository.DeleteAsync(data);
	}
}
