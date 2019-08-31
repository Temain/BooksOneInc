using BooksOneInc.Services.Models;
using FluentValidation;
using System.Linq;

namespace BooksOneInc.Web.Validation
{
	public class AuthorViewValidator : AbstractValidator<AuthorView>
	{
		public AuthorViewValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Необходимо указать имя автора.")
				.MaximumLength(20).WithMessage("Имя автора должно быть не более 20 символов.");

			RuleFor(x => x.Surname)
				.NotEmpty().WithMessage("Необходимо указать фамилию автора.")
				.MaximumLength(20).WithMessage("Фамилия автора должно быть не более 20 символов.");
		}
	}
}