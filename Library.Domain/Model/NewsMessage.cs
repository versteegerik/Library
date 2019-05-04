using Library.Domain.Common;
using Library.Domain.Requests;

namespace Library.Domain.Model
{
    public class NewsMessage : BaseEntity
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsShown { get; set; }

        public NewsMessage() { }

        public NewsMessage(CreateNewsMessageRequest request) : this()
        {
            Title = request.Title;
            Message = request.Message;
            IsShown = request.IsShown;
        }

        public void Edit(EditNewsMessageRequest request)
        {
            Title = request.Title;
            Message = request.Message;
            IsShown = request.IsShown;
        }
    }
}
