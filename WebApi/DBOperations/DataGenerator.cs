using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator{
        public static void Initialize(IServiceProvider serviceProvider){
            using (var context = new BookStoreDbContext(
             serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>() )) 
            {
                if( context.Books.Any()){
                    return;
                }

                context.Books.AddRange( 
                     new Book{
                Title="Lean Startup",
                GenreId=1,  //Kişisel gelişim
                PageCount=200,
                PublishDate = new DateTime(2002,06,12)

                },

                new Book{
                Title="İyi hissetmek",
                GenreId=2,
                PageCount=500,
                PublishDate=new DateTime(2000,02,25)
                },

                new Book{
                Title="Dune",
                GenreId=5,
                PageCount=520,
                PublishDate=new DateTime(2001,05,15)
                }
            );

            context.SaveChanges();
                
            }
        }
    }
}