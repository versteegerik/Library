using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Library.Domain.Models;

namespace Library.Application.Blazor.Data.NHibernateOverrides
{
    public class BookMap : IAutoMappingOverride<Book>
    {
        public void Override(AutoMapping<Book> mapping)
        {
            mapping.HasManyToMany(_ => _.Genres)
                .Cascade.None();
        }
    }
}
