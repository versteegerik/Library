using Library.Domain.Requests;
using Versteey.Common.Domain;

namespace Library.Domain.Models
{
    public class Book : BaseEntity
    {
        public virtual string Title { get; set; }
        public virtual string Author { get; set; }
        public virtual string Isbn { get; set; }

        public Book() { }

        public Book(CreateBookRequest request) : this()
        {
            Title = request.Title;
            Author = request.Author;
            Isbn = request.Isbn;
        }
    }
}
