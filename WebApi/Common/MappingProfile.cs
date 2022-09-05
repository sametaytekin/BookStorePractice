using AutoMapper;
using WebApi.Application.BookOperations.Queries.GetBooksQuery;
using WebApi.Application.BookOperations.Queries.GetBooksById;
using WebApi.Entities;
using static WebApi.Application.BookOperations.Commands.CreateBookCommand.CreateBookCommand;
using WebApi.Application.GenreOperations.Queries.GetGenres;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();

            CreateMap<Book,BooksViewModelById>().
            ForMember(dest=> dest.Genre, opt=>opt.MapFrom(src=> ((GenreEnum)src.GenreId).ToString()) );

            CreateMap<Book,BooksViewModel>()
            .ForMember(dest => dest.Genre ,opt => opt.MapFrom(src =>( (GenreEnum)src.GenreId).ToString() ) );

            CreateMap<Genre,GenresViewModel>();


        }
    }
}