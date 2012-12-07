using System.Collections.Generic;
using Epic.Data.Database;
using Epic.Domain;
using Raven.Client;
using Raven.Client.Linq;

namespace Epic.Data.Repositories
{
	public class ProductRepository
	{
		private readonly IDocumentStore _db;

		public ProductRepository(IDbProvider dbProvider)
		{
			_db = dbProvider.GetDataStore();
		}

		public void Create(Product product)
		{
			using (var session = _db.OpenSession())
			{
				session.Store(product, product.Title);
				session.SaveChanges();
			}
		}

		public void Update(Product product)
		{
			Create(product);
		}

		public IEnumerable<Product> GetProducts()
		{
			using (var session = _db.OpenSession())
			{
				return session.Query<Product>();				
			}
		}

		public IEnumerable<Product> GetProductsInCollection(string collection)
		{
			using (var session = _db.OpenSession())
			{
				return session.Query<Product>()
					.Where(x => x.Collection == collection);
			}
		}

		public void Delete(string id)
		{
			using (var session = _db.OpenSession())
			{
				var product = session.Load<Product>(id);
				session.Delete(product);
				session.SaveChanges();
			}
		}

		public Product GetProductByTitle(string title)
		{
			using (var session = _db.OpenSession())
			{
				return session.Load<Product>(title);
			}
		}
	}
}
