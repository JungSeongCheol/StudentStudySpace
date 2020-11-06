using Bogus;
using MetroFramework.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;

namespace BogusMqttWinPublishApp
{
    

    public partial class MainForm : MetroForm
    {
        public BackgroundWorker MqttWorker { get; set; }
        public string MqttBrokerUrl { get; set; }

        public MqttClient BrokerClient { get; set; }

        private Thread MqttThread { get; set; }

        private Faker<SensorInfo> SensorFaker { get; set; }

        private string CurrValue { get; set; }

        public MainForm()
        {
            InitializeComponent();
            InitializeAll();    // 전체 초기화

            #region 스레드 쓸때 사용
            //ConnectMqttBroker();// MQTT 브로커 접속
            //StartPublish();     // fake 센싱 메시지 전송
            #endregion 
        }


        private void InitializeAll()
        {

            MqttWorker = new BackgroundWorker();
            MqttWorker.DoWork += BgwTest_DoWork;
            MqttWorker.WorkerReportsProgress = false;
            MqttWorker.WorkerSupportsCancellation = true;

            #region 나머지 초기화
            MqttBrokerUrl = "localhost"; // 또는 127.0.0.1/ 210.119.12.52

            string[] Rooms = new[] { "DiningRoom", "LivingRoom", "BathRoom", "BedRoom", "GuestRoom" };

            SensorFaker = new Faker<SensorInfo>()
                .RuleFor(s => s.Dev_Id, f => f.PickRandom(Rooms))
                .RuleFor(s => s.Curr_Time, f => f.Date.Past(0).ToString("yyyy-MM-dd HH:mm:ss.ff"))
                .RuleFor(s => s.Temp, f => float.Parse(f.Random.Float(19.0f, 35.9f).ToString("0.00")))
                .RuleFor(s => s.Humid, f => float.Parse(f.Random.Float(40.0f, 63.9f).ToString("0.0")))
                .RuleFor(s => s.Press, f => float.Parse(f.Random.Float(800.0f, 999.9f).ToString("0.0")));
            #endregion
        }

        private void BgwTest_DoWork(object sender, DoWorkEventArgs e)
        {
            LoopPublish();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            ConnectMqttBroker();    // MQTT 브로커 접속
            //StartPublish();       // fake 센싱 메세지 접속 -> 스레드 쓸떄(지금은 BackGroundWorker를 사용하므로)
            MqttWorker.RunWorkerAsync();
        }

        private void ConnectMqttBroker()
        {
            MqttBrokerUrl = TxtBrokerIp.Text;
            BrokerClient = new MqttClient(MqttBrokerUrl);
            BrokerClient.Connect("FakerDemon");
        }

        #region 스레드 쓸시 사용됨
        //private void StartPublish()
        //{
        //    MqttThread = new Thread(new ThreadStart(LoopPublish)); // 아래와같음
        //    //MqttThread = new Thread(() => LoopPublish);
        //    MqttThread.Start();
        //}
        #endregion

        private void LoopPublish()
        {
            while (true)
            {
                SensorInfo value = SensorFaker.Generate();
                CurrValue = JsonConvert.SerializeObject(value, Formatting.Indented);
                BrokerClient.Publish("home/device/data/", Encoding.Default.GetBytes(CurrValue));

                this.Invoke(new Action(() =>
                {
                    RtbLog.AppendText($"Published : {CurrValue}\n");
                    RtbLog.ScrollToCaret();
                }));


                Thread.Sleep(1000); // 1sec
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MqttWorker.IsBusy)
            {
                MqttWorker.CancelAsync();
                MqttWorker.Dispose();
            }
            Environment.Exit(0);
        }
    }
}
