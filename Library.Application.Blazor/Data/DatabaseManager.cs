using Versteey.Infrastructure.Database;

namespace Library.Application.Blazor.Data
{
    public class DatabaseManager : DatabaseManagerBase
    {
        public DatabaseManager(string connectionString) : base(connectionString) { }

        public void Initialize()
        {
            UpdateFromScripts();
        }
    }
}
