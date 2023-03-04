using EasyDapper.Abstraction;

namespace DapperHelper.ExampleConsumer.DapperRequests
{
    public class DeletePerson : IDapperRequest
    {
        public DeletePerson(Guid guid) => Guid = guid;

        public Guid Guid { get; set; }

        public object? GetParameters() => new { Guid };

        public string GetSql() => "DELETE FROM Person WHERE Guid = @Guid";
    }
}
