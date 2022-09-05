using System.Collections.Generic;
using System.Linq;
using System;
using AutoMapper;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        
        public int GenreId { get; set; }

        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
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