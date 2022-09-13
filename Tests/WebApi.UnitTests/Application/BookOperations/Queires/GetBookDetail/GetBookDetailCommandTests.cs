using System;
using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi.BookOperations.GetBooksById;
using WebApi.DBOperations;
using Xunit;

namespace Application.BookOperations.Queries
{
    public class GetBookDetailCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookDetailCommandTests(CommonTestFixture testFixture)
        {
            _context =testFixture.Context;
            _mapper=testFixture.Mapper;
        }

        [Fact]
        public void WhenBookIsInvalid_InvalidOperationException_ShouldBeReturn()
        {   
            GetBooksById command = new GetBooksById(_context,_mapper);
            command.BookId=30;

            FluentActions.Invoking( ()=>command.Handle() ).Should()
            .Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Bulunamadı");

        }

    }
}