using Library.Common.Properties;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Requests
{
    public abstract class BookRequest
    {
        [Display(Name = "Book_Isbn", ResourceType = typeof(Resources))]
        public string Isbn { get; set; }
        [Display(Name = "Book_Title", ResourceType = typeof(Resources))]
        public string Title { get; set; }
        [Display(Name = "Book_Author", ResourceType = typeof(Resources))]
        public string Author { get; set; }
    }

    public class CreateBookRequest : BookRequest
    {
    }
}
