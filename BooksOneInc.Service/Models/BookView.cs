namespace BooksOneInc.Service.Models
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
		public string ImagePath { get; set; }
	}
}
