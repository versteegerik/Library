using Library.Domain.Common;
using Library.Domain.Requests;

namespace Library.Domain.Model
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public ApplicationUser Owner { get; set; }

        private Book() { }

        public Book(CreateBookRequest request)
        {
            Title = request.Title;
            Author = request.Author;
            Owner = request.Owner;
        }
    }
}
