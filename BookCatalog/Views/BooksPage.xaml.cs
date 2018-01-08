using System;
using System.Collections.Generic;
using BookCatalog.Services;
using BookCatalog.ViewModels;
using Xamarin.Forms;

namespace BookCatalog.Views
{
    public partial class BooksPage : ContentPage
    {

        public BooksPage()
        {
            var bookStore = new BookStoreService();
            var pageService = new PageService();

            ViewModel = new BooksPageViewModel(bookStore, pageService);
            InitializeComponent();
            ViewModel.LoadBooksCommand.Execute(null);
        }
        public BooksPageViewModel ViewModel
        {
            get { return BindingContext as BooksPageViewModel; }
            set { BindingContext = value; }
        }

        void Handle_BookSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectBookCommand.Execute(e.SelectedItem);
        }
    }
}
