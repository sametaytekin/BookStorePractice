using System;
using FluentAssertions;
using TestsSetup;
using WebApi.Application.BookOperations.Command.CreateBookCommandValidator;
using WebApi.Application.BookOperations.Commands.CreateBookCommand;
using Xunit;
using static WebApi.Application.BookOperations.Commands.CreateBookCommand.CreateBookCommand;

namespace Application.BookOperations.Commands
{
    public class CreateBookCommandTestsValidator : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData("Lord of the Rings", 0, 0)]
        [InlineData("Lord of the Rings", 0, 1)]
        [InlineData("", 0, 0)]
        [InlineData("", 100, 1)]
        [InlineData("", 0, 1)]
        [InlineData("Lor", 100, 1)]
        [InlineData("Lor", 0, 0)]
        [InlineData("Lord", 0, 1)]
        public void WhenInvalidInputIsGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId)
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            { Title = title, PageCount = pageCount, PublishDate = DateTime.Now.Date.AddYears(-1), GenreId = genreId };

            //act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            { Title = "Lord of theRings", PageCount = 100, PublishDate =DateTime.Now.Date , GenreId = 1 };

            //act 
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturn()
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            { Title = "Lord of theRings", PageCount = 100, PublishDate =DateTime.Now.Date.AddYears(-2) , GenreId = 1 };

            //act 
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Equals(0);
        }
    }
}