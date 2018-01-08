using System;
using System.Collections.Generic;
using BookCatalog.ViewModels;
using Xamarin.Forms;

namespace BookCatalog.Views
{
    public partial class BookDetailPage : ContentPage
    {
        public BookDetailPage()
        {
            InitializeComponent();
        }

        public BookDetailPage(BookDetailViewModel bookDetail)
        {
            InitializeComponent();
            BindingContext = bookDetail;
        }
    }
}
