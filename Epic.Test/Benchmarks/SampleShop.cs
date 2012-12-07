using System;
using System.Diagnostics;
using Epic.Biz.Shops;
using Epic.Data.Database;
using Epic.Data.Repositories;
using Epic.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epic.Test.Benchmarks
{
	[TestClass]
	public class SampleShop
	{		
		public static void Create()
		{
			var dbProvider = new PersistentDbProvider(new ServerConfiguration {DatabaseAddress = "http://localhost:8080/"});
			new ShopRepository(dbProvider).CreateShop("Sample");
			var productRepository = new ProductRepository(dbProvider);

			for (int i = 0; i < 1000; i++)
				productRepository.Create(GetRandomProduct());
		}

		private static Product GetRandomProduct()
		{
			return new Product
			{
			    Title = TestHelpers.RandomCapitalizedString(5, 15),
				Price = TestHelpers.RandomPrice()
			};
		}

		[Ignore][TestMethod]
		public void CreateThousandProductsNotSlow()
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			Create();
			
			Assert.IsTrue(stopwatch.ElapsedTicks < new TimeSpan(0, 0, 10).Ticks);
		}
	}
}
