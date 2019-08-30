using BooksOneInc.Domain.Models;
using BooksOneInc.Service.Abstractions;
using System.Collections.Generic;

namespace BooksOneInc.Service.Realizations
{
	public class BookRepository : InMemoryRepository<Book>
	{
		public BookRepository()
		{
			_context = new List<Book>
			{
				new Book {
					Id = 1,
					Title = "Чистый код",
					NumberOfPages = 464,
					Publisher = "Питер",
					Year = 2010,
					Authors = new List<Author>
					{
						new Author { Id = 1, Name = "Роберт", Surname = "Мартин" }
					}
				},
			};
		}
	}
}
