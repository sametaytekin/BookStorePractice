using FluentAssertions;
using TestsSetup;
using WebApi.Application.BookOperations.Queries.GetBooksById;
using WebApi.DBOperations;
using Xunit;

namespace Application.BookOperations.Queries
{
    public class GetBookDetailCommandValidatorTests:IClassFixture<CommonTestFixture>
    {   
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void WhenInvalidInputIsGiven_Validator_ShouldBeReturnError(int id)
        {

            GetBooksById command = new GetBooksById(null,null);
            command.BookId=id;

            GetBooksByIdValidator validator = new GetBooksByIdValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }
        [Fact]
        public void WhenValidInputIsGiven_Validator_ShouldNotBeReturnError()
        {
            GetBooksById command = new GetBooksById(null,null);
            command.BookId=1;

            GetBooksByIdValidator validator = new GetBooksByIdValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);
        }
    }
}