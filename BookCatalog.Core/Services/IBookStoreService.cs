using System.Collections.Generic;
using System.Threading.Tasks;
using BookCatalog.Core.Models;

namespace BookCatalog.Core.Services
{
    public interface IBookStoreService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
    }
}
