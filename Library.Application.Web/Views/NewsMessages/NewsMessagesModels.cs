using Library.Domain.Model;

namespace Library.Application.Web.Views.NewsMessages
{
    public class NewsMessagesOverviewModel
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public NewsMessagesOverviewModel(NewsMessage newsMessage)
        {
            Title = newsMessage.Title;
            Message = newsMessage.Message;
        }
    }
}
