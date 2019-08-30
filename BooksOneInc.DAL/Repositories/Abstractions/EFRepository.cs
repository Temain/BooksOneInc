using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BooksOneInc.Domain.Interfaces;

namespace BooksOneInc.DAL.Repositories.Abstractions
{
	/// <summary>
	/// Базовый класс репозитория с использованием EF.
	/// Реализовать при необходимости и зарегистрировать в DI контейнере вместо InMemoryRepository.
	/// </summary>
	public abstract class EFRepository<T> : IRepository<T> where T : class, IEntity
	{
		//private readonly DbContext _context;

		//protected EFRepository(IDbContextFactory dbContextFactory)
		//{
		//	if (dbContextFactory == null)
		//		throw new ArgumentNullException(nameof(dbContextFactory));

		//	_context = dbContextFactory.DbContext;
		//}

		public IQueryable<T> GetAll(Expression<Func<T, bool>> whereExpr = null)
		{
			throw new NotImplementedException();
		}

		public Task<T> GetAsync(Expression<Func<T, bool>> whereExpr, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public T Add(T entity)
		{
			throw new NotImplementedException();
		}

		public T Remove(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
