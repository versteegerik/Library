using Library.Domain.Model;
using Library.Domain.Properties;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Requests
{
    public abstract class NewsMessageRequest
    {
        [Display(Name = "NewsMessage_Title", ResourceType = typeof(DomainResources))]
        public string Title { get; set; }
        [Display(Name = "NewsMessage_Message", ResourceType = typeof(DomainResources))]
        public string Message { get; set; }
        [Display(Name = "NewsMessage_IsShown", ResourceType = typeof(DomainResources))]
        public bool IsShown { get; set; }
    }

    public class CreateNewsMessageRequest : NewsMessageRequest
    {

    }

    public class EditNewsMessageRequest : NewsMessageRequest
    {
        public Guid Id { get; set; }

        public EditNewsMessageRequest() { }
        public EditNewsMessageRequest(NewsMessage newsMessage) : this()
        {
            Id = newsMessage.Id;
            Title = newsMessage.Title;
            Message = newsMessage.Message;
            IsShown = newsMessage.IsShown;
        }
    }
}
