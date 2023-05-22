using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothStore.Models.ViewModels
{
    class ProductMenuViewModel: BaseViewModel
    {
        private ObservableCollection<Product> _products; 
        public ObservableCollection<Product> Products { get => _products; }
    }
}
