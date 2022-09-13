using System;
using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.DBOperations;
using Xunit;

namespace Application.AuthorOperations.Commands
{
    
    public class UpdateAuthorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context= testFixture.Context;
            _mapper=testFixture.Mapper;
        }

        [Fact]
        public void WhenAuthorIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_mapper,_context);
            //does not exist
            command.AuthorId=100;

            FluentActions.Invoking(()=> command.Handle()).Should()
            .Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı");
        }

        [Fact]
        public void WhenAuthorIsDouble_InvalidOperationException_ShouldBeReturn()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_mapper,_context);
            command.Model= new UpdateAuthorModel()
            {
                Name="Frank",
                Surname="Burns",
                Birthday=new DateTime(1980,05,05)
            };

            command.AuthorId=3;

            FluentActions.Invoking(()=> command.Handle()).Should()
            .Throw<InvalidOperationException>().And.Message.Should().Be("Yazar mevcut");
        }


    }
}