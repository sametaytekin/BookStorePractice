using System.Linq;
using WebApi.DBOperations;
using System.Collections.Generic;
using WebApi.Common;
using AutoMapper;
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle(){
            var bookList = _dbContext.Books.Include(e=>e.Author).Include(entity=>entity.Genre).OrderBy(x=>x.Id).ToList<Book>();
            List<BooksViewModel> viewModelBook = new List<BooksViewModel>();
            viewModelBook = _mapper.Map<List<BooksViewModel>>(bookList);

            return viewModelBook;
        }

    }

    public class BooksViewModel{
        public string Title { get; set; }

        public int PageCount { get; set; }

        public string PublishDate { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }
    }
    
}