using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothStore.Models.ViewModels
{
    class AdminMenuWindowViewModel: BaseViewModel
    {
        private int _productCount;
        private int ProductCount { get => _productCount;
               set {
                _productCount = value; 
                OnPropertyChanged(nameof(ProductCount));
                } 
        }
    }
}
