﻿using BooksOneInc.Domain.Interfaces;
using BooksOneInc.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BooksOneInc.Service
{
	public class InMemoryRepository<T> : IRepository<T> where T : class, IEntity
	{
		private readonly List<T> _context;

		public InMemoryRepository()
		{
			_context = new List<T>();
		}

		public IQueryable<T> GetAll(Expression<Func<T, bool>> whereExpr)
		{
			var query = _context.AsQueryable();
			if (whereExpr != null)
			{
				query = query.Where(whereExpr);
			}
			return query;
		}

		public Task<T> GetAsync(Expression<Func<T, bool>> whereExpr, CancellationToken cancellationToken)
		{
			if (whereExpr == null)
			{
				throw new ArgumentNullException(nameof(whereExpr));
			}

			var query = _context.AsQueryable();
			if (whereExpr != null)
			{
				query = query.Where(whereExpr);
			}
			return query.SingleOrDefaultAsync();
		}

		public Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
		{
			return _context.AsQueryable().SingleOrDefaultAsync(x => x.Id == id);
		}
	}
}
