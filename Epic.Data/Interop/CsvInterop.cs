using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Epic.Data.Database;
using Epic.Domain;
using Raven.Client;

namespace Epic.Data.Interop
{
	public sealed class ProductMap : CsvClassMap<Product>
	{
		public ProductMap()
		{
			Map(m => m.Title).Name("Title");
			Map(m => m.Description).Name("Description");
			Map(m => m.Price).Name("Price");
			Map(m => m.SKU).Name("SKU");
			Map(m => m.Weight).Name("Weight");
			Map(m => m.Vendor).Name("Vendor");
		}
	}

	public class CsvInterop
	{
		private const int RECORDS_PER_READ = 1000;
		private readonly IDocumentStore _db;

		public CsvInterop(IDbProvider dbProvider)
		{
			_db = dbProvider.GetDataStore();
		}

		public void ReadFromCsv(string fileName)
		{
			var csv = new CsvReader(new StreamReader(fileName));
			csv.Configuration.ClassMapping<ProductMap, Product>();
			using (var session = _db.OpenSession())
			{
				session.Advanced.MaxNumberOfRequestsPerSession = 1000;

				int cachedProductCount = 0;
				while (csv.Read())
				{
					var product = csv.GetRecord<Product>();
					session.Store(product);
					cachedProductCount++;

					if (cachedProductCount > RECORDS_PER_READ)
					{
						session.SaveChanges();
						cachedProductCount = 0;
					}
				}

				session.SaveChanges();
			}
		}

		public void WriteToCsv(string fileName)
		{
			var csv = new CsvWriter(new StreamWriter(fileName));

			using (var session = _db.OpenSession())
			{
				var products = session.Query<Product>();

				foreach (var product in products)
				{
					csv.WriteRecord(product);
				}
			}
		}
	}
}
