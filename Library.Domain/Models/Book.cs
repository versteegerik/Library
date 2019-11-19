using Library.Common;
using Library.Domain.Models.Requests;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Models
{
    [Table("Books")]
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public virtual IList<UserBookInformation> UserBookInformations { get; set; }

        public Book() { }

        public Book(CreateBookRequest request) : this()
        {
            Title = request.Title;
            Author = request.Author;
            Isbn = request.Isbn;
        }

        public void Update(UpdateBookRequest request)
        {
            Title = request.Title;
            Author = request.Author;
            Isbn = request.Isbn;
        }
    }
}
