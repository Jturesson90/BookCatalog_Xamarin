using System;
using BookCatalog.Core.Models;

namespace BookCatalog.ViewModels
{
    public class BookDetailViewModel : BaseViewModel
    {
        public Book Book { get; private set; }

        public BookDetailViewModel(BookViewModel bookViewModel)
        {
            if (bookViewModel == null)
                throw new ArgumentException(nameof(bookViewModel));

            Book = new Book
            {
                Id = bookViewModel.Id,
                Author = bookViewModel.Author,
                Description = bookViewModel.Description,
                Genre = bookViewModel.Genre,
                Price = bookViewModel.Price,
                PublishDate = bookViewModel.PublishDate,
                Title = bookViewModel.Title
            };
        }

    }
}
