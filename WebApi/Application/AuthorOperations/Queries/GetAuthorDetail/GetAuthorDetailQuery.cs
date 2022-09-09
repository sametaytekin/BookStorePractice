using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetailQuery
{
    public class GetAuthorDetailQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int AuthorId { get; set; }

        public GetAuthorDetailViewModel Handle()
        {
            var author = _context.Authors.Include(e=>e.Books).Where(x => x.Id == AuthorId).SingleOrDefault();
            if(author is null)
            {
                throw new InvalidOperationException("Yazar Bulunamadı");
            }
            
            GetAuthorDetailViewModel authorById= _mapper.Map<GetAuthorDetailViewModel>(author);

            return authorById;
        }
    }

    public class GetAuthorDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set;}
        public List<string> Books { get; set; }
        
    }
    
}