using Library.Application.Models;
using System.Linq;

namespace Library.Application.Common
{
    public interface IApplicationPersistence
    {
        IQueryable<NewsMessage> NewsMessages { get; }
        void Create(NewsMessage newsMessage);
        void Update(NewsMessage newsMessage);
    }
}
