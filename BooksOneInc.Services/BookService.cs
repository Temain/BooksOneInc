﻿using System;
using System.Collections.Generic;
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
				Image = book.Image,
				Year = book.Year
			};

			var authors = book.Authors;
			if (!authors.Any())
			{
				throw new Exception("Необходимо указать минимум одного автора.");
			}

			var dbAuthors = new List<Author>();
			foreach (var author in authors)
			{
				dbAuthors.Add(new Author
				{
					Id = author.Id,
					Name = author.Name,
					Surname = author.Surname
				});
			}
			dbBook.Authors = dbAuthors;

			_bookRepository.Add(dbBook);

			return dbBook;
		}

		public async Task<Book> UpdateBookAsync(int id, BookView book, CancellationToken cancellationToken)
		{
			var dbBook = await _bookRepository.GetByIdAsync(id, cancellationToken);
			if (dbBook == null)
			{
				throw new ArgumentNullException(nameof(dbBook));
			}

			dbBook.Title = book.Title;
			dbBook.NumberOfPages = book.NumberOfPages;
			dbBook.Publisher = book.Publisher;
			dbBook.Year = book.Year;
			dbBook.Image = book.Image;

			var dbAuthors = dbBook.Authors;
			var authors = book.Authors;
			foreach (var author in authors)
			{

			}

			return dbBook;
		}

		public async Task<Book> DeleteBookAsync(int id, CancellationToken cancellationToken)
		{
			var dbBook = await _bookRepository.GetByIdAsync(id, cancellationToken);
			if (dbBook == null)
			{
				throw new ArgumentNullException(nameof(dbBook));
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
					Image = b.Image,
					Authors = b.Authors
						.Select(a => new AuthorView
						{
							Id = a.Id,
							Name = a.Name,
							Surname = a.Surname
						})
				});

			return query;
		}
	}
}
