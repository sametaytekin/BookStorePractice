using System;
using FluentAssertions;
using TestsSetup;
using WebApi.Application.GenreOperations.UpdateGenre;
using WebApi.DBOperations;
using Xunit;

namespace Application.GenreOperations.Commands
{
    public class UpdateGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        
        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
        }

        [Theory]
        [InlineData(15)]
        [InlineData(25)]
        [InlineData(35)]
        public void WhenInvalidGenreIdIsGiven_InvalidOperationException_ShouldBeReturn(int id)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId= id;

            FluentActions.Invoking(()=>command.Handle()).Should()
            .Throw<InvalidOperationException>().And.Message.Should().Be("Genre bulunamadı");
        }

        [Theory]
        [InlineData("Romance",1)]
        [InlineData("Science Fiction",3)]
        public void WhenGivenNameIsDouble_InvalidOperationException_ShouldBeReturn(string name,int id)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId=id;
            UpdateGenreModel model= new UpdateGenreModel(){isActive=true,Name=name};
            command.Model=model;
            
            FluentActions.Invoking( ()=> command.Handle()).Should()
            .Throw<InvalidOperationException>().And.Message.Should().Be("Aynı isimde zaten bir kitap türü mevcut");

        }
    }
}