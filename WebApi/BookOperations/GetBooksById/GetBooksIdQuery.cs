using System.Collections.Generic;
using System.Linq;
using WebApi.Common;

namespace WebApi.BookOperations.GetBooksById
{
    public class GetBooksById
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksById(BookStoreDbContext dbContext ){
            _dbContext= dbContext;
        }

        public BooksViewModelById Handle(int id){
            var bookList = _dbContext.Books.Where(x=>x.Id == id ).SingleOrDefault();
            BooksViewModelById bookById = new BooksViewModelById{
                PageCount=bookList.PageCount,
                PublishDate=bookList.PublishDate.Date.ToString("dd/MM/yyy"),
                Genre= ((GenreEnum)bookList.GenreId).ToString(),
                Title=bookList.Title
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