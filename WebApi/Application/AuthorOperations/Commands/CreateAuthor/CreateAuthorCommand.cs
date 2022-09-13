using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public readonly IBookStoreDbContext _context;
        public readonly IMapper _mapper;

        public CreateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public CreateAuthorModel ModelAuthor { get; set; }

        public void Handle()
        {
            var author= _context.Authors.SingleOrDefault(x=>x.Name == ModelAuthor.Name);
            if(author is not null){
                throw new InvalidOperationException("Yazar zaten var");
            }

            var createAuthor = _mapper.Map<Author>(ModelAuthor);
            _context.Authors.Add(createAuthor);
            _context.SaveChanges();

        }
    }


    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
    
}