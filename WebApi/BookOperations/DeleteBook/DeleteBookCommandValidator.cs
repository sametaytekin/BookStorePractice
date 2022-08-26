using System;
using System.Linq;
using FluentValidation;
using WebApi.DBOperations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidator: AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator(){
            //BookId must be greater than 0
            RuleFor(command => command.BookId).GreaterThan(0);
        }

    }

}