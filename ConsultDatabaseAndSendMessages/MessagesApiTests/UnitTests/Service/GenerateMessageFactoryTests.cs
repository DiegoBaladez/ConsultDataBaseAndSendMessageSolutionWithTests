using AutoFixture;
using FluentAssertions;
using MessagesApi.Constants.Enums;
using MessagesApi.Exceptions;
using MessagesApi.Services;

namespace MessagesApiTests.UnitTests.Service
{
    public class GenerateMessageFactoryTests
    {
        [Fact]
        public void GetMessageGenerator_ShouldReturn_StatementGenerator()
        {
            var result = GenerateMessageFactoryService.GetMessageGenerator(MessageType.Statement);

            result.GetType().Should().Be(typeof(GenerateStatementService));
        }
        [Fact]
        public void GetMessageGenerator_ShouldThrow_NoTypeMatchException()
        {
           var wrongType = (MessageType)42;

           Assert.Throws<NoTypeMatchException>(() => GenerateMessageFactoryService.GetMessageGenerator(wrongType));
        }
    }
}
