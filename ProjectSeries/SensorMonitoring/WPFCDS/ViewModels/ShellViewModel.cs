using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using MySql.Data.MySqlClient;
using OxyPlot;
using WPFCDS.Models;
using System.Windows.Threading;
using WPFCDS.Helpers;

namespace WPFCDS.ViewModels
{

    public class ShellViewModel : Conductor<IScreen>
    {

        #region 변수 선언
        SerialPort serial;
        DispatcherTimer timer = new DispatcherTimer();
        Random rand = new Random();
        DateTime current;
        List<DataPoint> trueData, viewData = new List<DataPoint> { };
        List<SensorDataModel> photoDatas = new List<SensorDataModel>();
        int Check = Constants.TimeStop;
        #endregion

        #region 프로퍼티
        public List<string> CboSelectPort { get; set; }

        string lblConnectionTimeText = "연결시간 : ";
        public string LblConnectionTimeText
        {
            get => lblConnectionTimeText;
            set
            {
                lblConnectionTimeText = value;
                NotifyOfPropertyChange(() => LblConnectionTimeText);
            }
        }

        string serialPortText;
        public string SerialPortText
        {
            get => serialPortText;
            set
            {
                serialPortText = value;
                NotifyOfPropertyChange(() => SerialPortText);
            }
        }

        string txtSensorCount;
        public string TxtSensorCount
        {
            get => txtSensorCount;
            set
            {
                txtSensorCount = value;
                NotifyOfPropertyChange(() => TxtSensorCount);
            }
        }

        ushort pgbValue;
        public ushort PgbValue
        {
            get => pgbValue;
            set
            {
                pgbValue = value;
                NotifyOfPropertyChange(() => PgbValue);
            }
        }

        bool connectedOnOff = false;
        public bool ConnectedOnOff
        {
            get => connectedOnOff;
            set
            {
                connectedOnOff = value;
                NotifyOfPropertyChange(() => CanBtn_Disconnect_Click);
                NotifyOfPropertyChange(() => CanBtnConnectClick);
            }
        }

        public List<DataPoint> TrueData
        {
            get => trueData;
            set
            {
                trueData = value;
                NotifyOfPropertyChange(() => TrueData);
            }
        }

        public List<DataPoint> ViewData
        {
            get => viewData;
            set
            {
                viewData = value;
                NotifyOfPropertyChange(() => ViewData);
            }
        }


        string rtbLog;
        public string RtbLog
        {
            get => rtbLog;
            set
            {
                rtbLog = value;
                NotifyOfPropertyChange(() => RtbLog);
            }
        }

        int xMaxValue;
        public int XMaxValue
        {
            get => xMaxValue;
            set
            {
                xMaxValue = value;
                NotifyOfPropertyChange(() => XMaxValue);
            }
        }

        int xMinValue;
        public int XMinValue
        {
            get => xMinValue;
            set
            {
                xMinValue = value;
                NotifyOfPropertyChange(() => XMinValue);
            }
        }

        int fontSizeNum;
        public int FontSizeNum
        {
            get => fontSizeNum;
            set
            {
                fontSizeNum = value;
                NotifyOfPropertyChange(() => FontSizeNum);
            }
        }

        bool isSimulation;
        public bool IsSimulation { 
            get => isSimulation;
            set
            {
                isSimulation = value;
                NotifyOfPropertyChange(() => IsSimulation);
                NotifyOfPropertyChange(() => CanBtnConnectClick);
            } 
        }

        string selectPortName;
        public string SelectPortName
        {
            get => selectPortName;
            set
            {
                selectPortName = value;
                NotifyOfPropertyChange(() => SelectPortName);
                NotifyOfPropertyChange(() => CanBtnConnectClick);
                NotifyOfPropertyChange(() => CanBtn_Disconnect_Click);
            }
        }

        string serialValue;
        public string SerialValue
        {
            get => serialValue;
            set
            {
                serialValue = value;
                NotifyOfPropertyChange(() => SerialValue);
            }
        }

        string portOrValue = "PORT";
        public string PortOrValue
        {
            get => portOrValue;
            set
            {
                portOrValue = value;
                NotifyOfPropertyChange(() => PortOrValue);
            }
        }
        #endregion

        #region 메서드
        public void BtnConnectClick()
        {
            ConnectedOnOff = true;
            SerialPortText = SelectPortName;

            serial = new SerialPort(SerialPortText);
            serial.Open();
            serial.DataReceived += DataReceived;
            FontSizeNum = 25;
            LblConnectionTimeText = $"연결시간 : {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}";
        }

