using EasyDapper.Abstraction;

namespace DapperHelper.ExampleConsumer.DapperRequests
{
    public class IsPlayerGuidTaken : IDapperRequest<bool>
    {
        public IsPlayerGuidTaken(Guid guid) => Guid = guid;

        public Guid Guid { get; set; }

        public object? GetParameters() => new { Guid };

        public string GetSql() => "SELECT CASE WHEN EXISTS (SELECT * FROM Person WHERE Guid = @Guid) THEN 1 ELSE 0 END";
    }
}
