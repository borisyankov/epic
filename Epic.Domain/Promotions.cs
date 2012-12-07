using System.Collections.Generic;

namespace Epic.Domain
{
	class Promotions
	{
		public IEnumerable<Coupon> Coupons { get; set; }
	}

	public class Coupon
	{
		public string Code { get; set; }

		// concrete value / %%% / free shipping
		// for all / orders over / collection / select product
		// starts / ends / usage count
	}
}
