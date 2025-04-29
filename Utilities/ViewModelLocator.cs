using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWpfApp.ViewModels;

namespace MyWpfApp.Utilities
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => new MainViewModel();
    }
}
