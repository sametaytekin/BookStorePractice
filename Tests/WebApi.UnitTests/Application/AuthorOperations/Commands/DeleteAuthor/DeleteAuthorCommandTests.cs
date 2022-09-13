using System;
using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi.AuthorOperations.DeleteAuthor;
using WebApi.DBOperations;
using Xunit;

namespace Application.AuthorOperations.Commands
{
    public class DeleteAuthorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        
        private readonly IMapper _mapper;

        public DeleteAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
            _mapper=testFixture.Mapper;
        }

        [Fact]
        public void WhenAuthorIsNotAvailable_InvalidOperationException_ShouldBeReturn()
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context,_mapper);
            command.AuthorId=10;

            FluentActions.Invoking( ()=> command.Handle()).Should()
            .Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı");
        }

        [Fact]
        public void WhenAuthorHasBooks_InvalidOperationException_ShouldBeReturn()
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context,_mapper);
            command.AuthorId=1;

            FluentActions.Invoking(()=> command.Handle()).Should()
            .Throw<InvalidOperationException>().And.Message.Should().Be("Yazarın yayında kitabı bulunmaktadır.");
        }

    }
}