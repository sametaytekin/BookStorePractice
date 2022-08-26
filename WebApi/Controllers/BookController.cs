using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooksById;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.DeleteBook;
using AutoMapper;
using FluentValidation.Results;
using FluentValidation;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase{


        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetBooks(){
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]    
        public IActionResult GetById(int id){
            BooksViewModelById result;
            try
            {
                GetBooksById query = new GetBooksById(_context,_mapper);
                query.BookId=id;
                result = query.Handle();                
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }
    /*
    [HttpGet]
    public Book Get([FromQuery] string id){
        var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();

        return book;
    }*/

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook ){
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);

        try
        {
            command.Model = newBook;
            //Validation comes first
            CreateBookCommandValidator addValidator = new CreateBookCommandValidator();
            addValidator.ValidateAndThrow(command);                    

            command.Handle();
        }
        catch (InvalidOperationException e)
        {
                
            return BadRequest(e.Message);
        }


            return Ok(); 
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] BookUpdateViewModel updatedBook){

            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);

                command.BookId =id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){


            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId=id;
                command.Handle();                
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }            

            return Ok();
        }

    }


}