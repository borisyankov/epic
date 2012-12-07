using System;
using System.ComponentModel.DataAnnotations;

namespace Epic.Domain
{
	public class Shop
	{
		public string Name { get; set; }
		public string Description { get; set; }

		[DataType(DataType.EmailAddress)]
		public string AccountEmail { get; set; }

		[DataType(DataType.EmailAddress)]
		public string CustomerEmail { get; set; }

		public string Phone { get; set; }

		public string Address { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public string Zip { get; set; }

		// order id formatting?

		public TimeZone TimeZone { get; set; }
		public bool IsMetric { get; set; }

		public string Language { get; set; }

		//public string GoogleAnalyticsAccount { get; set; }
	}
}