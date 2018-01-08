using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookCatalog.Core.Models;

namespace BookCatalog.Services
{
    public interface IBookStore
    {
        Task<IEnumerable<Book>> GetBooksAsync();
    }
}
