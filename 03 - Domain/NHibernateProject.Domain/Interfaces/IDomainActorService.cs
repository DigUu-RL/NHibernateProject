using NHibernateProject.Domain.Models;
using NHibernateProject.Domain.Request;

namespace NHibernateProject.Domain.Interfaces;

public interface IDomainActorService
{
	Task<ActorModel> GetByIdAsync(long id);
	Task<PaginatedModel<ActorModel>> GetAllAsync(int page, int quantity);
	Task CreateAsync(ActorRequest request);
	Task UpdateAsync(ActorRequest request);
	Task DeleteAsync(long id);
}
