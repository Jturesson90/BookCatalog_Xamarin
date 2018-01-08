using System;
using BookCatalog.Core.Models;

namespace BookCatalog.ViewModels
{
    public class BookViewModel : BaseViewModel
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Description { get; private set; }

        public string _price;
        public string Price { get { return $"{ _price}$"; } private set { _price = value; } }
        public string Genre { get; private set; }
        public string Id { get; private set; }
        public string PublishDate { get; private set; }

        public BookViewModel(Book book)
        {
            Title = book.Title;
            Author = book.Author;
            Description = book.Description;
            Price = book.Price;
            Genre = book.Genre;
            Id = book.Id;
            PublishDate = book.PublishDate;
        }
    }
}
