using System.ComponentModel.DataAnnotations;
using Library.Domain.Properties;

namespace Library.Domain.Requests
{
    public  abstract class BookRequest
    {
        [Display(Name = "Book_Title", ResourceType = typeof(DomainResources))]
        public string Title { get; set; }
        [Display(Name = "Book_Author", ResourceType = typeof(DomainResources))]
        public string Author { get; set; }
    }

    public class CreateBookRequest : BookRequest
    {
    }

    public class EditBookRequest : BookRequest
    {
    }
}
