using sebExamination.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace sebExamination.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand questionbank_click { get; set; }
        public HomeViewModel() {
        questionbank_click = new RelayCommand<string>(
            (s) => true, // CanExecute()
            (s) => s = "" // Execute()
            );
        }
    }
}
