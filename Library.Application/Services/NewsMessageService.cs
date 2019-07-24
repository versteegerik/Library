using Library.Application.Common;
using Library.Application.Models;
using Library.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Application.Services
{
    public class NewsMessageService
    {
        private readonly IApplicationPersistence Persistence;

        public NewsMessageService(IApplicationPersistence persistence)
        {
            Persistence = persistence;
        }

        public IEnumerable<NewsMessage> GetAll()
        {
            return Persistence.NewsMessages
                .ToArray();
        }

        public IEnumerable<NewsMessage> GetListForOverview()
        {
            return Persistence.NewsMessages
                .Where(nm => nm.IsShown)
                .ToArray();
        }

        public void CreateNewsMessage(CreateNewsMessageRequest request)
        {
            var newsMessage = new NewsMessage(request);
            Persistence.Create(newsMessage);
        }

        public void UpdateNewsMessage(UpdateNewsMessageRequest request)
        {
            var newsMessage = GetById(request.Id);

            newsMessage.Update(request);

            Persistence.Update(newsMessage);
        }

        public NewsMessage GetById(Guid id)
        {
            return Persistence.NewsMessages.Single(_ => _.Id == id);
        }
    }
}
