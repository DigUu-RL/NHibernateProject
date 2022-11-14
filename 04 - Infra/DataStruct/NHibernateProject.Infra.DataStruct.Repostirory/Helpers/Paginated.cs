using NHibernate.Linq;

namespace NHibernateProject.Infra.DataStruct.Repostirory.Helpers;

public class Paginated<T> : List<T>
{
	public int Page { get; }
	public int Pages { get; }
	public int Total { get; }

	private Paginated(List<T> items, int page, int total, int quantity)
	{
		AddRange(items);
		Page = page;
		Pages = (int) Math.Ceiling(total / (decimal) quantity);
		Total = total;
	}

	public static Paginated<T> CreateInstance(IEnumerable<T> source, int page, int quantity)
	{
		page = page == 0 ? 1 : page;
		quantity = quantity == 0 ? 10 : quantity;

		int total = source.Count();

		List<T> items = source
			.Skip((page - 1) * quantity)
			.Take(quantity)
			.ToList();

		return new Paginated<T>(items, page, total, quantity);
	}

	public static async Task<Paginated<T>> CreateInstanceAsync(IEnumerable<T> source, int page, int quantity)
	{
		page = page == 0 ? 1 : page;
		quantity = quantity == 0 ? 10 : quantity;

		IQueryable<T> query = source.AsQueryable();

		int total = await query.CountAsync();

		List<T> items = await query
			.Skip((page - 1) * quantity)
			.Take(quantity)
			.ToListAsync();

		return new Paginated<T>(items, page, total, quantity);
	}
}
