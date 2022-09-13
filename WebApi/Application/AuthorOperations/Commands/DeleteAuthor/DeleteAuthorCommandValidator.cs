using FluentValidation;

namespace WebApi.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(x=>x.AuthorId).GreaterThan(0);
        }
    }
}