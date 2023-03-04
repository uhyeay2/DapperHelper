using DapperHelper.ExampleConsumer.DataTransferObjects;
using EasyDapper.Abstraction;

namespace DapperHelper.ExampleConsumer.DapperRequests
{
    public class GetPerson : IDapperRequest<PersonDTO>
    {
        public GetPerson(int id) => Id = id;

        public GetPerson(Guid guid) => Guid = guid;

        public int? Id { get; set; }

        public Guid Guid { get; set; }

        public object? GetParameters() => new { Id, Guid };

        public string GetSql() => "SELECT * FROM Person WHERE (Id = @Id AND @Guid IS NULL) OR (@Id IS NULL AND Guid = @Guid)";
    }
}
