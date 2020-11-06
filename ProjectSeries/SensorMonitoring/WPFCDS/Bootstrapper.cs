using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFCDS.ViewModels;

namespace WPFCDS
{
    class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>(); // Object -> ViewModel, DisplayRootViewFor은 (뷰모델이) 모델이랑 연결하기 위한것이다.
        }
    }
}
