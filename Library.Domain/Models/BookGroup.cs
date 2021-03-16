using Library.Domain.Requests;
using System;
using System.Collections.Generic;
using Versteey.Common.Domain;

namespace Library.Domain.Models
{
    public class BookGroup : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual IList<Book> Books { get; set; } = new List<Book>();

        public BookGroup() { }
        public BookGroup(CreateBookGroupRequest request) : this()
        {
            HandleRequest(request);
        }

        public virtual void Update(UpdateBookGroupRequest request)
        {
            HandleRequest(request);
        }

        private void HandleRequest(BookGroupRequest request)
        {
            Name = request.Name;
        }

        public virtual void AddBook(Book book)
        {
            if (!Books.Contains(book))
            {
                Books.Add(book);
            }
        }
    }
}
