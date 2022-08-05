using FluentNHibernate.Mapping;
using NHibernateProject.Infra.DataStruct.Data.Entities;

namespace NHibernateProject.Infra.DataStruct.Data.Mappings;

public class ActorMap : ClassMap<Actor>
{
	public ActorMap()
	{
		DynamicUpdate();
		Table(nameof(Actor).ToLower());
		Id(x => x.ActorId).Column("actor_id");
		Map(x => x.FirstName).Column("first_name");
		Map(x => x.LastName).Column("last_name");
		Map(x => x.LastUpdate).Column("last_update");
	}
}
