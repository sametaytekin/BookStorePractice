using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public UpdateBookCommand(IBookStoreDbContext dbContext ){
            _dbContext= dbContext;
        }

        public int BookId { get; set; }

        public BookUpdateViewModel Model { get; set; }

        public void Handle(){
            var updatedBook = _dbContext.Books.SingleOrDefault(x=>x.Id == BookId);

            if( updatedBook is null){
                throw new InvalidOperationException("Kitap Bulunamad─▒");
            }

            updatedBook.Title= Model.Title != default ? Model.Title : updatedBook.Title;

            updatedBook.GenreId= Model.GenreId != default ? Model.GenreId : updatedBook.GenreId;

            updatedBook.AuthorId= Model.AuthorId != default ? Model.AuthorId : updatedBook.AuthorId;

            _dbContext.SaveChanges();
        }

    }

    public class BookUpdateViewModel
    {
        public string Title { get; set; }

        public int GenreId { get; set; }

        public int AuthorId { get; set; }
        
    }
    
}