using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BooksOneInc.Domain.Models;
using BooksOneInc.Service.Abstractions.Services.Models;

namespace BooksOneInc.Service.Abstractions.Services
{
	public interface IBookService
	{
		IQueryable<BookView> GetBooks(Expression<Func<BookView, bool>> expr = null);

		Task<BookView> GetBook(int id, CancellationToken cancellationToken);

		Task<Book> AddBookAsync(BookView book, CancellationToken cancellationToken);

		Task<Book> UpdateBookAsync(BookView book, CancellationToken cancellationToken);

		Task<Book> DeleteBookAsync(int id, CancellationToken cancellationToken);
	}
}
