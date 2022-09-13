using System;
using System.Linq;
using FluentAssertions;
using TestsSetup;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Application.BookOperations.Commands
{
    public class UpdateBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
        }
        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(100)]
        public void WhenBookIsNotFound_InvalidOperationException_ShouldBeReturn(int bookId)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId=bookId;

            FluentActions.Invoking(() => command.Handle()).Should()
            .Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Bulunamadı");


        }

        [Fact]
        public void WhenValidInputsGiven_Book_ShouldBeUpdated()
        {   
            var bookDb = new Book()
            {   
                Title="Incognito",
                GenreId=2,
                AuthorId=2,
                PageCount=300,
                PublishDate=DateTime.Now.Date.AddYears(-1)
            };

            _context.Books.Add(bookDb);;
            _context.SaveChanges();

            UpdateBookCommand command = new UpdateBookCommand(_context);
            var model = new BookUpdateViewModel()
            {
                Title="ModelTitle",
                GenreId=3,
                AuthorId=1
            };
            command.BookId=1;
            command.Model=model;

            FluentActions.Invoking(()=>command.Handle()).Invoke();
            var book= _context.Books.SingleOrDefault(x=>x.Id==1);
            book.Should().NotBeNull();

            book.Title.Should().Be(model.Title);
            book.GenreId.Should().Be(model.GenreId);
            book.AuthorId.Should().Be(model.AuthorId);

        }

    }
    
}