using System.Data;

namespace EasyDapper.Abstraction
{
    public interface IDbConnectionFactory
    {
        public IDbConnection NewConnection();
    }
}
