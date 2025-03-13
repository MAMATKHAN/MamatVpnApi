using System.Transactions;
using MamatVPN.DAL.Options;
using MamatVPN.DAL.Repositories.Interfaces;
using Microsoft.Data.Sqlite;

namespace MamatVPN.DAL.Repositories
{
    public class SqliteRepository : ISqliteRepository
    {
        private readonly DbConnectionOption _dbConnectionOption;

        public SqliteRepository(DbConnectionOption dbConnectionOption)
        {
            _dbConnectionOption = dbConnectionOption;
        }
        public async Task<SqliteConnection> GetConnectionAsync()
        {
            if (Transaction.Current is not null &&
            Transaction.Current.TransactionInformation.Status is TransactionStatus.Aborted)
            {
                throw new TransactionAbortedException("Transaction was aborted (probably by user cancellation request)");
            }

            using var connection = new SqliteConnection(_dbConnectionOption.SqlLiteConnectionString);
            await connection.OpenAsync();

            return connection;

        }
    }
}
