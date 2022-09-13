using System;
using FluentAssertions;
using TestsSetup;
using WebApi.AuthorOperations.UpdateAuthor;
using Xunit;

namespace Application.AuthorOperations.Commands
{
    public class UpdateAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("David","Burns",-1)]
        [InlineData("David","Burns",0)]
        [InlineData("David"," ",1)]
        [InlineData(" ","Burns",1)]
        [InlineData("Dav","Burns",1)]
        [InlineData("David","Bur",1)]
        public void WhenInvalidAuthorInputIsGiven_Validator_ShouldBeReturnErrors(string name, string surname,int id)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null,null);
            var model = new UpdateAuthorModel()
            {
                Name=name,
                Surname=surname,
                Birthday= new DateTime(1970,05,05)
            };

            command.Model= model;
            command.AuthorId=id;

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var result = validator.Validate(command);
        }

        [Fact]
        public void WhenValidAuthorInputsGiven_Validator_ShouldNotReturnError()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(null,null);
            command.Model= new UpdateAuthorModel()
            {
                Name="David",
                Surname="Burns",
                Birthday=new DateTime(1970,05,05)
            };

            command.AuthorId= 2;

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);
        }
    }

}