using FluentAssertions;
using TestsSetup;
using WebApi.Application.GenreOperations.DeleteGenre;
using Xunit;

namespace Application.GenreOperations.Commands
{
    public class DeleteGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {   
         public DeleteGenreCommandValidatorTests()
        {
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void WhenInvalidGenreIdIsGiven_Validator_ShouldBeReturnErrors(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.GenreId=id;

            DeleteGenreCommandValidator validator= new DeleteGenreCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidGenreIdIsGiven_Validator_ShouldNotReturnError()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.GenreId=1;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Equals(0);
        }


    }
}