        public bool CanBtnConnectClick
        {
            get => !ConnectedOnOff && !string.IsNullOrEmpty(SelectPortName) && (IsSimulation == false);
        }

        public void Btn_Disconnect_Click()
        {
            ConnectedOnOff = false;
            serial.Close();
        }

        public bool CanBtn_Disconnect_Click
        {
            get => ConnectedOnOff;
        }

        public void Simulation_Start(object obj)
        {
            
            IsSimulation = true;

            timer.Interval = TimeSpan.FromMilliseconds(1000);
            if(Check != Constants.TimeStart)
            {
                timer.Tick += Timer_Tick;
            }
            Check = Constants.TimeStart;
            FontSizeNum = 50;
            timer.Start();

            // serial통신 끊기
           // Btn_Disconnect_Click();
        }

        public void Simulation_Stop(object obj)
        {
            timer.Stop();
            IsSimulation = false;
        }

        public void InitControls()
        {
            CboSelectPort = new List<string>();
            foreach (var item in SerialPort.GetPortNames())
            {
                CboSelectPort.Add(item);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ushort value = (ushort)rand.Next(1, 1024);
            DisplayValue(value.ToString());
        }

        public void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string sVal = serial.ReadLine();
            dispatcher.Invoke(DispatcherPriority.Normal,new System.Action(delegate
            {
                DisplayValue(sVal);
            })); //데이터를 받을때 오류가 나지 않기 위해 사용.
        }

        public void App_Exit(object obj)
        {
            TryClose();
        }

        private void DisplayValue(string SerialValue)
        {
            if (IsSimulation == true)
            {
                ushort value = (ushort)rand.Next(1, 1024);
                SerialValue = value.ToString();
            }

            try
            {
                if (ushort.Parse(SerialValue) > 1023) return;
                PgbValue = ushort.Parse(SerialValue);
                current = DateTime.Now;
                SensorDataModel data = new SensorDataModel(current, PgbValue);
                InsertDataToDB(data);
                photoDatas.Add(data);

                TxtSensorCount = photoDatas.Count.ToString();
                RtbLog += ($"{current.ToString()} {SerialValue}\n");

                ViewData.Add(new DataPoint(photoDatas.Count, PgbValue));
                TrueData = null;
                TrueData = ViewData;
                if(photoDatas.Count > 200)
                {
                    XMaxValue = photoDatas.Count;
                    xMinValue = photoDatas.Count - 200;
                }

                else
                {
                    XMaxValue = 200;
                    XMinValue = 1;
                }

                if (ConnectedOnOff == true)
                    PortOrValue = $"{serial.PortName}\n{PgbValue}";
                else
                    PortOrValue = $"{PgbValue}";
            }
            catch (Exception ex)
            {
                RtbLog += ($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")} {ex.Message}\n");
            }
        }

        public void ViewAllClick()
        {
            XMaxValue = photoDatas.Count;
            XMinValue = 1;
        }

        public void ZoomClick()
        {
            XMaxValue = photoDatas.Count;
            XMinValue = photoDatas.Count - 10;
        }

        public void HelpClicked()
        {
            IWindowManager manager = new WindowManager();
            manager.ShowDialog(new ThisProgramFormViewModel(), null, null);
        }

        private void InsertDataToDB(SensorDataModel data)
        {
            string strQuery = "INSERT INTO sensordatatbl " +
                " (Date, Value) " +
                " VALUES " +
                " (@Date, @Value) ";

            using (MySqlConnection conn = new MySqlConnection(Commons.strConnString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlParameter paramDate = new MySqlParameter("@Date", MySqlDbType.DateTime)
                {
                    Value = data.Date
                };
                cmd.Parameters.Add(paramDate);
                MySqlParameter paramValue = new MySqlParameter("@Value", MySqlDbType.Int32)
                {
                    Value = data.Value
                };
                cmd.Parameters.Add(paramValue);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region ShortCut RelayCommand
        ICommand sim_Start_Command;
        public ICommand Sim_Start_Command => sim_Start_Command ?? (sim_Start_Command = new RelayCommand<object>(Simulation_Start));

        ICommand sim_Stop_Command;
        public ICommand Sim_Stop_Command => sim_Stop_Command ?? (sim_Stop_Command = new RelayCommand<object>(Simulation_Stop));

        ICommand shortCutExit;
        public ICommand ShortCutExit => shortCutExit ?? (shortCutExit = new RelayCommand<object>(App_Exit));
        Dispatcher dispatcher = Application.Current.Dispatcher;
        #endregion

        #region 생성자
        public ShellViewModel()
        {
            InitControls();
        }
        #endregion
    }
}
