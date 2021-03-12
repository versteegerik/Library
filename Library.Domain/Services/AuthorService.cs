using Library.Domain.Models;
using Library.Domain.Requests;
using Library.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using Versteey.Infrastructure.Persistence;

namespace Library.Domain.Services
{
    public class AuthorService : BaseService
    {
        public AuthorService(IPersistence persistence) : base(persistence)
        {
        }

        public Author GetAuthorById(Guid id) => Persistence.GetById<Author>(id);
        public IList<Book> GetBooksByAuthor(Guid id) => Persistence.Query<Book>().Where(_ => _.Author.Id == id).OrderBy(_ => _.Title).ToList();
        public IQueryable<Author> GetAllAuthors() => Persistence.Query<Author>().OrderBy(_ => _.LastName);

        public Guid CreateAuthor(CreateAuthorRequest request)
        {
            if (!new CreateAuthorRequestValidator().Validate(request).IsValid)
            {
                throw new Exception("CreateAuthor validation error");
            }

            Persistence.BeginTransaction();
            var author = new Author(request);
            Persistence.Create(author);
            Persistence.Commit();
            return author.Id;
        }

        public void UpdateAuthor(UpdateAuthorRequest request)
        {
            if (!new UpdateAuthorRequestValidator().Validate(request).IsValid)
            {
                throw new Exception("UpdateAuthor validation error");
            }

            Persistence.BeginTransaction();
            var author = GetAuthorById(request.Id);
            author.Update(request);
            Persistence.Commit();
        }
    }
}
