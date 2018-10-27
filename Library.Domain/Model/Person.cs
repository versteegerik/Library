using Library.Domain.Common;
using Library.Domain.Requests;

namespace Library.Domain.Model
{
    public sealed class Person : BaseEntity
    {
        public string FirstName { get; private set; }
        public string Prefix { get; private set; }
        public string LastName { get; private set; }

        public Person(CreatePersonRequest request)
        {
            FirstName = request.FirstName;
            Prefix = request.Prefix;
            LastName = request.LastName;
        }
    }
}
