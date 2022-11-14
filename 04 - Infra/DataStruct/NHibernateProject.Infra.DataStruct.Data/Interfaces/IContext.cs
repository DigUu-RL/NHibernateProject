using NHibernate;

namespace NHibernateProject.Infra.DataStruct.Data.Interfaces;

public interface IContext
{
	public ISession Session { get; }
}
