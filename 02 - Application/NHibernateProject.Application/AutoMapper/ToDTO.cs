using AutoMapper;
using NHibernateProject.Application.DTOs;
using NHibernateProject.Domain.Models;

namespace NHibernateProject.Application.AutoMapper;

public class ToDTO : Profile
{
	public ToDTO()
	{
		CreateMap(typeof(ActorModel), typeof(ActorDTO));

		#region PAGINATED'S

		CreateMap(typeof(PaginatedModel<ActorModel>), typeof(PaginatedDTO<ActorDTO>));

		#endregion
	}
}
