using FluentAssertions;
using TestsSetup;
using WebApi.GenreOperations.CreateGenre;
using Xunit;

namespace Application.GenreOperations.Commands
{
     public class CreateGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
     {
        [Theory]
        [InlineData("Bit")]
        [InlineData("Top")]
        public void WhenInvalidInputIsGiven_Validator_ShouldReturnErrors(string name)
        {
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model= new CreateGenreModel(){Name=name,isActive=true};

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result=validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturn()
        {
            //arrange
            CreateGenreCommand command = new CreateGenreCommand( null);
            command.Model = new CreateGenreModel()
            { Name = "Biyoloji"};

            //act 
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Equals(0);
        }
     }
}