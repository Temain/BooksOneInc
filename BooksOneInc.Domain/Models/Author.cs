using BooksOneInc.Domain.Interfaces;

namespace BooksOneInc.Domain.Models
{
	/// <summary>
	/// Автор.
	/// </summary>
	public class Author : IEntity
	{
		/// <summary>
		/// Идентфиикатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Имя.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Фамилия.
		/// </summary>
		public string Surname { get; set; }
	}
}
