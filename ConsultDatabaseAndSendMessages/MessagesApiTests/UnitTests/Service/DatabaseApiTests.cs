using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using MessagesApi.DTO;
using MessagesApi.Exceptions;
using MessagesApi.Interfaces;
using MessagesApi.Constants.Logs;
using Microsoft.Extensions.Logging;
using Moq;
using System.Text.Json;

namespace MessagesApiTests.UnitTests.Service
{
    public class DatabaseApiTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<ISimpleHttpClient> _simpleHttpClient;
        private readonly Mock<ILogger<MessagesApi.Services.External.DatabaseApi>> _logger;
        private readonly MessagesApi.Services.External.DatabaseApi _databaseApi;
        private readonly long _accountNumber;

        public DatabaseApiTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _simpleHttpClient = _fixture.Freeze<Mock<ISimpleHttpClient>>();
            _logger = _fixture.Freeze<Mock<ILogger<MessagesApi.Services.External.DatabaseApi>>>();
            _databaseApi = new MessagesApi.Services.External.DatabaseApi(_simpleHttpClient.Object, _logger.Object);
            _accountNumber = _fixture.Create<long>();
        }

        [Fact]
        public async Task GetCustomerTransactions_ShouldReturn_CustomerTransactionsRequest()
        {
            var expectedResponse = _fixture.Create<CustomerTransactionsRequest>(); 

            var jsonResponse = JsonSerializer.Serialize(expectedResponse);
            _simpleHttpClient.Setup(client => client.Get(It.IsAny<string>())).ReturnsAsync(jsonResponse);

            var result = await _databaseApi.GetCustomerTransactions(_accountNumber);

            result.Should().BeEquivalentTo(expectedResponse);
            _simpleHttpClient.Verify(client => client.Get(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task GetCustomerTransactions_ShouldThrow_RequestFailedException()
        {
            _simpleHttpClient.Setup(client => client.Get(It.IsAny<string>())).ThrowsAsync(new RequestFailedException(ErrorMessages.RequestFail));

            Func<Task> act = async () => await _databaseApi.GetCustomerTransactions(_accountNumber);

            await act.Should().ThrowAsync<RequestFailedException>()
                .WithMessage(ErrorMessages.RequestFail);
            _simpleHttpClient.Verify(client => client.Get(It.IsAny<string>()), Times.Once);
        }
        [Fact]
        public async Task GetCustomerTransactions_ShouldThrow_JsonSerializationException()
         {
            _simpleHttpClient.Setup(client => client.Get(It.IsAny<string>())).ReturnsAsync(string.Empty);

            Func<Task> act = async () => await _databaseApi.GetCustomerTransactions(_accountNumber);

            await act.Should().ThrowAsync<JsonSerializationException>()
                .WithMessage(ErrorMessages.SerializationFail);

            _simpleHttpClient.Verify(client => client.Get(It.IsAny<string>()), Times.Once);
        }
    }
}
