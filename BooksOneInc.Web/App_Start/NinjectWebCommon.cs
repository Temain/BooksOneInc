using Ninject.Web.Common.WebHost;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BooksOneInc.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BooksOneInc.Web.App_Start.NinjectWebCommon), "Stop")]

namespace BooksOneInc.Web.App_Start
{
	using BooksOneInc.Domain.Models;
	using BooksOneInc.Service;
	using BooksOneInc.Service.Abstractions;
	using BooksOneInc.Service.Realizations;
	using Microsoft.Web.Infrastructure.DynamicModuleHelper;
	using Ninject;
	using Ninject.Web.Common;
    using Ninject.Web.WebApi;
    using System;
	using System.Web;
    using System.Web.Http;

    public static class NinjectWebCommon
	{
		private static readonly Bootstrapper bootstrapper = new Bootstrapper();

		public static void Start()
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
			bootstrapper.Initialize(CreateKernel);
		}

		public static void Stop()
		{
			bootstrapper.ShutDown();
		}

		private static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			try
			{
				kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
				kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

				RegisterServicesStatic(kernel);
				RegisterModules(kernel);
				RegisterFiltersStatic(kernel);

				GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
				return kernel;
			}
			catch
			{
				kernel.Dispose();
				throw;
			}
		}

		private static void RegisterServicesStatic(IKernel kernel)
		{
			// Repositories
			kernel.Bind<IRepository<Book>>().To<BookRepository>();

			// Services
			kernel.Bind<IBookService>().To<BookService>();
		}

		private static void RegisterFiltersStatic(IKernel kernel) { }

		private static void RegisterModules(IKernel kernel) { }
	}
}