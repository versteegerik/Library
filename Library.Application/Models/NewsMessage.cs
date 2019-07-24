using Library.Application.Models.Requests;
using Library.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Application.Models
{
    [Table("NewsMessages")]
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

        public void Update(UpdateNewsMessageRequest request)
        {
            Title = request.Title;
            Message = request.Message;
            IsShown = request.IsShown;
        }
    }
}
