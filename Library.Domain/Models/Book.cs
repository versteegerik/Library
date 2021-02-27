using Library.Common.Properties;
using Library.Domain.Requests;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Versteey.Common.Extensions;
using Versteey.Common.Domain;

namespace Library.Domain.Models
{
    public class Book : BaseEntity
    {
        [Display(Name = nameof(Resources.Book_Title), ResourceType = typeof(Resources))]
        public virtual string Title { get; set; }
        [Display(Name = nameof(Resources.Book_AlternativeTitle), ResourceType = typeof(Resources))]
        public virtual string AlternativeTitle { get; set; }
        [Display(Name = nameof(Resources.Book_Author), ResourceType = typeof(Resources))]
        public virtual Author Author { get; set; }
        [Display(Name = nameof(Resources.Book_Isbn), ResourceType = typeof(Resources))]
        public virtual string Isbn { get; set; }
        [Display(Name = nameof(Resources.BookGenre), ResourceType = typeof(Resources))]
        public virtual IList<BookGenre> Genres { get; set; } = new List<BookGenre>();

        public Book() { }

        public Book(CreateBookRequest request) : this()
        {
            Title = request.Title;
            AlternativeTitle = request.AlternativeTitle;
            Author = request.Author;
            Isbn = request.Isbn;
            Genres.Clear();
            Genres.ReplaceWith(request.Genres);
        }

        public virtual void Update(UpdateBookRequest request)
        {
            Title = request.Title;
            AlternativeTitle = request.AlternativeTitle;
            Author = request.Author;
            Isbn = request.Isbn;
            Genres.ReplaceWith(request.Genres);
        }
    }
}
