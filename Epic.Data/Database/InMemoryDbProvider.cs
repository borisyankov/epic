using Raven.Client;
using Raven.Client.Embedded;

namespace Epic.Data.Database
{
	public class InMemoryDbProvider : IDbProvider
	{
		private EmbeddableDocumentStore _dataStore;

		public IDocumentStore GetDataStore()
		{
			if (_dataStore != null)
			{
				return _dataStore;
			}

			_dataStore = new EmbeddableDocumentStore
			{
				RunInMemory = true
			};
			_dataStore.Initialize();

			return _dataStore;
		}
	}
}