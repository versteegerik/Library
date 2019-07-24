using Library.Domain.Common;
using Library.Domain.Models.Requests;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Models
{
    [Table("Books")]
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DomainUser Owner { get; set; }

        private Book() { }

        public Book(CreateBookRequest request, DomainUser owner) : this()
        {
            Title = request.Title;
            Author = request.Author;
            Isbn = request.Isbn;
            Owner = owner;
        }

        public void Update(UpdateBookRequest request)
        {
            Title = request.Title;
            Author = request.Author;
            Isbn = request.Isbn;
        }
    }
}
