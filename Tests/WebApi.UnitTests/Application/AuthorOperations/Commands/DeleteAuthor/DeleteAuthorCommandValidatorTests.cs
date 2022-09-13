using FluentAssertions;
using TestsSetup;
using WebApi.AuthorOperations.DeleteAuthor;
using Xunit;

namespace Application.AuthorOperations.Commands
{
    public class DeleteAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenAuthorIdIsInvalid_Validator_ShouldBeReturnError(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(null,null);
            command.AuthorId=id;

            DeleteAuthorCommandValidator validator =new DeleteAuthorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}