using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BookOperations.Queries.GetBooksQuery;
using WebApi.Application.BookOperations.Commands.CreateBookCommand;
using WebApi.Application.BookOperations.Queries.GetBooksById;

using AutoMapper;
using FluentValidation;
using static WebApi.Application.BookOperations.Commands.CreateBookCommand.CreateBookCommand;
using WebApi.Application.BookOperations.Command.CreateBookCommandValidator;
using WebApi.Application.BookOperations.DeleteBook;
using WebApi.Application.BookOperations.Commands.CreateBookCommandValidator;
using WebApi.Application.BookOperations.Commands.UpdateBook;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {


        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BooksViewModelById result;

            GetBooksById query = new GetBooksById(_context, _mapper);
            query.BookId = id;
            GetBooksByIdValidator idValidator = new GetBooksByIdValidator();
            idValidator.ValidateAndThrow(query);
            result = query.Handle();
            

            return Ok(result);
        }
        /*
        [HttpGet]
        public Book Get([FromQuery] string id){
            var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();

            return book;
        }*/

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
          
            command.Model = newBook;
            //Validation comes first
            CreateBookCommandValidator addValidator = new CreateBookCommandValidator();
            addValidator.ValidateAndThrow(command);

            command.Handle();
            

            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookUpdateViewModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);

            command.BookId = id;
            command.Model = updatedBook;
            UpdateBookCommandValidator updateValidator = new UpdateBookCommandValidator();
            updateValidator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {            
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;
            DeleteBookCommandValidator deleteValidator = new DeleteBookCommandValidator();
            deleteValidator.ValidateAndThrow(command);

            command.Handle();
            
            return Ok();
        }

    }


}