using Library.Domain.Model;
using Library.Domain.Repositories;
using Library.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            Repository.Create(newsMessage);
            Repository.SaveChanges();
        }

        public async Task EditNewsMessage(EditNewsMessageRequest request)
        {
            var newsMessage = await Repository.FindAsync<NewsMessage>(request.Id);
            Repository.Update(newsMessage);
            Repository.SaveChanges();
        }

        public async Task<NewsMessage> GetById(Guid id)
        {
            return await Repository.FindAsync<NewsMessage>(id);
        }
    }
}
