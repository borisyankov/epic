namespace Epic.Domain
{
	public class CartItem 
	{
		public Product Product { get; set; }
		public int Quantity { get; set; }

		public decimal Price
		{
			get
			{
				return Product.Price * Quantity;
			}
		}
	}
}