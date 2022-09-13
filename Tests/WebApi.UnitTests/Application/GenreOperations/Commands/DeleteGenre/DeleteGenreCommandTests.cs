using System;
using FluentAssertions;
using TestsSetup;
using WebApi.Application.GenreOperations.DeleteGenre;
using WebApi.DBOperations;
using Xunit;

namespace Application.GenreOperations.Commands
{
    public class DeleteGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        
        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {   
            _context=testFixture.Context;
        }

        [Fact]
        public void WhenGenreIsNotAvailable_InvalidOperationException_ShouldBeReturn()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId=25;

            FluentActions.Invoking(()=>command.Handle()).Should()
            .Throw<InvalidOperationException>().And.Message.Should().Be("Genre yok");
        }
    }
}