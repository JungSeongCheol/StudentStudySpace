using MvvmDialogs.DialogTypeLocators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThridCaliburnApp.Helpers
{
    class DialogTypeLoactor : IDialogTypeLocator
    {
        public Type Locate(INotifyPropertyChanged viewModel)
        {
            var viewModelType = viewModel.GetType();

            var dialogFullName = viewModelType.FullName;
            dialogFullName = dialogFullName.Substring(0, dialogFullName.Length - "Model".Length);

            return viewModelType.Assembly.GetType(dialogFullName);
        }
    }
}
