using System.Collections.Generic;
using System.Linq;
using Epic.Domain.Interfaces;

namespace Epic.Domain
{
	public class ShoppingCart
	{
		private readonly IShippingCalculator _shippingCalculator;

		public ShoppingCart(IShippingCalculator shippingCalculator = null)
		{
			_shippingCalculator = shippingCalculator;

			Items = new List<CartItem>();
		}

		public List<CartItem> Items { get; set; }

		public decimal Subtotal
		{
			get
			{
				return Items.Sum(x => x.Price);
			}
		}

		public decimal Shipping
		{
			get { return _shippingCalculator.GetShippingPrice(null); }
		}


		public decimal Total
		{
			get { return Subtotal + Shipping; }
		}

		public bool IsEmpty
		{
			get { return !Items.Any(); }
		}	

		public void Clear()
		{
			Items.Clear();
		}

		public void Add(Product product)
		{
			var item = Items.SingleOrDefault(x => x.Product == product);

			if (item != null)
			{
				item.Quantity++;
				return;
			}

			Items.Add(new CartItem
			{
				Product = product,
				Quantity = 1
			});
		}
	}
}
