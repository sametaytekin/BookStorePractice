using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestsSetup;
using WebApi.AuthorOperations.CreateAuthor;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Application.AuthorOperations.Commands
{
   public class CreateAuthorCommandTests:IClassFixture<CommonTestFixture>
   {
      private readonly BookStoreDbContext _context;
      
      private readonly IMapper _mapper;
      public CreateAuthorCommandTests(CommonTestFixture testFixture)
      {
         _context=testFixture.Context;
         _mapper=testFixture.Mapper;
      }

      [Fact]
      public void WhenAlreadyAuthorNameIsGiven_InvalidOperationException_ShouldBeReturn()
      {
         var author = new Author()
         {
            Name="Nazım",
            Surname="Hikmet",
            Birthday= new DateTime(2021,05,05),
         };
         _context.Authors.Add(author);
         _context.SaveChanges();

         CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
         command.ModelAuthor = new CreateAuthorModel()
         {
            Name="Nazım",
            Surname="Hikmet",
            Birthday=new DateTime(2021,05,05)
         };
         FluentActions.Invoking(()=>command.Handle())
         .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar zaten var");

      }
      [Fact]
      public void WhenValidNameIsGiven_Author_ShouldBeCreated()
      {
         CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
         var model = new CreateAuthorModel()
         {
            Name="Cemil",
            Surname="Süreyya",
            Birthday=new DateTime(1980,05,05)
         };

         command.ModelAuthor=model;

         FluentActions.Invoking(()=>command.Handle()).Invoke();

         var author= _context.Authors.SingleOrDefault(x=>x.Name == model.Name);

         author.Surname.Should().Be(model.Surname);
         author.Birthday.Should().Be(model.Birthday);

      }

   }
}