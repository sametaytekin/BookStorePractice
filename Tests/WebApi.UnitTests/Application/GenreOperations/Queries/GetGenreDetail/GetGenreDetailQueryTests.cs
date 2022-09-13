using System;
using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.DBOperations;
using Xunit;

namespace Application.GenreOperations.Queries
{
    public class GetGenreDetailCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreDetailCommandTests(CommonTestFixture testFixture)
        {
            _context =testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenGenreIdIsInvalid_InvalidOperationException_ShouldBeReturn()
        {   
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
            query.GenreId=10;

            FluentActions.Invoking(()=> query.Handle()).Should()
            .Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü bulunamadı");

        }
    }

}