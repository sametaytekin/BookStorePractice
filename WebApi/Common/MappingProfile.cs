using AutoMapper;
using WebApi.Application.BookOperations.Queries.GetBooksQuery;
using WebApi.Application.BookOperations.Queries.GetBooksById;
using WebApi.Entities;
using static WebApi.Application.BookOperations.Commands.CreateBookCommand.CreateBookCommand;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.CreateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.AuthorOperations.Queries.CreateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetailQuery;
using System.Linq;

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


        }
    }
}