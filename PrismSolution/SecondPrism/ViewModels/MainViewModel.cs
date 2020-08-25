using Microsoft.VisualBasic;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecondPrism.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string displayName;
        public string DisplayName
        {
            get => displayName;
            set
            {
                displayName = value;
                SetProperty(ref displayName, value);
            }
        }

        public MainViewModel()
        {
            DisplayName = "Prism App";
        }
    }
}
