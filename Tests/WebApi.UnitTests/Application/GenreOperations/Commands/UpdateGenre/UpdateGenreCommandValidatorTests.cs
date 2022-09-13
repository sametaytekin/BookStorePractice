using FluentAssertions;
using TestsSetup;
using WebApi.GenreOperations.UpdateGenre;
using Xunit;

namespace Application.GenreOperations.Commands
{
    public class UpdateGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("AMD")]
        [InlineData("Int")]
        public void WhenInvalidGenreInputsGiven_Validator_ShouldBeReturnError(string name)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.GenreId=1;
            var model = new UpdateGenreModel(){Name=name,isActive=true};
            command.Model=model;

            UpdateGenreCommandValidator validator= new UpdateGenreCommandValidator();
            var result = validator.Validate(command);
                        
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsGiven_Validator_ShouldNotReturnErrors()
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.GenreId=1;
            var model= new UpdateGenreModel(){ Name="Tarih",isActive=true};
            command.Model=model;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);

        }
    }
}