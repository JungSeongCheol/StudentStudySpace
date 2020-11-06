using Caliburn.Micro;
using MqttMonitoringApp.Helpers;
using MqttMonitoringApp.ViewModels;
using MvvmDialogs;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MqttMonitoringApp
{
    class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer container;

        public Bootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            container = new SimpleContainer();
            container.Singleton<IWindowManager, WindowManager>();
            container.RegisterInstance(typeof(IDialogService), null,
                new DialogService(dialogTypeLocator: new DialogTypeLocator()));
            container.PerRequest<MainViewModel>();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>(); // Object -> ViewModel, DisplayRootViewFor은 (뷰모델이) 모델이랑 연결하기 위한것이다.
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return base.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            base.BuildUp(instance);
        }

    }
}
