using System;
using FluentAssertions;
using TestsSetup;
using WebApi.Application.BookOperations.DeleteBook;
using WebApi.DBOperations;
using Xunit;

namespace Application.BookOperations.Commands
{
    public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly IBookStoreDbContext _context;
        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            _context =testFixture.Context;
        }
        [Fact]
        public void WhenBookIsNotAvailable_InvalidOperationException_ShouldBeReturn()
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId=10;

            FluentActions.Invoking(()=>command.Handle())
            .Should().Throw<InvalidOperationException>()
            .And.Message.Should().Be("Kitap Bulunamadı");
        }
    }
}