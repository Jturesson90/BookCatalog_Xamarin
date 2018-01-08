using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PropertyChanged;

namespace BookCatalog.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel 
    {
        public bool IsRefreshing { get; set; }
        public bool IsBusy { get; set; }
        public string PageTitle { get; set; }
    }
}
