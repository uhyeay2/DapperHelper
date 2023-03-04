namespace DapperHelper.ExampleConsumer.DataTransferObjects
{
    public class PersonDTO
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;
    }
}
