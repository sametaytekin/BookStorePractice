using System;
using System.Linq;
using WebApi.DBOperations;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Common;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand{
       private readonly BookStoreDbContext _dbContext;

       public CreateBookModel Model { get; set; }

        public CreateBookCommand( BookStoreDbContext context){
        _dbContext = context;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Title == Model.Title);

            if( book is not null){
                throw new InvalidOperationException();
            }

            book = new Book();
            book.Title = Model.Title;
            book.PublishDate = Model.PublishDate;
            book.PageCount = Model.PageCount;
            book.GenreId = Model.GenreId;

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();


        }

        public class CreateBookModel{
            public string Title { get; set; }

            public int GenreId { get; set; }
            public int PageCount { get; set; }

            public DateTime PublishDate { get; set; }


        }

    }
}
