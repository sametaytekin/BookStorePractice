using System;
using FluentAssertions;
using TestsSetup;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Queries.CreateAuthor;
using Xunit;

namespace Application.AuthorOperations.Commands
{
    public class CreateAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(" "," ")]
        [InlineData(" ","Kaya")]
        [InlineData("Marcus"," ")]
        [InlineData("Mar","Aurelius")]
        [InlineData("Marcus","Aur")]
        public void WhenInvalidAuthorInputIsGiven_Validator_ShouldBeReturnErrors(string name,string surname)
        {
            CreateAuthorCommand commmand = new CreateAuthorCommand(null,null);
            commmand.ModelAuthor= new CreateAuthorModel()
            {
                Name=name,
                Surname=surname
            };

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var result = validator.Validate(commmand);

            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenAuthorDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            //arrange
            CreateAuthorCommand command = new CreateAuthorCommand(null,null);
            command.ModelAuthor= new CreateAuthorModel()
            {
                Name="Marcus",
                Surname="Aurelius",
                Birthday= DateTime.Now.Date
            };

            //act
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var result = validator.Validate(command);
            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }
        [Fact]
        public void WhenValidAuthorInputsIsGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
            CreateAuthorCommand command = new CreateAuthorCommand(null,null);
            command.ModelAuthor= new CreateAuthorModel()
            {
                Name="Marcus",
                Surname="Aurelius",
                Birthday=new DateTime(80,05,05)
            };

            //act
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            var result = validator.Validate(command);
            
            //assert
            result.Errors.Count.Should().Equals(0);
        }
    }
}