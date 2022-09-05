using System;
using System.Linq;
using FluentValidation;
using WebApi.Application.BookOperations.DeleteBook;

namespace WebApi.Application.BookOperations.Commands.CreateBookCommandValidator
{
    public class DeleteBookCommandValidator: AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator(){
            //BookId must be greater than 0
            RuleFor(command => command.BookId).GreaterThan(0);
        }

    }

}