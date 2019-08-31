using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using BooksOneInc.Services.Interfaces;
using BooksOneInc.Services.Models;

namespace BooksOneInc.Web.Controllers
{
	[RoutePrefix("api/Books")]
	public class BooksController : ApiController
	{
		private readonly IBookService _bookService;

		public BooksController(IBookService bookService)
		{
			_bookService = bookService;
		}

		// GET: api/Books
		[HttpGet]
		[Route("")]
		public async Task<IEnumerable<BookView>> GetBooks(CancellationToken cancellationToken)
		{
			var books = await _bookService.GetBooks()
				.ToListAsync(cancellationToken);

			return books;
		}

		// GET: api/Books/5
		[HttpGet]
		[Route("{id:int}")]
		public async Task<IHttpActionResult> GetBook(int id, CancellationToken cancellationToken)
		{
			var book = await _bookService.GetBooks(a => a.Id == id)
				.SingleOrDefaultAsync(cancellationToken);
			if (book == null)
			{
				return NotFound();
			}

			return Ok(book);
		}

		// POST: api/Books/
		[Route("")]
		public async Task<IHttpActionResult> PostBook([FromBody]BookView book, CancellationToken cancellationToken)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var saved = await _bookService.AddBookAsync(book, cancellationToken);

			return CreatedAtRoute("DefaultApi", new { id = saved.Id }, saved);
		}

		// PUT: api/Books/2
		[Route("{id:int}")]
		public async Task<IHttpActionResult> PutBook(int id, [FromBody]BookView book, CancellationToken cancellationToken)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != book.Id)
			{
				return BadRequest();
			}

			await _bookService.UpdateBookAsync(id, book, cancellationToken);

			return StatusCode(HttpStatusCode.NoContent);
		}

		// DELETE: api/Books/2
		[Route("{id:int}")]
		public async Task<IHttpActionResult> DeleteBook(int id, CancellationToken cancellationToken)
		{
			var book = await _bookService.GetBook(id, cancellationToken);
			if (book == null)
			{
				return NotFound();
			}

			await _bookService.DeleteBookAsync(id, cancellationToken);

			return Ok(book);
		}
	}
}