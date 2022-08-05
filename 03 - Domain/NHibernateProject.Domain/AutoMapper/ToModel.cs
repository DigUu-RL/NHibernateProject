using AutoMapper;
using NHibernateProject.Domain.Models;
using NHibernateProject.Infra.DataStruct.Data.Entities;

namespace NHibernateProject.Domain.AutoMapper;

public class ToModel : Profile
{
	public ToModel()
	{
		CreateMap(typeof(Actor), typeof(ActorModel));
	}
}
