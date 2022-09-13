using FluentAssertions;
using TestsSetup;
using WebApi.AuthorOperations.GetAuthorDetailQuery;
using Xunit;

namespace Application.AuthorOperations.Queries
{
    public class GetAuthorDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidAuthorInputIsGiven_Validator_ShouldBeReturnError(int id)
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(null,null);
            query.AuthorId=id;

            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
            var result=validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidAuthorInputsGiven_Validator_ShouldBeReturnError()
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(null,null);
            //Valid input
            query.AuthorId=2;

            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().Equals(0);
        }

    }
}