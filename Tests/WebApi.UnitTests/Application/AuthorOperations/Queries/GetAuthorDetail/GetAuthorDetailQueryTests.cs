using System;
using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi.AuthorOperations.GetAuthorDetailQuery;
using WebApi.DBOperations;
using Xunit;

namespace Application.AuthorOperations.Queries
{
    public class GetAuthorDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorDetailQueryTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
            _mapper=testFixture.Mapper;
        }
        [Fact]
        public void WhenAuthorGetInpuIsInvalid_InvalidOperationException_ShouldBeReturn()
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context,_mapper);
            //Currently this does not exist
            query.AuthorId=100;

            FluentActions.Invoking(()=> query.Handle()).Should()
            .Throw<InvalidOperationException>().And.Message.Should().Be("Yazar Bulunamadı");

        }
    }
}