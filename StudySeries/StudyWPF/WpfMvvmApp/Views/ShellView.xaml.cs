using MahApps.Metro.Controls;
using WpfMvvmApp.ViewModels;

namespace WpfMvvmApp.Views
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ShellView : MetroWindow
    {
        public ShellView()
        {
            InitializeComponent();
            this.DataContext = new ShellViewModel(); //DataContext ShellView모델 연동하기 위해 반드시 필요
        }
    }
}
