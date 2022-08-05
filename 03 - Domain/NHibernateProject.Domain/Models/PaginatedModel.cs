namespace NHibernateProject.Domain.Models;

public class PaginatedModel<T>
{
	public int Page { get; set; }
	public int Pages { get; set; }
	public int Total { get; set; }
	public List<T>? Data { get; set; }
}
