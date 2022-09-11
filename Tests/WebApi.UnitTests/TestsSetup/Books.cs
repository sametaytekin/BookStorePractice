using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestsSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange( 
                 new Book{
                Title="Lean Startup",
                GenreId=1,  //Kişisel gelişim
                PageCount=200,
                PublishDate = new DateTime(2002,06,12),
                AuthorId=3

                },

                new Book{
                Title="İyi hissetmek",
                GenreId=2,
                PageCount=500,
                PublishDate=new DateTime(2000,02,25),
                AuthorId=2
                },

                new Book{
                Title="Dune",
                GenreId=2,
                PageCount=520,
                PublishDate=new DateTime(2001,05,15),
                AuthorId=1
                }
            );
        }
    }
    
}