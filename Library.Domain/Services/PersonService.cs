using Library.Domain.Models;
using System;
using Versteey.Infrastructure.Persistence;

namespace Library.Domain.Services
{
    public class PersonService : BaseService
    {
        public PersonService(IPersistence persistence) : base(persistence) { }

        public Person CreatePerson()
        {
            Persistence.BeginTransaction();

            var person = new Person();
            Persistence.Create(person);

            Persistence.Commit();

            return person;
        }

        public void DeletePerson(Guid personId)
        {
            Persistence.BeginTransaction();

            var person = Persistence.GetById<Person>(personId);
            Persistence.Delete(person);

            Persistence.Commit();
        }
    }
}
