using DapperHelper.ExampleConsumer.DapperRequests;
using EasyDapper.Abstraction;
using EasyDapper.DependencyInjection;

namespace DapperHelper.ExampleTests
{
    public class SqlHandlerTests
    {
        private static readonly IHandleInlineSql _sqlHandler = ServiceInjection.NewSqlHandler(Hidden.TestDatabaseConnectionString);

        #region GetPerson

        [Fact]
        public async Task GetPerson_Given_NoPersonExists_Should_ReturnNull()
        {
            var result = await _sqlHandler.FetchAsync(new GetPerson(Guid.NewGuid()));

            Assert.Null(result);
        }

        [Fact]
        public async Task GetPerson_Given_PersonExists_Should_ReturnPerson()
        {
            var insertPersonRequest = new InsertPerson(Guid.NewGuid(), "firstName", "lastName", "phoneNumber", "emailAddress");

            await _sqlHandler.ExecuteAsync(insertPersonRequest);

            var result = await _sqlHandler.FetchAsync(new GetPerson(insertPersonRequest.Guid));

            await _sqlHandler.ExecuteAsync(new DeletePerson(insertPersonRequest.Guid));

            Assert.Multiple(() =>
            {
                Assert.NotNull(result);

                Assert.Equal(insertPersonRequest.FirstName, result.FirstName);
                Assert.Equal(insertPersonRequest.LastName, result.LastName);
                Assert.Equal(insertPersonRequest.PhoneNumber, result.PhoneNumber);
                Assert.Equal(insertPersonRequest.EmailAddress, result.EmailAddress);
            });
        }

        #endregion

        #region IsPlayerGuidTaken

        [Fact]
        public async Task IsPlayerGuidTaken_Given_GuidTaken_Should_ReturnTrue()
        {
            var guid = Guid.NewGuid();

            await _sqlHandler.ExecuteAsync(new InsertPerson(guid, "firstName", "lastName", "phoneNumber", "emailAddress"));

            var exists = await _sqlHandler.FetchAsync(new IsPlayerGuidTaken(guid));

            await _sqlHandler.ExecuteAsync(new DeletePerson(guid));

            Assert.True(exists);
        }

        [Fact]
        public async Task IsPlayerGuidTaken_Given_GuidNotTaken_Should_ReturnFalse()
        {
            var exists = await _sqlHandler.FetchAsync(new IsPlayerGuidTaken(Guid.NewGuid()));

            Assert.False(exists);
        }

        #endregion

        #region InsertPerson

        [Fact]
        public async Task InsertPerson_Given_PersonIsInserted_Should_ReturnOne()
        {
            var insertPersonRequest = new InsertPerson(Guid.NewGuid(), "firstName", "lastName", "phoneNumber", "emailAddress");

            var rowsAffected = await _sqlHandler.ExecuteAsync(insertPersonRequest);

            await _sqlHandler.ExecuteAsync(new DeletePerson(insertPersonRequest.Guid));

            Assert.Equal(1, rowsAffected);
        }

        #endregion

        #region DeletePerseon

        [Fact]
        public async Task DeletePerson_Given_NoPersonExists_Should_ReturnZero()
        {
            var rowsAffected = await _sqlHandler.ExecuteAsync(new DeletePerson(Guid.NewGuid()));

            Assert.Equal(0, rowsAffected);
        }

        #endregion
    }
}
