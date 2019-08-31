using System.ComponentModel.DataAnnotations;

namespace BooksOneInc.Services.Models
{
	/// <summary>
	/// Автор.
	/// </summary>
	public class AuthorView
	{
		/// <summary>
		/// Идентфиикатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Имя.
		/// </summary>
		[Required(ErrorMessage = "Необходимо указать имя автора.")]
		[MaxLength(20, ErrorMessage = "Имя автора должно быть не более 20 символов.")]
		public string Name { get; set; }

		/// <summary>
		/// Фамилия.
		/// </summary>
		[Required(ErrorMessage = "Необходимо указать фамилию автора.")]
		[MaxLength(20, ErrorMessage = "Фамилия автора должна быть не более 20 символов.")]
		public string Surname { get; set; }
	}
}
