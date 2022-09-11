using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi.Application.BookOperations.Commands.CreateBookCommand;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;
using static WebApi.Application.BookOperations.Commands.CreateBookCommand.CreateBookCommand;

namespace Application.BookOperations.Commands
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
            _mapper= testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var book = new Book(){Title="Test_WhenAlreadyBookTitleIsGiven_InvalidOperationException_ShouldBeReturn",PageCount=100,PublishDate=new System.DateTime(1990,05,05), GenreId=1,AuthorId=1};
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            command.Model = new CreateBookModel(){Title = book.Title};

            //act and assert
            FluentActions.Invoking(()=> command.Handle())
            .Should()
            .Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten var");
            

        }
        [Fact]
        public void WhenValidInputsIsGiven_Book_ShouldBeCreated()
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            var model= new CreateBookModel()
            {
                Title="Hobbit",
                PageCount=250,
                PublishDate=DateTime.Now.Date.AddYears(-2),
                GenreId=1,
                AuthorId=1
            };
            command.Model=model;

            FluentActions.Invoking(()=> command.Handle()).Invoke();
            
            var book = _context.Books.SingleOrDefault(x=>x.Title==model.Title);
            book.Should().NotBeNull();

            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreId.Should().Be(model.GenreId);
            book.AuthorId.Should().Be(model.AuthorId);
        }

    }
}