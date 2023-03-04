namespace EasyDapper.Abstraction
{
    public interface IDapperHandler
    {
        public Task<int> ExecuteAsync(IDapperRequest request);

        public Task<TOutput> FetchAsync<TOutput>(IDapperRequest<TOutput> request);

        public Task<IEnumerable<TOutput>> FetchListAsync<TOutput>(IDapperRequest<TOutput> request);
    }

    public interface IHandleInlineSql : IDapperHandler { }

    public interface IHandleStoredProcedures : IDapperHandler { }
}
