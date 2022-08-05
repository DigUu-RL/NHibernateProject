using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cache;
using System.Reflection;

namespace NHibernateProject.Infra.DataStruct.Data.Contexts;

public class Context
{
	public ISession Session { get; }

	public Context(string connectionString)
	{
		ISessionFactory sessionFactory = Fluently
			.Configure()
			.Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
			.Cache(x => x.UseQueryCache().UseSecondLevelCache().ProviderClass<HashtableCacheProvider>())
			.Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
			.BuildSessionFactory();

		Session = sessionFactory.OpenSession();
		sessionFactory.CloseAsync().Wait();
	}
}
