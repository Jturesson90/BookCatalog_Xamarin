using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BookCatalog.Core.Models;
using BookCatalog.Core.Net.Messages;
using Newtonsoft.Json;

namespace BookCatalog.Services
{
    public class BookStoreService : IBookStore
    {

        readonly string URL = "https://api.myjson.com/bins/14jdb";
        readonly HttpClient _client = new HttpClient();

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var content = await _client.GetStringAsync(URL);
            var books = JsonConvert.DeserializeObject<BookApiResponse>(content);

            return books.Catalog.Books;
        }
    }
}
