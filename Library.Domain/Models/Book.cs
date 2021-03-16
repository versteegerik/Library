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
        [Display(Name = nameof(Resources.Book_IsBookGroup), ResourceType = typeof(Resources))]
        public virtual bool IsBookGroup { get; set; }

        public Book() { }

        public Book(CreateBookRequest request) : this()
        {
            HandleRequest(request);
        }

        public virtual void Update(UpdateBookRequest request)
        {
            HandleRequest(request);
        }

        private void HandleRequest(BookRequest request)
        {
            Title = request.Title?.Trim();
            AlternativeTitle = request.AlternativeTitle?.Trim();
            Author = request.Author;
            Isbn = request.Isbn;
            Genres.ReplaceWith(request.Genres);
            IsBookGroup = request.IsBookGroup;
        }
    }
}
