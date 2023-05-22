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
        private bool _sort; 
        public bool Sort { get => _sort; set {

                _sort = value;
                OnPropertyChanged(nameof(Sort)); 
            } 
        }

        private string _showValueText;
        public string ShowValueText { get => _showValueText; set {
                _showValueText = value;
            OnPropertyChanged(nameof(ShowValueText));
            } }

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products { get => _products;  }

        private ObservableCollection<string> _manufacturers;
        public ObservableCollection<string> Manufacturers { get => _manufacturers; }
    }
}
