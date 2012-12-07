namespace Epic.Biz.Shops
{
	public class ServerConfiguration
	{
		public string DatabaseAddress { get; set; }

		public ServerConfiguration()
		{
			DatabaseAddress = "http://localhost:8080";
		}
	}
}