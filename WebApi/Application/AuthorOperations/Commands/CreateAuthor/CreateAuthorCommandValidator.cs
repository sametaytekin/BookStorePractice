using System;
using FluentValidation;

namespace WebApi.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            //Not empty kaldırılabilir
            RuleFor(command=>command.ModelAuthor.Name).NotEmpty().MinimumLength(4);
            RuleFor(command=> command.ModelAuthor.Surname).NotEmpty().MinimumLength(4);
            RuleFor(command=> command.ModelAuthor.Birthday.Date).LessThan(DateTime.Now.Date);
        }

    }
}