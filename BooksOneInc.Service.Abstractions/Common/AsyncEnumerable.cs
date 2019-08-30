using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace BooksOneInc.Service.Abstractions.Common
{
	public class AsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>, IQueryable<T>
	{
		public AsyncEnumerable(IEnumerable<T> enumerable)
			: base(enumerable)
		{ }

		public AsyncEnumerable(Expression expression)
			: base(expression)
		{ }

		public IDbAsyncEnumerator<T> GetAsyncEnumerator()
		{
			return new AsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
		}

		IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
		{
			return GetAsyncEnumerator();
		}

		IQueryProvider IQueryable.Provider
		{
			get { return new AsyncQueryProvider<T>(this); }
		}
	}
}
