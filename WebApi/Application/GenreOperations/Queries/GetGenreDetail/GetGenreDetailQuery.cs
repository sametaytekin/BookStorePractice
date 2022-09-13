using System.Collections.Generic;
using System.Linq;
using System;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.GenreOperations.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public readonly IBookStoreDbContext _context;
        public readonly IMapper _mapper;
        
        public int GenreId { get; set; }

        public GetGenreDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle(){
            var genres= _context.Genres.SingleOrDefault(x=>x.isActive && x.Id == GenreId);
            if(genres is null){
                throw new InvalidOperationException("Kitap türü bulunamadı");
            }
            return  _mapper.Map<GenreDetailViewModel>(genres);
        }

    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}