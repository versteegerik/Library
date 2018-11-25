using Library.Domain.Model;
using Library.Domain.Requests;

namespace Library.Domain.Services
{
    public class BookService
    {
        public void CreateBook(CreateBookRequest request)
        {
            var book = new Book(request);
        }
    }
}
