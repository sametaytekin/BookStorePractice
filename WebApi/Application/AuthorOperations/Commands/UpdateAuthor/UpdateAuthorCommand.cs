using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {   
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public UpdateAuthorCommand(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public int AuthorId { get; set; }
        public UpdateAuthorModel Model { get; set; }
        public void Handle()
        {
            var updateAuthor = _context.Authors.SingleOrDefault(x=> x.Id == AuthorId);
            if(updateAuthor is null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");
            }
            if(_context.Authors.Any(x=> x.Name.ToLower() == Model.Name.ToLower() && x.Id != AuthorId))
            {
                throw new InvalidOperationException("Yazar mevcut");
            }
            updateAuthor.Name = string.IsNullOrEmpty( Model.Name) ? updateAuthor.Name : Model.Name;
            
            updateAuthor.Surname= string.IsNullOrEmpty(Model.Surname) ? updateAuthor.Surname : updateAuthor.Surname;
            
            updateAuthor.Birthday= Model.Birthday.Date != default ? Model.Birthday.Date : updateAuthor.Birthday.Date;
            _context.SaveChanges();

        }
    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}