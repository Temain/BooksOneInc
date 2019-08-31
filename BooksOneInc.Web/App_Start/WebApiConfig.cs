using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BooksOneInc.Web.App_Start;
using FluentValidation.WebApi;

namespace BooksOneInc.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

			FluentValidationModelValidatorProvider.Configure(config, provider => {
				provider.ValidatorFactory = new NinjectValidatorFactory();
			});
		}
	}
}
