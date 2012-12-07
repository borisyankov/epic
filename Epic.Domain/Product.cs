using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Epic.Domain
{
	public enum ProductVisibility
	{
		Published, Hidden
	}

	public class Product
	{
		[Required]
		public string Title { get; set; }
		public string Description { get; set; }

		public string ProductType { get; set; }
		public string Vendor { get; set; }
		public string Collection { get; set; }

		public decimal Price { get; set; }
		public decimal Weight { get; set; }

		// compare at price?

		public bool ChargeTax { get; set; }
		public bool RequireShippingAddress { get; set; } // None for digital

		public string SKU { get; set; } // Unique identifier for organization of larger inventories. Optional

		public class Inventory
		{
			public bool Enabled { get; set; }
			public int InStock { get; set; }
			public bool CanBuyIfOutOfStock { get; set; }
		}		

		public IEnumerable<string> Tags { get; set; }

		public IEnumerable<string> Images { get; set; }

		// collection?

		public ProductVisibility Visibility { get; set; }
	}
}
