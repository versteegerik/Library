namespace Library.Domain.Requests
{
    public class CreateBookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class EditBookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
