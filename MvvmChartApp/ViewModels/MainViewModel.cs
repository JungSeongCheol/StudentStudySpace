using Caliburn.Micro;
using MvvmChartApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmChartApp.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        public MainViewModel()
        {

        }

        public void ExitProgram()
        {
            Environment.Exit(0);
        }

        public void LoadLineChart()
        {
            ActivateItem(new LineChartViewModel());
        }

        public void LoadGuageChart()
        {
            ActivateItem(new GuageChartViewModel());
        }
    }
}
