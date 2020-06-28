using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.ViewModels
{
    public class PaginationControl : INotifyPropertyChanged
    {
        private int _currentPage = 1;
        public int CurrentPage { get => _currentPage; set
            {
                _currentPage = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("CurrentPage"));
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
