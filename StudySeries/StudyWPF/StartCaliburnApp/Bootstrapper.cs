using Caliburn.Micro;
using StartCaliburnApp.ViewModels;
using System.Windows;

namespace StartCaliburnApp
{
    class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ButtonsViewModel/*ShellViewModel*/> (); // Object -> ViewModel, DisplayRootViewFor은 (뷰모델이) 모델이랑 연결하기 위한것이다.
        }
    }
}
