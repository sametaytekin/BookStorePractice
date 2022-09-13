using FluentAssertions;
using TestsSetup;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.UpdateBookValidator;
using Xunit;

namespace Application.BookOperations.Commands
{
    public class UpdateBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {        
        [Theory]
        [InlineData("Hobbit",0,0)]
        [InlineData("Hobbit",0,1)]
        [InlineData("Hobbit",1,0)]
        [InlineData("Hob",1,1)]
        [InlineData("Hob",1,0)]
        [InlineData("Hob",0,1)]
        public void WhenInvalidInputIsGiven_Validator_ShouldBeReturnErrors(string title,int authorId,int genreId)
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            var model =new BookUpdateViewModel()
            {
                Title=title,
                GenreId=genreId,
                AuthorId=authorId
            };
            command.Model=model;
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidInputsGiven_Validator_ShouldNotReturnErrors()
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            var model = new BookUpdateViewModel()
            {
                Title="Hobbit",
                GenreId=2,
                AuthorId=2
            };
            command.Model=model;

            UpdateBookCommandValidator validator =new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);

        }

    }
}