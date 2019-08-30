using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BooksOneInc.Domain.Interfaces;

namespace BooksOneInc.Service.Abstractions.Repositories
{
	public interface IRepository<T> where T : class, IEntity
	{
		IQueryable<T> GetAll(Expression<Func<T, bool>> whereExpr = null);

		Task<T> GetAsync(Expression<Func<T, bool>> whereExpr, CancellationToken cancellationToken);

		Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);

		T Add(T entity);

		T Remove(T entity);
	}
}
