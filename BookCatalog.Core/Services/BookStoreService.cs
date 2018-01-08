using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BookCatalog.Core.Models;
using BookCatalog.Core.Net.Messages;
using Newtonsoft.Json;

namespace BookCatalog.Core.Services
{
    public class BookStoreService : IBookStoreService
    {
        private readonly string _url = "https://api.myjson.com/bins/14jdb";
        private readonly HttpClient _client = new HttpClient();

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var content = await _client.GetStringAsync(_url);
            var books = JsonConvert.DeserializeObject<BookApiResponse>(content);

            return books.Catalog.Books;
        }
    }
}
