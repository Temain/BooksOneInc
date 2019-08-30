using BooksOneInc.Domain.Models;
using BooksOneInc.Service;
using BooksOneInc.Service.Abstractions;
using BooksOneInc.Service.Realizations;
using Ninject.Modules;

namespace BooksOneInc.Web.App_Start
{
	public class NinjectRegistrations : NinjectModule
	{
		public override void Load()
		{
			// Repositories
			Bind<IRepository<Book>>().To<BookRepository>();

			// Services
			Bind<IBookService>().To<BookService>();
		}
	}
}