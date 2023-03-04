using EasyDapper.Abstraction;

namespace DapperHelper.ExampleConsumer.DapperRequests
{
    public class InsertPerson :IDapperRequest
    {
        public InsertPerson(Guid guid, string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            Guid = guid;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }

        public Guid Guid { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public object? GetParameters() => new { Guid, FirstName, LastName, PhoneNumber, EmailAddress };

        public string GetSql() => "INSERT INTO Person (Guid, FirstName, LastName, PhoneNumber, EmailAddress)" +
                                             " VALUES (@Guid, @FirstName, @LastName, @PhoneNumber, @EmailAddress)";
    }
}
