using Microsoft.Extensions.DependencyInjection;
using NHibernateProject.Application.Interfaces;
using NHibernateProject.Application.Services;
using NHibernateProject.Domain.Interfaces;
using NHibernateProject.Domain.Services;
using NHibernateProject.Infra.DataStruct.Repostirory.Interfaces;
using NHibernateProject.Infra.DataStruct.Repostirory.Repositories;

namespace NHibernateProject.Infra.CrossCutting.CCT;

public static class ConfigureServiceCollections
{
	public static IServiceCollection ApplyServiceCollection(this IServiceCollection services)
	{
		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		services.AddScoped(typeof(IApplicationActorService), typeof(ApplicationActorService));
		services.AddScoped(typeof(IDomainActorService), typeof(DomainActorService));
		services.AddScoped(typeof(IActorRepository), typeof(ActorRepository));

		return services;
	}
}
