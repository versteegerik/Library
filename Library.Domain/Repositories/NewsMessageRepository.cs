using Library.Domain.Common;
using Library.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.Repositories
{
    public class NewsMessageRepository : Repository
    {
        public NewsMessageRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public IEnumerable<NewsMessage> NewsMessages => DbContext.NewsMessages;
        public IQueryable<NewsMessage> NewsMessagesQuery => DbContext.Query<NewsMessage>();
    }
}
