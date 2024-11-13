using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using MessagesApi.Constants.Enums;
using MessagesApi.DTO;
using MessagesApi.DTO.Messages;
using MessagesApi.Interfaces;
using MessagesApi.Interfaces.External;
using MessagesApi.Services;
using Moq;

namespace MessagesApiTests.UnitTests.Service
{
    public class SendMessageTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<ISimpleHttpClient> _simpleHttpClient;
        private readonly Mock<IDatabaseApi> _databaseApi;
        private readonly SendMessages _sendMessages;

        public SendMessageTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _simpleHttpClient = _fixture.Freeze<Mock<ISimpleHttpClient>>();
            _databaseApi = _fixture.Freeze<Mock<IDatabaseApi>>();
            _sendMessages = new SendMessages(_databaseApi.Object);
        }

        [Fact]
        public void GetStatement_ShouldReturn_StatementXml()
        {
            //arrange
            var accountNumber = _fixture.Create<long>();
            var customerTransactions = _fixture.Create<CustomerTransactionsRequest>();

            var messageGenerator = GenerateMessageFactoryService.GetMessageGenerator(MessageType.Statement);
            var messageParameter = messageGenerator.GenerateMessage(customerTransactions);
            var xmlString = MessagesSerializer<BussinesMessage>.Serialize(messageParameter);

            _databaseApi.Setup(k => k.GetCustomerTransactions(It.IsAny<long>())).ReturnsAsync(customerTransactions);

            //act
            var result = _sendMessages.SendBankToCustomerMessages(accountNumber, MessageType.Statement).Result;

            //assert
            _databaseApi.Verify(db => db.GetCustomerTransactions(accountNumber), Times.Once);
            result.Should().Be(xmlString);
        }
    }
}
