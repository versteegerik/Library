using Library.Domain.Models;
using Library.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using Versteey.Infrastructure.Persistence;

namespace Library.Domain.Services
{
    public class BookGroupService : BaseService
    {
        public BookGroupService(IPersistence persistence) : base(persistence) { }

        public BookGroup GetBookGroupByBookId(Guid bookId) => Persistence.Query<BookGroup>().SingleOrDefault(_ => _.Books.Any(b => b.Id == bookId));

        public IList<BookGroup> SearchBookGroup(SearchBookGroupRequest request)
        {
            var query = Persistence.Query<BookGroup>();
            if (!string.IsNullOrWhiteSpace(request.Author))
            {
                query = query.Where(_ => _.Books.Any(b => b.Author.LastName.Contains(request.Author)));
                query = query.Where(_ => _.Books.Any(b => b.Author.FirstNames.Contains(request.Author)));
            }
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(_ => _.Name.Contains(request.Name));
            }
            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                query = query.Where(_ => _.Books.Any(b => b.Title.Contains(request.Title)));
            }
            return query.OrderBy(_ => _.Name).Take(20).ToList();
        }

        public void CreateBookGroup(CreateBookGroupRequest request, Book book)
        {
            Persistence.BeginTransaction();

            var bookGroup = new BookGroup(request);
            bookGroup.AddBook(book);

            Persistence.Create(bookGroup);
            Persistence.Commit();
        }

        public void UpdateBookGroup(UpdateBookGroupRequest request)
        {
            Persistence.BeginTransaction();

            var bookGroup = Persistence.GetById<BookGroup>(request.BookGroupId);
            bookGroup.Update(request);

            Persistence.Update(bookGroup);
            Persistence.Commit();
        }

        public void AddBookToBookGroup(Guid bookGroupId, Book book)
        {
            Persistence.BeginTransaction();

            var bookGroup = Persistence.GetById<BookGroup>(bookGroupId);
            bookGroup.AddBook(book);

            Persistence.Update(bookGroup);
            Persistence.Commit();
        }
    }
}
