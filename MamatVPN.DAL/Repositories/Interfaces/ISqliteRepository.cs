using Microsoft.Data.Sqlite;

namespace MamatVPN.DAL.Repositories.Interfaces
{
    internal interface ISqliteRepository
    {
        Task<SqliteConnection> GetConnectionAsync();
    }
}
