using BooksOneInc.Domain.Models;
using BooksOneInc.Service.Abstractions;
using System.Collections.Generic;

namespace BooksOneInc.Service.Realizations
{
	public class BookRepository : InMemoryRepository<Book>
	{
		public BookRepository()
		{
			var books = new List<Book>
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
				new Book {
					Id = 2,
					Title = "Паттерны проектирования",
					NumberOfPages = 645,
					Publisher = "Питер",
					Year = 2017,
					Authors = new List<Author>
					{
						new Author { Id = 2, Name = "Эрик", Surname = "Фримен" },
						new Author { Id = 3, Name = "Элизабет", Surname = "Фримен" }
					}
				}
			};

			_context = new AsyncEnumerable<Book>(books);
		}
	}
}
