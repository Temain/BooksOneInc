using BooksOneInc.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace BooksOneInc.Domain.Models
{
	/// <summary>
	/// Книга.
	/// </summary>
	public class Book : IEntity
	{
		public Book()
		{
			Authors = new List<Author>();
		}

		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Количество страниц.
		/// </summary>
		public int NumberOfPages { get; set; }

		/// <summary>
		/// Наименование издательства.
		/// </summary>
		public string Publisher { get; set; }

		/// <summary>
		/// Год публикации.
		/// </summary>
		public int Year { get; set; }

		/// <summary>
		/// Изображение.
		/// </summary>
		public string Image { get; set; }

		/// <summary>
		/// Список авторов.
		/// </summary>
		public IEnumerable<Author> Authors { get; set; }
	}
}
