using System.Linq;
using Epic.Biz.Shops;
using Epic.Data.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epic.Test.IntegrationTests
{
	[TestClass]
	public class AccountCreation
	{
		[TestMethod] [Ignore]
		public void CreateNewAccount()
		{
			var dbProvider = new InMemoryDbProvider();

			var shopManager = new ShopRepository(dbProvider);
			
			shopManager.CreateShop("First");

			var allShops = shopManager.GetShops();
			var ourNewShop = allShops.SingleOrDefault(x => x.Name == "First");

			Assert.IsNotNull(ourNewShop);
		}
	}
}
