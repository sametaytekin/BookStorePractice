using System;
using System.Linq;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand(BookStoreDbContext dbContext ){
            _dbContext= dbContext;
        }

        public BookUpdateViewModel Model { get; set; }

        public void Handle(){
            var updatedBook = _dbContext.Books.SingleOrDefault(x=>x.Title ==  Model.Title);

            if( updatedBook is null){
                throw new InvalidOperationException();
            }

            updatedBook.Title= updatedBook != default ? Model.Title : updatedBook.Title;
            updatedBook.PageCount= updatedBook != default ? Model.PageCount : updatedBook.PageCount;
            updatedBook.PublishDate= updatedBook != default ? Model.PublishDate : updatedBook.PublishDate;
            updatedBook.GenreId= updatedBook.GenreId != default ? Model.GenreId : updatedBook.GenreId;

            _dbContext.SaveChanges();
        }

    }

    public class BookUpdateViewModel
    {
        public string Title { get; set; }

        public int GenreId { get; set; }
        public int PageCount { get; set; }

        public DateTime PublishDate { get; set; }
        
    }
    
}