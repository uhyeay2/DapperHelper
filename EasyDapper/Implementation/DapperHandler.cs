using EasyDapper.Abstraction;

namespace EasyDapper.Implementation
{
    internal abstract class DapperHandler
    {
        protected readonly IDbConnectionFactory _connectionFactory;

        public DapperHandler(IDbConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;
    }
}
