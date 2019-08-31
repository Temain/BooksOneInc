using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksOneInc.Services.Models
{
	public class BookView
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Заголовок.
		/// </summary>
		[Required(ErrorMessage = "Необходимо указать название книги.")]
		[MaxLength(30, ErrorMessage = "Название книги должно быть не более 30 символов.")]
		public string Title { get; set; }

		/// <summary>
		/// Количество страниц.
		/// </summary>
		[Range(1, 10000, ErrorMessage = "Количество страниц должно быть более 1 и менее 10000.")]
		public int NumberOfPages { get; set; }

		/// <summary>
		/// Наименование издательства.
		/// </summary>
		[MaxLength(30, ErrorMessage = "Название издательства должно быть не более 30 символов.")]
		public string Publisher { get; set; }

		/// <summary>
		/// Год публикации.
		/// </summary>
		[Range(1800, 2020, ErrorMessage = "Год должен быть не реньше 1800.")]
		public int Year { get; set; }

		/// <summary>
		/// Изображение.
		/// </summary>
		public string Image { get; set; }

		/// <summary>
		/// Авторы.
		/// </summary>
		public IEnumerable<AuthorView> Authors { get; set; }
	}
}
