using BooksOneInc.Domain.Models;
using BooksOneInc.Service.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BooksOneInc.Service.Abstractions
{
	public interface IBookService
	{
		IQueryable<BookView> GetBooks(Expression<Func<BookView, bool>> expr = null);

		Task<BookView> GetBook(int id, CancellationToken cancellationToken);

		Task<Book> AddBook(BookView book, CancellationToken cancellationToken);

		Task<Book> UpdateBook(BookView book, CancellationToken cancellationToken);

		Task<Book> DeleteBook(BookView book, CancellationToken cancellationToken);
	}
}
