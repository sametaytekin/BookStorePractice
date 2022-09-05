using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi
{
    public class BookStoreDbContext : DbContext{
        public BookStoreDbContext( DbContextOptions<BookStoreDbContext> options) : base(options)
        {}
        public DbSet<Book> Books {get;set;}
        
    }
}