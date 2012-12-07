using System.Collections.Generic;
using System.Linq;
using Epic.Data.Database;
using Epic.Domain;
using Raven.Client;
using Raven.Client.Extensions;

namespace Epic.Biz.Shops
{
	public class ShopRepository
	{
		private readonly IDocumentStore _db;

		public List<Shop> Shops { get; set; }

		public ShopRepository(IDbProvider dbProvider)
		{
			_db = dbProvider.GetDataStore();
		}

		public Shop CreateShop(string name)
		{
			_db.DatabaseCommands.EnsureDatabaseExists(name);

			using (var session = _db.OpenSession())
			{
				var newShop = new Shop
				{
					Name = name
				};
				session.Store(newShop);
				session.SaveChanges();

				return newShop;
			}
		}

		public IEnumerable<Shop> GetShops()
		{
			using (var session = _db.OpenSession())
			{
				return session.Query<Shop>().Take(1000).ToList();
			}
		}
	}
}