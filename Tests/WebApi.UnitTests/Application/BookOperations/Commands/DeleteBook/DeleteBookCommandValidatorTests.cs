using FluentAssertions;
using TestsSetup;
using WebApi.Application.BookOperations.Commands.CreateBookCommandValidator;
using WebApi.Application.BookOperations.DeleteBook;
using WebApi.DBOperations;
using Xunit;

namespace Application.BookOperations.Commands
{
    public class DeleteBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(-1)]
        public void WhenInvalidInputIsGiven_Validator_ShouldBeReturnErrors(int bookId)
        {
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId=bookId;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var result = validator.Validate(command);
            
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        
        [Fact]
        public void WhenValidInputGiven_Validator_ShouldNotBeReturnError()
        {
            DeleteBookCommand command= new DeleteBookCommand(null);
            command.BookId=2;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);

        }
    }
}