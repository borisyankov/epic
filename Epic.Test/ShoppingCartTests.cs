using System.Linq;
using Epic.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epic.Test
{  
	[TestClass]
	public class ShoppingCartTest
	{
		[TestMethod]
		public void ShoppingCartCreatesSuccessfully()
		{
			var cart = new ShoppingCart();

			Assert.IsNotNull(cart);
		}

		[TestMethod]
		public void ShoppingCartCanAddProducts()
		{
			var cart = new ShoppingCart();

			cart.Add(new Product());

			Assert.AreEqual(1, cart.Items.Count);
		}

		[TestMethod]
		public void ShoppingCartCanClear()
		{
			var cart = new ShoppingCart();

			cart.Add(new Product());
			cart.Clear();

			Assert.AreEqual(0, cart.Items.Count);
		}

		[TestMethod]
		public void ShoppingCartAddingSameProductIncreasesQuantity()
		{
			var cart = new ShoppingCart();

			var product = new Product();

			cart.Add(product);
			cart.Add(product);

			var item = cart.Items.Single(x => x.Product == product);

			Assert.AreEqual(2, item.Quantity);
		}
	}
}
