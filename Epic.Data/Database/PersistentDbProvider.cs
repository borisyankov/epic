using Epic.Biz.Shops;
using Raven.Client;
using Raven.Client.Document;

namespace Epic.Data.Database
{
	public class PersistentDbProvider : IDbProvider
	{
		private readonly ServerConfiguration _serverConfiguration;

		public PersistentDbProvider(ServerConfiguration serverConfiguration)
		{
			_serverConfiguration = serverConfiguration;
		}

		public IDocumentStore GetDataStore()
		{
			return new DocumentStore
			{
			    Url = _serverConfiguration.DatabaseAddress
			}.Initialize();
		}
	}
}