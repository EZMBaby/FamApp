using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Diagnostics;

namespace FamApp.Frontend
{
    [INotifyPropertyChanged]
    public partial class MainViewModel
    {
        [ObservableProperty]
        private string name;
        partial void OnNameChanging(string? oldValue, string newValue)
        {
            Debug.WriteLine($"Name is about to change to {newValue}");
        }

        partial void OnNameChanged(string value)
        {
            Debug.WriteLine($"Name has changed to {value}");
        }
    }
}
