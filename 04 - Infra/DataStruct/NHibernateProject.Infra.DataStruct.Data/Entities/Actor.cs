namespace NHibernateProject.Infra.DataStruct.Data.Entities;

public class Actor
{
	public virtual long ActorId { get; set; }
	public virtual string? FirstName { get; set; }
	public virtual string? LastName { get; set; }
	public virtual DateTime LastUpdate { get; set; }
}
