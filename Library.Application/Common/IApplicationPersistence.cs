using System.Linq;
using Library.Domain.Models;

namespace Library.Application.Common
{
    public interface IApplicationPersistence
    {
        IQueryable<NewsMessage> NewsMessages { get; }
    }
}
