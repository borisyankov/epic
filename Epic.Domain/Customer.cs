using System.Collections.Generic;

namespace Epic.Domain
{
	public class Customer
	{
		public Person Person { get; set; }

		public string Notes { get; set; }
		public IEnumerable<string> Tags { get; set; }
		public bool AcceptsMarketing { get; set; }
	}
}
