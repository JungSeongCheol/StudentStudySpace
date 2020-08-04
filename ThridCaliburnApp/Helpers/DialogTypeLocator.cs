using MvvmDialogs.DialogTypeLocators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThridCaliburnApp.Helpers
{
    class DialogTypeLocator : IDialogTypeLocator
    {
        /// <summary>
        /// 특정 뷰모델에다 Dialog 타입을 위치시키는 메서드
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public Type Locate(INotifyPropertyChanged viewModel)
        {
            Type viewModelType = viewModel.GetType();
            
            var dialogfullName = viewModelType.FullName;
            dialogfullName = dialogfullName.Substring(0, dialogfullName.Length - "Model".Length);

            return viewModelType.Assembly.GetType(dialogfullName);
        }
    }
}
