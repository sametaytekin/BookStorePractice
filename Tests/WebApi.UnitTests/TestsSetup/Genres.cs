using WebApi.DBOperations;
using WebApi.Entities;

namespace TestsSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
            context.Genres.AddRange(
                    new Genre{
                        Name="Personal Growth",
                        isActive=true
                    },
                    new Genre{
                        Name="Science Fiction",
                        isActive=true
                    },

                    new Genre{
                        Name="Romance",
                        isActive=true
                    }
                );

        }
    }
    
}