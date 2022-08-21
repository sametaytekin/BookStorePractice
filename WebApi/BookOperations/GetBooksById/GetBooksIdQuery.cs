using System.Collections.Generic;
using System.Linq;
using System;
using WebApi.Common;

namespace WebApi.BookOperations.GetBooksById
{
    public class GetBooksById
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksById(BookStoreDbContext dbContext ){
            _dbContext= dbContext;
        }

        public int BookId { get; set; }

        public BooksViewModelById Handle(){
            var book = _dbContext.Books.Where(x=>x.Id == BookId ).SingleOrDefault();

            if (book is null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı");
            }
            BooksViewModelById bookById = new BooksViewModelById{
                PageCount=book.PageCount,
                PublishDate=book.PublishDate.Date.ToString("dd/MM/yyy"),
                Genre= ((GenreEnum)book.GenreId).ToString(),
                Title=book.Title
            };
            
            return bookById;


        }
        
    }

    public class BooksViewModelById
    {
        public string Title { get; set; }

        public int PageCount { get; set; }

        public string PublishDate { get; set; }

        public string Genre { get; set; }        

    }

    
    
}