using Epic.Biz.Shops;
using Epic.Data.Database;
using Epic.Data.Interop;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epic.Test
{
	[TestClass]
	public class CsvInteropTests
	{
		[Ignore][TestMethod]
		public void CanImportLayline()
		{
			var dbProvider = new PersistentDbProvider(new ServerConfiguration {DatabaseAddress = "http://localhost:8080/"});
			var csvInterop = new CsvInterop(dbProvider);

			csvInterop.ReadFromCsv("../../TestData/layline_short.csv");
		}
	}
}