using Library.Domain.Model;

namespace Library.Domain.Requests
{
    public class CreateBookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Person Owner { get; set; }
    }
}
