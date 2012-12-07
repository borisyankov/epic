using Epic.Biz.Shops;
using Epic.Data.Database;
using Epic.Data.Repositories;
using Epic.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epic.Test.IntegrationTests
{
	[TestClass]
	public class ProductOperations
	{
		[TestMethod] [Ignore]
		public void CanCreateProducts()
		{
			var dbProvider = new InMemoryDbProvider();

			var shopManager = new ShopRepository(dbProvider);
			shopManager.CreateShop("Test");

			var productRepo = new ProductRepository(dbProvider);
			productRepo.Create(new Product
			{
			    Title = "First product"
			});

			var product = productRepo.GetProductByTitle("First product");

			Assert.IsNotNull(product);
			Assert.AreEqual("First product", product.Title);
		}
	}
}
