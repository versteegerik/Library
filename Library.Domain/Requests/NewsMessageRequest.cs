using System;

namespace Library.Domain.Requests
{
    public abstract class NewsMessageRequest
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsShown { get; set; }
    }

    public class CreateNewsMessageRequest : NewsMessageRequest
    {

    }

    public class EditNewsMessageRequest : NewsMessageRequest
    {
        public Guid Id { get; set; }
    }
}
