using System;
using System.Linq;
using FluentValidation;
using WebApi.BookOperations.DeleteBook;

namespace WebApi.BookOperations.DeleteBookCommandValidator
{
    public class DeleteBookCommandValidator: AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator(){
            //BookId must be greater than 0
            RuleFor(command => command.BookId).GreaterThan(0);
        }

    }

}