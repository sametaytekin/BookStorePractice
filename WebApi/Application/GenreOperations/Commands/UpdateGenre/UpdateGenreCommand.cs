using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public IBookStoreDbContext _context { get; set; }
        public UpdateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }
        public int GenreId { get; set; }

        public UpdateGenreModel Model { get; set; }

        public void Handle()
        {
            var genre =_context.Genres.SingleOrDefault(x=>x.Id == GenreId);
            if(genre is null){
                throw new InvalidOperationException("Genre bulunamadı");
            }
            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId ))
            {
                throw new InvalidOperationException("Aynı isimde zaten bir kitap türü mevcut");
            }

            genre.Name=string.IsNullOrEmpty( Model.Name.Trim()) ? genre.Name: Model.Name;
            genre.isActive=Model.isActive;
            _context.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool isActive { get; set; }
    }

}