using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Cache;
using NHibernateProject.Infra.DataStruct.Data.Interfaces;
using System.Reflection;

namespace NHibernateProject.Infra.DataStruct.Data.Contexts;

public class Context : IContext, IDisposable
{
	public ISession Session { get; }

	public Context(IConfiguration configuration)
	{
		ISessionFactory sessionFactory = Fluently
			.Configure()
			.Database(MySQLConfiguration.Standard.ConnectionString(configuration.GetConnectionString("Sakila")))
			.Cache(x => x.UseQueryCache().UseSecondLevelCache().ProviderClass<HashtableCacheProvider>())
			.Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
			.BuildSessionFactory();

		Session = sessionFactory.OpenSession();

		sessionFactory.CloseAsync().Wait();
		sessionFactory.Dispose();
	}

	// disponse pattern
	private bool _disposed;

    public void Dispose()
    {
        Dispose(true);
		GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
            Session.Dispose();

        _disposed = true;
    }
}
