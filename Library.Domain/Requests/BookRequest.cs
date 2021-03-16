using Library.Common.Properties;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Versteey.Common.Extensions;

namespace Library.Domain.Requests
{
    public abstract class BookRequest
    {
        [Display(Name = nameof(Resources.Book_Title), ResourceType = typeof(Resources))]
        public string Title { get; set; }
        [Display(Name = nameof(Resources.Book_AlternativeTitle), ResourceType = typeof(Resources))]
        public string AlternativeTitle { get; set; }
        [Display(Name = nameof(Resources.Book_Author), ResourceType = typeof(Resources))]
        public Author Author { get; set; }
        [Display(Name = nameof(Resources.Book_Isbn), ResourceType = typeof(Resources))]
        public string Isbn { get; set; }
        [Display(Name = nameof(Resources.BookGenre), ResourceType = typeof(Resources))]
        public IList<BookGenre> Genres { get; set; } = new List<BookGenre>();
        [Display(Name = nameof(Resources.Book_IsBookGroup), ResourceType = typeof(Resources))]
        public virtual bool IsBookGroup { get; set; }
    }

    public class CreateBookRequest : BookRequest
    {
    }

    public class UpdateBookRequest : BookRequest
    {
        public Guid Id { get; set; }
        public UpdateBookRequest()
        {

        }
        public UpdateBookRequest(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            AlternativeTitle = book.AlternativeTitle;
            Author = book.Author;
            Isbn = book.Isbn;
            Genres.ReplaceWith(book.Genres);
            IsBookGroup = book.IsBookGroup;
        }
    }
}
