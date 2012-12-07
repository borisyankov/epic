using Raven.Client;

namespace Epic.Data.Database
{
	public interface IDbProvider
	{
		IDocumentStore GetDataStore();
	}
}