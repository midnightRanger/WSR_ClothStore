using System;
using System.Collections.Generic;
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
    }
}
