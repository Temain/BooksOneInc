using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using BooksOneInc.Service.Abstractions.Services;
using BooksOneInc.Service.Abstractions.Services.Models;

namespace BooksOneInc.Web.Controllers
{
	public class BooksController : ApiController
	{
		private readonly IBookService _bookService;

		public BooksController(IBookService bookService)
		{
			_bookService = bookService;
		}

		public async Task<IEnumerable<BookView>> GetBooks(CancellationToken cancellationToken)
		{
			var books = await _bookService.GetBooks()
				.ToListAsync(cancellationToken);

			return books;
		}
	}
}