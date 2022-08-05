using NHibernateProject.Application.DTOs;
using NHibernateProject.Domain.Request;

namespace NHibernateProject.Application.Interfaces;

public interface IApplicationActorService
{
	Task<ActorDTO> GetByIdAsync(long id);
	Task<PaginatedDTO<ActorDTO>> GetAllAsync(int page, int quantity);
	Task CreateAsync(ActorRequest request);
	Task UpdateAsync(ActorRequest request);
	Task DeleteAsync(long id);
}
