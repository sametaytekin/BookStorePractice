using System;
using System.Linq;
using FluentValidation;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooksById
{
    public class GetBooksByIdValidator : AbstractValidator<GetBooksById>
    {
        public GetBooksByIdValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
        
        
    }
}