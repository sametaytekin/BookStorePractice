using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public readonly IBookStoreDbContext _context;
        public readonly IMapper _mapper;

        public DeleteAuthorCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int AuthorId { get; set; }

        public void Handle()
        {
            var deleteAuthor = _context.Authors.Include(entity=>entity.Books).SingleOrDefault(x=>x.Id==AuthorId);
            
            if(deleteAuthor is null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");
            }

            if(deleteAuthor.Books.Any())
            {
                throw new InvalidOperationException("Yazarın yayında kitabı bulunmaktadır.");
            }

            _context.Authors.Remove(deleteAuthor);
            _context.SaveChanges();

        }
    }
}