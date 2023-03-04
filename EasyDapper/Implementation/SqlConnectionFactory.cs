using EasyDapper.Abstraction;
using System.Data;
using System.Data.SqlClient;

namespace EasyDapper.Implementation
{
    internal class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString) => _connectionString = connectionString;

        public IDbConnection NewConnection() => new SqlConnection(_connectionString);
    }
}
