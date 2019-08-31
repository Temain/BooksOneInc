using BooksOneInc.Services.Models;
using FluentValidation;
using System.Linq;

namespace BooksOneInc.Web.Validation
{
	public class BookViewValidator : AbstractValidator<BookView>
	{
		public BookViewValidator()
		{
			RuleFor(x => x.Title)
				.NotEmpty().WithMessage("Необходимо указать название книги.")
				.MaximumLength(30).WithMessage("Название книги должно быть не более 30 символов.");

			RuleFor(x => x.NumberOfPages)
				.GreaterThan(0).WithMessage("Количество страниц должно быть больше 0.")
				.LessThanOrEqualTo(10000).WithMessage("Количество страниц должно быть менее или равно 10000.");

			RuleFor(x => x.Publisher)
				.MaximumLength(30).WithMessage("Название издательства должно быть не более 30 символов.");

			RuleFor(x => x.Year)
				.GreaterThanOrEqualTo(1800).WithMessage("Год публикации должен быть не раньше 1800.");

			RuleFor(x => x.Authors)
				.Must(x => x != null && x.Count() > 0).WithMessage("У книги должен быть как минимум один автор.");
		}
	}
}