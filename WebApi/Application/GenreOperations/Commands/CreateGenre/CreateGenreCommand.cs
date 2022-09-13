using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
    {
        public readonly IBookStoreDbContext _context;

        public readonly IMapper _mapper;

        public CreateGenreModel Model; 

        public CreateGenreCommand( IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var newGenre= _context.Genres.SingleOrDefault(genre=> genre.Name == Model.Name);

            if( newGenre is not null){
                throw new InvalidOperationException("Genre zaten var");
            }

            // newGenre = _mapper.Map<Genre>(Model);
            newGenre = new Genre();
            newGenre.Name=Model.Name;

            _context.Genres.Add(newGenre);
            _context.SaveChanges();
        }

    }

    public class CreateGenreModel
    {
        public bool isActive { get; set; }

        public string Name { get; set; }
        
    }
    
}