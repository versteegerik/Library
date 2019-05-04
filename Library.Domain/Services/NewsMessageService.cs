using Library.Domain.Model;
using Library.Domain.Repositories;
using Library.Domain.Requests;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.Services
{
    public class NewsMessageService : IService<NewsMessageRepository>
    {
        public NewsMessageService(NewsMessageRepository repository) : base(repository)
        {
        }

        public IEnumerable<NewsMessage> GetAll()
        {
            return Repository.NewsMessages
                .ToArray();
        }

        public IEnumerable<NewsMessage> GetListForOverview()
        {
            return Repository.NewsMessages
                .Where(nm => nm.IsShown)
                .ToArray();
        }

        public void CreateNewsMessage(CreateNewsMessageRequest request)
        {
            var newsMessage = new NewsMessage(request);
            Repository.Add(newsMessage);
            Repository.SaveChanges();
        }

        public void EditNewsMessage(EditNewsMessageRequest request)
        {
            var newsMessage = Repository.Get<NewsMessage>(request.Id);
            Repository.Update(newsMessage);
            Repository.SaveChanges();
        }
    }
}
