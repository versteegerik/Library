using Library.Common.Properties;
using Library.Domain.Requests;
using System.ComponentModel.DataAnnotations;
using Versteey.Common.Domain;

namespace Library.Domain.Models
{
    public class Book : BaseEntity
    {
        [Display(Name = nameof(Resources.Book_Title), ResourceType = typeof(Resources))]
        public virtual string Title { get; set; }
        [Display(Name = nameof(Resources.Book_Author), ResourceType = typeof(Resources))]
        public virtual string Author { get; set; }
        [Display(Name = nameof(Resources.Book_Isbn), ResourceType = typeof(Resources))]
        public virtual string Isbn { get; set; }

        public Book() { }

        public Book(CreateBookRequest request) : this()
        {
            Title = request.Title;
            Author = request.Author;
            Isbn = request.Isbn;
        }

        public virtual void Update(UpdateBookRequest request)
        {
            Title = request.Title;
            Author = request.Author;
            Isbn = request.Isbn;
        }
    }
}
