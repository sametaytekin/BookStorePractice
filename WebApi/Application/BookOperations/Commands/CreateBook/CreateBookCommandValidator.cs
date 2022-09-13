using System;
using FluentValidation;
using WebApi.BookOperations.CreateBook;

namespace WebApi.BookOperations.CreateBookCommandValidator

{
    public class CreateBookCommandValidator:AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            //Validation rules for createbook
            RuleFor(command=>command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command=>command.Model.Title).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);

        }
    }
    
}