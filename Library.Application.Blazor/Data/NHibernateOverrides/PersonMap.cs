using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Library.Domain.Models;

namespace Library.Application.Blazor.Data.NHibernateOverrides
{
    public class PersonMap : IAutoMappingOverride<Person>
    {
        public void Override(AutoMapping<Person> mapping)
        {
            mapping.HasManyToMany(_ => _.WishListBooks)
                .Cascade.None();
            mapping.HasManyToMany(_ => _.OwnedBooks)
                .Table("PersonToOwnedBooks")
                .Cascade.None();
        }
    }
}
