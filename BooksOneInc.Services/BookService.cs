using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BooksOneInc.DAL.Repositories.Abstractions;
using BooksOneInc.Domain.Models;
using BooksOneInc.Services.Interfaces;
using BooksOneInc.Services.Models;

namespace BooksOneInc.Services
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

		public async Task<BookView> GetBook(int id, CancellationToken cancellationToken)
		{
			return await GetBooksQuery()
				.SingleOrDefaultAsync(b => b.Id == id);
		}

		public async Task<Book> AddBookAsync(BookView book, CancellationToken cancellationToken)
		{
			var count = await _bookRepository.GetAll()
				.CountAsync(cancellationToken);
			var dbBook = new Book
			{
				Id = count + 1, 
				Title = book.Title,
				NumberOfPages = book.NumberOfPages,
				Publisher = book.Publisher,
				ImagePath = book.ImagePath,
				Year = book.Year
			};

			//var authors = book.Authors;
			//if (!authors.Any())
			//{
			//	throw new Exception("Необходимо указать минимум одного автора.");
			//}

			_bookRepository.Add(dbBook);

			return dbBook;
		}

		public async Task<Book> UpdateBookAsync(int id, BookView book, CancellationToken cancellationToken)
		{
			var dbBook = await _bookRepository.GetByIdAsync(id, cancellationToken);
			if (dbBook == null)
			{

			}

			dbBook.Title = book.Title;
			dbBook.NumberOfPages = book.NumberOfPages;
			dbBook.Publisher = book.Publisher;
			dbBook.Year = book.Year;
			dbBook.ImagePath = book.ImagePath;

			return dbBook;
		}

		public async Task<Book> DeleteBookAsync(int id, CancellationToken cancellationToken)
		{
			var dbBook = await _bookRepository.GetByIdAsync(id, cancellationToken);
			if (dbBook == null)
			{

			}

			_bookRepository.Remove(dbBook);

			return dbBook;
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
