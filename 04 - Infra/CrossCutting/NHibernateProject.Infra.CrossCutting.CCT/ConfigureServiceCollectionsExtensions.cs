using Microsoft.Extensions.DependencyInjection;
using NHibernateProject.Application.Interfaces;
using NHibernateProject.Application.Services;
using NHibernateProject.Domain.Interfaces;
using NHibernateProject.Domain.Services;
using NHibernateProject.Infra.DataStruct.Data.Contexts;
using NHibernateProject.Infra.DataStruct.Data.Interfaces;
using NHibernateProject.Infra.DataStruct.Repostirory.Interfaces;
using NHibernateProject.Infra.DataStruct.Repostirory.Repositories;

namespace NHibernateProject.Infra.CrossCutting.CCT;

public static class ConfigureServiceCollectionsExtensions
{
	public static IServiceCollection ConfigureServiceCollection(this IServiceCollection services)
	{
		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		services.AddScoped(typeof(IContext), typeof(Context));

		services.AddScoped(typeof(IApplicationActorService), typeof(ApplicationActorService));
		services.AddScoped(typeof(IDomainActorService), typeof(DomainActorService));
		services.AddScoped(typeof(IActorRepository), typeof(ActorRepository));

		return services;
	}
}
