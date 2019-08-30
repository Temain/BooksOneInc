using System.Collections.Generic;
using BooksOneInc.Domain.Models;
using BooksOneInc.Service.Abstractions.Repositories;

namespace BooksOneInc.Service.Realizations
{
	public class EFBookRepository : EFRepository<Book>
	{
	}
}
