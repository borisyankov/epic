using System;

namespace Epic.Domain
{
	public class Page
	{
		public string Title { get; set; }
		public string Body { get; set; }
		public DateTime Updated { get; set; }
		public bool Published { get; set; }
	}
}
