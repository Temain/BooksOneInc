using BooksOneInc.Service.Abstractions;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BooksOneInc.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IBookService _bookService;

		public HomeController(IBookService bookService)
		{
			_bookService = bookService;
		}

		public async Task<ActionResult> Index(CancellationToken cancellationToken)
		{
			var books = await _bookService.GetBooks().ToListAsync(cancellationToken);

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}