using Library.Application.Models;
using System.Collections.Generic;

namespace Library.Application.Web.Views.Home
{
    public class HomeIndexModel
    {
        public NewsMessages.ListModel NewsMessages { get; set; }

        public HomeIndexModel(IEnumerable<NewsMessage> newsMessages)
        {
            NewsMessages = new NewsMessages.ListModel(newsMessages);
        }
    }
}
