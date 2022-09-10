using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public IBookStoreDbContext _context { get; set; }

        public DeleteGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public int GenreId { get; set; }
        public void Handle(){
            var genre = _context.Genres.SingleOrDefault(g => g.Id == GenreId);

            if(genre is null){
                throw new InvalidOperationException("Genre yok");
            }

            _context.Genres.Remove(genre);
            _context.SaveChanges();

        }



    }
    
}