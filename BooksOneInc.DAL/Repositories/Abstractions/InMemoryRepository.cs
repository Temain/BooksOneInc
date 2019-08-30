using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BooksOneInc.DAL.Common;
using BooksOneInc.Domain.Interfaces;

namespace BooksOneInc.DAL.Repositories.Abstractions
{
	public abstract class InMemoryRepository<T> : IRepository<T> where T : class, IEntity
	{
		private readonly List<T> _source;
		private readonly AsyncEnumerable<T> _context;

		public InMemoryRepository()
		{
			_source = new List<T>();
			_context = new AsyncEnumerable<T>(_source);
		}

		public InMemoryRepository(List<T> source)
		{
			_source = source;
			_context = new AsyncEnumerable<T>(_source);
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

		public virtual T Add(T entity)
		{
			_source.Add(entity);
			return entity;
		}

		public virtual T Remove(T entity)
		{
			_source.Remove(entity);
			return entity;
		}
	}
}
