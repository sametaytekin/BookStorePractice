using AutoMapper;
using WebApi.Entities;
using System.Linq;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using WebApi.BookOperations.GetBooksById;
using WebApi.BookOperations.GetBooks;
using WebApi.AuthorOperations.GetAuthors;
using WebApi.AuthorOperations.GetAuthorDetailQuery;
using WebApi.AuthorOperations.CreateAuthor;
using WebApi.GenreOperations.GetGenres;
using WebApi.GenreOperations.GetGenreDetail;
using WebApi.GenreOperations.CreateGenre;
using WebApi.UserOperations.CreateUser;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();

            CreateMap<Book,BooksViewModelById>().
            ForMember(dest=> dest.Genre, opt=>opt.MapFrom(src=> src.Genre.Name) )
            .ForMember(dest=>dest.Author,opt=>opt.MapFrom(src=>src.Author.Name+" "+src.Author.Surname));

            CreateMap<Book,BooksViewModel>()
            .ForMember(dest => dest.Genre ,opt => opt.MapFrom(src => src.Genre.Name ) )
            .ForMember(dest=>dest.Author, opt=>opt.MapFrom(src=>src.Author.Name+" "+src.Author.Surname));

            CreateMap<Genre,GenresViewModel>();
            CreateMap<CreateGenreModel,Genre>();
            CreateMap<Genre,GenreDetailViewModel>();

            CreateMap<Author,AuthorsViewModel>()
            .ForMember(dest=>dest.Books ,opt=>opt.MapFrom(src=>src.Books.OrderBy(x=>x.Id).Select(x=>x.Title).ToList<string>()));

            CreateMap<Author,GetAuthorDetailViewModel>()
            .ForMember(dest=>dest.Books,opt=>opt.MapFrom(src=>src.Books.OrderBy(x=>x.Id).Select(x=>x.Title).ToList<string>()));
            
            CreateMap<CreateAuthorModel,Author>();

            CreateMap<CreateUserModel,User>();


        }
    }
}