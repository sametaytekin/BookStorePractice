using FluentValidation;

namespace WebApi.GenreOperations.GetGenreDetail
{
    public class GetGenreDetailQueryValidator: AbstractValidator<GetGenreDetailQuery>
    {
       public GetGenreDetailQueryValidator()
        {
            RuleFor(query=>query.GenreId).GreaterThan(0);
       }
    }
    
}