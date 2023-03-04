using EasyDapper.Abstraction;
using EasyDapper.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace EasyDapper.DependencyInjection
{
    public static class ServiceInjection
    {
        public static IServiceCollection InjectDapperHandlerWithSqlConnectionFactory(this IServiceCollection services, string connectionString) => services.InjectDapperHandler(NewSqlConnectionFactory(connectionString));

        public static IServiceCollection InjectDapperHandler(this IServiceCollection services, IDbConnectionFactory connectionFactory)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSingleton(connectionFactory);

            services.AddScoped<InlineSqlHandler>();

            services.AddScoped<StoredProcHandler>();

            return services;
        }

        private static IDbConnectionFactory NewSqlConnectionFactory(string connectionString) => new SqlConnectionFactory(connectionString);

        public static IHandleInlineSql NewSqlHandler(string connectionString) => new InlineSqlHandler(NewSqlConnectionFactory(connectionString));

        public static IHandleInlineSql NewSqlHandler(IDbConnectionFactory connectionFactory) => new InlineSqlHandler(connectionFactory);

        public static IHandleStoredProcedures NewStoredProcHandler(string connectionString) => new StoredProcHandler(NewSqlConnectionFactory(connectionString));

        public static IHandleStoredProcedures NewStoredProcHandler(IDbConnectionFactory connectionFactory) => new StoredProcHandler(connectionFactory);
    }
}
