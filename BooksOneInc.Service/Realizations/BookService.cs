using BooksOneInc.Domain.Models;
using BooksOneInc.Service.Abstractions;
using BooksOneInc.Service.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BooksOneInc.Service
{
	public class BookService : IBookService
	{
		private readonly IRepository<Book> _bookRepository;

		public BookService(IRepository<Book> bookRepository)
		{
			_bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
		}

		public IQueryable<BookView> GetBooks(Expression<Func<BookView, bool>> expr = null)
		{
			var query = GetBooksQuery();
			if (expr != null)
			{
				query = query.Where(expr);
			}
			return query;
		}

		public Task<BookView> GetBook(int id, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<Book> AddBook(BookView book, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<Book> DeleteBook(BookView book, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<Book> UpdateBook(BookView book, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		private IQueryable<BookView> GetBooksQuery()
		{
			var query = _bookRepository.GetAll()
				.Select(b => new BookView
				{
					Id = b.Id,
					Title = b.Title,
					NumberOfPages = b.NumberOfPages,
					Publisher = b.Publisher,
					Year = b.Year,
					ImagePath = b.ImagePath
				});

			return query;
		}
	}
}
