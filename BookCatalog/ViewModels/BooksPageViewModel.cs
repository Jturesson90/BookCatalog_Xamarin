using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using BookCatalog.Services;
using BookCatalog.Views;
using Xamarin.Forms;

namespace BookCatalog.ViewModels
{
    public class BooksPageViewModel : BaseViewModel
    {
        readonly IBookStore _bookStore;
        readonly IPageService _pageService;

        BookViewModel _selectedBook;

        ObservableCollection<BookViewModel> _books = new ObservableCollection<BookViewModel>();

        public ObservableCollection<BookViewModel> Books
        {
            get { return _books; }
            set { SetProperty(ref _books, value); }
        }
        public BookViewModel SelectedBook
        {
            get { return _selectedBook; }
            set { SetProperty(ref _selectedBook, value); }
        }

        public ICommand LoadBooksCommand { get; private set; }
        public ICommand SelectBookCommand { get; private set; }

        public BooksPageViewModel(IBookStore bookStore, IPageService pageService)
        {
            _bookStore = bookStore;
            _pageService = pageService;

            LoadBooksCommand = new Command(async () => await LoadBooks());
            SelectBookCommand = new Command<BookViewModel>(async book => await SelectBook(book));
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
