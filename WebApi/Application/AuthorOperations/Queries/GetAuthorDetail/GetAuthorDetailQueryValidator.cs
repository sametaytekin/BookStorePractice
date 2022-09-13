using FluentValidation;

namespace WebApi.AuthorOperations.GetAuthorDetailQuery
{
    public class GetAuthorDetailQueryValidator:AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(x => x.AuthorId).GreaterThan(0);
        }
    }
    
}