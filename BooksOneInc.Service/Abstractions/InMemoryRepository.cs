using BooksOneInc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BooksOneInc.Service.Abstractions
{
	public abstract class InMemoryRepository<T> : IRepository<T> where T : class, IEntity
	{
		protected AsyncEnumerable<T> _context;

		public InMemoryRepository()
		{
			_context = new AsyncEnumerable<T>(new List<T>());
		}

		public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> whereExpr = null)
		{
			var query = _context.AsQueryable();
			if (whereExpr != null)
			{
				query = query.Where(whereExpr);
			}
			return query;
		}

		public virtual Task<T> GetAsync(Expression<Func<T, bool>> whereExpr, CancellationToken cancellationToken)
		{
			if (whereExpr == null)
				throw new ArgumentNullException(nameof(whereExpr));

			var query = _context.AsQueryable();
			if (whereExpr != null)
			{
				query = query.Where(whereExpr);
			}
			return query.SingleOrDefaultAsync(cancellationToken);
		}

		public virtual Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return _context.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
		}
	}
}
