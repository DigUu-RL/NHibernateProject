using AutoMapper;
using NHibernateProject.Application.DTOs;
using NHibernateProject.Application.Interfaces;
using NHibernateProject.Domain.Interfaces;
using NHibernateProject.Domain.Request;

namespace NHibernateProject.Application.Services;

public class ApplicationActorService : IApplicationActorService
{
	private readonly IDomainActorService actorService;
	private readonly IMapper mapper;

	public ApplicationActorService(IDomainActorService actorService, IMapper mapper)
	{
		this.actorService = actorService;
		this.mapper = mapper;
	}

	public async Task<ActorDTO> GetByIdAsync(long id)
	{
		ActorDTO data = mapper.Map<ActorDTO>(await actorService.GetById(id));
		return data;
	}

	public async Task<PaginatedDTO<ActorDTO>> GetAllAsync(int page, int quantity)
	{
		PaginatedDTO<ActorDTO> data = mapper.Map<PaginatedDTO<ActorDTO>>(await actorService.GetAllAsync(page, quantity));
		return data;
	}

	public async Task CreateAsync(ActorRequest request)
	{
		await actorService.CreateAsync(request);
	}

	public async Task UpdateAsync(ActorRequest request)
	{
		await actorService.UpdateAsync(request);
	}

	public async Task DeleteAsync(long id)
	{
		await actorService.DeleteAsync(id);
	}
}
