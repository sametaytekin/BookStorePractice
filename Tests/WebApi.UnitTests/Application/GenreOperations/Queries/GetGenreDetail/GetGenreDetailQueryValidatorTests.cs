using FluentAssertions;
using TestsSetup;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using Xunit;

namespace Application.GenreOperations.Queries
{
    public class GetGenreDetailQueryValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputIsGiven_Validator_ShouldBeReturnErrors()
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(null,null);
            query.GenreId=0;

            GetGenreDetailQueryValidator validator=new GetGenreDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);


        }

        [Fact]
        public void WhenValidInputIsGiven_Validator_ShouldNotBeReturnError()
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(null,null);
            query.GenreId=2;

            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();

            var result =validator.Validate(query);

            result.Errors.Count.Should().Equals(0);
        }
    }
}