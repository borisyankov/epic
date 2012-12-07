using System.Collections.Generic;
using Epic.Data.Database;
using Epic.Domain;
using Raven.Client;

namespace Epic.Data.Repositories
{
	public class PagesRepository
	{
		private readonly IDocumentStore _db;

		public PagesRepository(IDbProvider dbProvider)
		{
			_db = dbProvider.GetDataStore();
		}

		public IEnumerable<Page> GetPages()
		{
			using (var session = _db.OpenSession())
			{
				return session.Query<Page>();
			}
		}

		public IEnumerable<BlogPost> GetBlogPosts()
		{
			using (var session = _db.OpenSession())
			{
				return session.Query<BlogPost>();
			}
		}
	}
}
