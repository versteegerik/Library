using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Application.Web.Views.NewsMessages
{
    public class ListModel
    {
        public IEnumerable<NewsMessageModel> NewsMessages { get; set; }

        public ListModel(IEnumerable<NewsMessage> newsMessages)
        {
            NewsMessages = newsMessages.Select(nm => new NewsMessageModel(nm));
        }
    }

    public class NewsMessageModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsShown { get; set; }

        public NewsMessageModel(NewsMessage newsMessage)
        {
            Id = newsMessage.Id;
            Title = newsMessage.Title;
            Message = newsMessage.Message;
            IsShown = newsMessage.IsShown;
        }
    }
}
