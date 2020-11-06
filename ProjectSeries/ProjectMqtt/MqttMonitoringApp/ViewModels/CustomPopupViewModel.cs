﻿using Caliburn.Micro;
using MqttMonitoringApp.Helpers;

namespace MqttMonitoringApp.ViewModels
{
    public class CustomPopupViewModel : Conductor<object>
    {
        private string brokerIp;
        public string BrokerIp
        {
            get => brokerIp;
            set
            {
                brokerIp = value;
                NotifyOfPropertyChange(() => BrokerIp);
            }
        }

        private string topic;
        public string Topic
        {
            get => topic;
            set
            {
                topic = value;
                NotifyOfPropertyChange(() => Topic);
            }
        }
        public CustomPopupViewModel(string title)
        {
            this.DisplayName = title;

            BrokerIp = "localhost";
            Topic = "home/device/data/";
        }

        public void AcceptClose()
        {
            Commons.BROKERHOST = BrokerIp;
            Commons.PUB_TOPIC = Topic;
            TryClose(true);
        }
    }
}