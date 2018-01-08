using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using BookCatalog.Core.Services;
using BookCatalog.Services;
using BookCatalog.Views;
using Xamarin.Forms;

namespace BookCatalog.ViewModels
{
    public class BooksPageViewModel : BaseViewModel
    {
        private readonly IBookStoreService _bookStore;
        private readonly IPageService _pageService;

        private BookViewModel _selectedBook;

        public ObservableCollection<BookViewModel> Books { get; set; } = new ObservableCollection<BookViewModel>();

        public BookViewModel SelectedBook
        {
            get { return _selectedBook; }
            set { _selectedBook = value; SelectBookCommand.Execute(value); }
        }

        public ICommand LoadBooksCommand => new Command(async () => await LoadBooks());
        public ICommand SelectBookCommand => new Command<BookViewModel>(async book => await SelectBook(book));

        public BooksPageViewModel(IBookStoreService bookStore, IPageService pageService)
        {
            _bookStore = bookStore;
            _pageService = pageService;
        }

        async Task SelectBook(BookViewModel book)
        {
            if (book == null) return;
            SelectedBook = null;

            var bookDetailViewModel = new BookDetailViewModel(book);
            await _pageService.PushAsync(new BookDetailPage(bookDetailViewModel));
        }

        async Task LoadBooks()
        {
            IsRefreshing = true;
            var books = await _bookStore.GetBooksAsync();
            Books.Clear();

            foreach (var book in books)
            {
                Books.Add(new BookViewModel(book));
            }

            IsRefreshing = false;
        }
    }
}
