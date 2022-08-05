namespace NHibernateProject.Application.DTOs;

public class ActorDTO
{
	public long ActorId { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public DateTime LastUpdate { get; set; }
}
