namespace NHibernateProject.Application.DTOs;

public class PaginatedDTO<T>
{
	public int Page { get; set; }
	public int Pages { get; set; }
	public int Total { get; set; }
	public List<T>? Data { get; set; }
}
