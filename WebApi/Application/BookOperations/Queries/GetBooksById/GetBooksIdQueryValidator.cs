using System;
using System.Linq;
using FluentValidation;

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