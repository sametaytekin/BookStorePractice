using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.DeleteBook
{
    public class DeleteBookCommand{
        private readonly IBookStoreDbContext _dbContext;

        public DeleteBookCommand( IBookStoreDbContext dbContext){
            _dbContext = dbContext;
        }

        public int BookId { get; set; }


        public void Handle(){
            var book = _dbContext.Books.SingleOrDefault(x=> x.Id == BookId);
            if( book is null)
                throw new InvalidOperationException("Kitap Bulunamadı");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }



    }



}