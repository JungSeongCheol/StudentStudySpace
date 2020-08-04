using MahApps.Metro.Controls;
using ThridCaliburnApp.ViewModels;

namespace ThridCaliburnApp.Views
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : MetroWindow
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void Salary_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !Commons.IsNumeric(e.Text);
        }
    }
}
