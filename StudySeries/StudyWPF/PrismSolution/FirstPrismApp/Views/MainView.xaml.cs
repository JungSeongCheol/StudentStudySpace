using Prism.Ioc;
using Prism.Regions;
using System;
using System.ComponentModel;
using System.Windows;

namespace FirstPrismApp.Views
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : Window
    {
        //IContainerExtension _container;
        //IRegionManager _regionManager;
        //IRegion _region;
        //SubViewA _viewA;
        //SubViewB _viewB;

        public MainView(/*IContainerExtension container ,IRegionManager regionManager*/)
        {
            InitializeComponent();
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(SubView));
            //_container = container;
            //_regionManager = regionManager;
        }

        private void ContentControl_Loaded(object sender, RoutedEventArgs e)
        {


        #region View모델을 쓰지 않았을시
            //_viewA = _container.Resolve<SubViewA>();
            //_viewB = _container.Resolve<SubViewB>();
            //_region = _regionManager.Regions["ContentRegion"];
            //_region.Add(_viewA);
            //_region.Add(_viewB);
        #endregion
        }


        #region View모델을 쓰지않았을시
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //_region.Activate(_viewA);
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    _region.Deactivate(_viewA);
        //}

        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    _region.Activate(_viewB);
        //}

        //private void Button_Click_3(object sender, RoutedEventArgs e)
        //{
        //    _region.Deactivate(_viewB);
        //}
        #endregion
    }
}
