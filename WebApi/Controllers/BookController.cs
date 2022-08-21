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

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase{
        // private static List<Book> BookList = new List<Book>(){
        //     new Book{
        //         Id=1,
        //         Title="Lean Startup",
        //         GenreId=1,  //Kişisel gelişim
        //         PageCount=200,
        //         PublishDate = new DateTime(2002,06,12)

        //     },

        //     new Book{
        //         Id=2,
        //         Title="İyi hissetmek",
        //         GenreId=2,
        //         PageCount=500,
        //         PublishDate=new DateTime(2000,02,25)
        //     },

        //     new Book{
        //         Id=3,
        //         Title="Dune",
        //         GenreId=5,
        //         PageCount=520,
        //         PublishDate=new DateTime(2001,05,15)
        //     }
        // };

        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context){
            _context =context;
        }
        
    
        [HttpGet]
        public IActionResult GetBooks(){
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]    
        public IActionResult GetById(int id){
            BooksViewModelById result;
            try
            {
                GetBooksById query = new GetBooksById(_context);
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
            CreateBookCommand command = new CreateBookCommand(_context);

            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (InvalidOperationException e)
            {
                
                return BadRequest(e.Message);
            }
            command.Handle();


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