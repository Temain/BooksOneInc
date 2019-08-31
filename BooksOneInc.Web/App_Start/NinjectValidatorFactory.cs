using System;
using System.Web.Http;
using FluentValidation;

namespace BooksOneInc.Web.App_Start
{
	public class NinjectValidatorFactory : ValidatorFactoryBase
	{
		/// <summary>
		/// Creates an instance of a validator with the given type using ninject.
		/// </summary>
		/// <param name="validatorType">Type of the validator.</param>
		/// <returns>The newly created validator</returns>
		public override IValidator CreateInstance(Type validatorType)
		{
			return GlobalConfiguration.Configuration.DependencyResolver.GetService(validatorType) as IValidator;
		}
	}
}