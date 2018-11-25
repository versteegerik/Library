using Library.Domain.Common;
using Library.Domain.Model;
using Library.Domain.Requests;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.Services
{

    public class NewsService
    {
        private readonly IRepository _repository;

        public NewsService(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<NewsMessage> GetAllForAdmin()
        {
            return _repository.NewsMessages
                .ToArray();
        }

        public IEnumerable<NewsMessage> GetAllForOverview()
        {
            return _repository.NewsMessages
                .Where(nm => nm.IsShown)
                .ToArray();
        }

        public void CreateNewsMessage(CreateNewsMessageRequest request)
        {
            var newsMessage = new NewsMessage(request);
            _repository.Add(newsMessage);
            _repository.SaveChanges();
        }

        public void EditNewsMessage(EditNewsMessageRequest request)
        {
            var newsMessage = _repository.Get<NewsMessage>(request.Id);
            _repository.Update(newsMessage);
            _repository.SaveChanges();
        }
    }
}
