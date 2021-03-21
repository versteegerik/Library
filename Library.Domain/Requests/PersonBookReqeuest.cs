using System;

namespace Library.Domain.Requests
{
    public abstract class PersonBookRequest
    {
        public Guid BookId { get; set; }
    }

    public class AddBookToWishListRequest : PersonBookRequest
    {
    }

    public class RemoveBookFromWishListRequest : PersonBookRequest
    {
    }

    public class AddBookToOwnedListRequest : PersonBookRequest
    {
    }

    public class RemoveBookFromOwnedListRequest : PersonBookRequest
    {
    }
}
