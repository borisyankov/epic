using System.Collections.Generic;

namespace Epic.Domain
{
	public class BlogPost : Page
	{
		public IEnumerable<string> Tags { get; set; }
	}
}
