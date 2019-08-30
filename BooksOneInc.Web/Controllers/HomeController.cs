using System.Web.Mvc;

namespace BooksOneInc.Web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}