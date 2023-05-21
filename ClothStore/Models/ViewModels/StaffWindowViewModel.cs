using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothStore.Models.ViewModels
{
    public class StaffWindowViewModel : BaseViewModel
    {
        private string _showValueText;
        public string ShowValueText { get => _showValueText; set {
                _showValueText = value;
            OnPropertyChanged(nameof(ShowValueText));
            } }

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products { get => _products;  }
    }
}
