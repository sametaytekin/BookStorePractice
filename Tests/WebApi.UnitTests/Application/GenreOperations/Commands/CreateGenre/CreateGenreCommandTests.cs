using System;
using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.GenreOperations.CreateGenre;
using Xunit;

namespace Application.GenreOperations.Commands
{
    public class CreateGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context= testFixture.Context;
            _mapper=testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyModelNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            var genre = new Genre()
            {
                Name="Şiir",
                isActive=true
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model= new CreateGenreModel(){Name=genre.Name};

            FluentActions.Invoking(()=>command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Genre zaten var");



        }

        

    }
}