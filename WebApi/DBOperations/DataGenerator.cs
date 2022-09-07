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

                //Authors
                context.Authors.AddRange(
                    new Author{
                        Name="Frank",
                        Surname="Herbert",
                        Birthday=new DateTime(1920,08,10)
                    },
                    new Author{
                        Name="James",
                        Surname="Clear",
                        Birthday=new DateTime(1980,06,6)
                    },
                    new Author{
                        Name="George",
                        Surname="Orwell",
                        Birthday=new DateTime(1903,04,4)
                    }
                );
                //Genres
                context.Genres.AddRange(
                    new Genre{
                        Name="Personal Growth"
                    },
                    new Genre{
                        Name="Science Fiction"
                    },

                    new Genre{
                        Name="Romance"
                    }
                );
                //Books
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