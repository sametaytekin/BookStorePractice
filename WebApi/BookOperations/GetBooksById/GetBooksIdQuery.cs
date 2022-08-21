using System.Collections.Generic;
using System.Linq;
using System;
using WebApi.Common;
using WebApi;
using AutoMapper;

namespace WebApi.BookOperations.GetBooksById
{
    public class GetBooksById
    {
        private readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetBooksById(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int BookId { get; set; }

        public BooksViewModelById Handle(){
            var book = _dbContext.Books.Where(x=>x.Id == BookId ).SingleOrDefault();

            if (book is null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı");
            }
            BooksViewModelById bookById = _mapper.Map<BooksViewModelById>(book);
        
            
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