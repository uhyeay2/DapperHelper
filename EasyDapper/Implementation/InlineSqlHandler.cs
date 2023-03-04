using Dapper;
using EasyDapper.Abstraction;

namespace EasyDapper.Implementation
{
    internal class InlineSqlHandler : DapperHandler, IHandleInlineSql
    {
        public InlineSqlHandler(IDbConnectionFactory connectionFactory) : base(connectionFactory) { }

        public async Task<int> ExecuteAsync(IDapperRequest request)
        {
            using var connection = _connectionFactory.NewConnection();

            connection.Open();

            return await connection.ExecuteAsync(request.GetSql(), request.GetParameters());
        }

        public async Task<TOutput> FetchAsync<TOutput>(IDapperRequest<TOutput> request)
        {
            using var connection = _connectionFactory.NewConnection();

            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<TOutput>(request.GetSql(), request.GetParameters());
        }

        public async Task<IEnumerable<TOutput>> FetchListAsync<TOutput>(IDapperRequest<TOutput> request)
        {
            using var connection = _connectionFactory.NewConnection();

            connection.Open();

            return await connection.QueryAsync<TOutput>(request.GetSql(), request.GetParameters());
        }     
    }
}
