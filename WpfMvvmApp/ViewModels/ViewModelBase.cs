using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

                //if (PropertyChanged != null)
                //{
                //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                //} 와 Invoke와 같다.(위의 18번째 줄)
            }
        }
    }
}
