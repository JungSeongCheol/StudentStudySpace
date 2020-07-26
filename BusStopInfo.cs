using MetroFramework.Forms;
using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using CefSharp; // Chrome 으로 webpage를 열기위해서 사용됨.
using CefSharp.WinForms;
using BusInformation;
#region CefSharp 수정시 유의사항.
// CefSharp 설치시 수동으로 하는게 편하다. Nuget설정에서 Org를 끄고, https://www.nuget.org/packages/cef.redist.x86/
// 그리고 https://www.nuget.org/packages/cef.redist.x64/ 를 설치해야하는데(오프라인식으로) 이렇게 해도 64는 40분, 86은 24분걸린다.
// 시간도 많이 필요하고, 설치가 정확하게 되고있는지 알 방법이 없기 때문에, 시간이 직접 보이는 방식을 위해
// 수동으로 다운받는게 편하다
#endregion
//using Sy
namespace BusInformation.BusStop
{
    public partial class BusStopInfo : MetroForm
    {
        #region 매개 변수
        ChromiumWebBrowser browser;
        string bstopNum = string.Empty;
        #endregion

        #region 생성자
        public BusStopInfo()
        {
            InitializeComponent();
        }
    #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(0);

            if(Cef.IsInitialized == false) // Cef는 초기화를 한번만 할수 있기때문에 사용했습니다.(나갔다가 들어왔을때 다시 초기화를 시키지 못하도록)
            {
                Cef.Initialize(new CefSettings());
            }
        }

        private void SearchBus_Click(object sender, EventArgs e)
        {
            WaitingTxt.Text = "Please Wait...";
            WebClient wc = null;
            XmlDocument doc = null;

            wc = new WebClient() { Encoding = Encoding.UTF8 };
            doc = new XmlDocument();
            StringBuilder str = new StringBuilder();
            str.Append("http://61.43.246.153/openapi-data/service/busanBIMS2/busStop");
            str.Append("?ServiceKey=De7wGblOoulgq0pk85stfmRe3ZjeMWN2nc4%2BdoO1NKCjb8fJ9GFgulC2Vu1HcXzeu0Jn2vHJtfUgTfb9QuieGw%3D%3D");
            str.Append("&bstopnm=" + SerachBusStop.Text);

            string xml = wc.DownloadString(str.ToString());
            doc.LoadXml(xml);

            XmlNodeList items = doc.GetElementsByTagName("item");

            dgvBusStop.Rows.Clear();
            foreach (XmlNode item in items)
            {
                dgvBusStop.Rows.Add(item["bstopNm"] == null ? string.Empty : item["bstopNm"].InnerText,
                    item["stoptype"] == null ? string.Empty : item["stoptype"].InnerText,
                    item["bstopId"] == null ? string.Empty : item["bstopId"].InnerText);
            }

            WaitingTxt.Text = string.Empty;
            metroTabControl1.SelectTab(0);
            dgvBusStop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }

        private void dgvBusStop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBusStop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Thread t1 = new Thread(new ThreadStart(WriteText));
            //t1.IsBackground = false;
            //t1.Start();
            try
            {
                WaitingTxt.Text = "Please Wait...";
                bstopNum = dgvBusStop.Rows[e.RowIndex].Cells[2].Value.ToString();

                WebClient wc2 = null;
                XmlDocument doc2 = null;

                wc2 = new WebClient() { Encoding = Encoding.UTF8 };
                doc2 = new XmlDocument();

                WebClient wc3 = null;
                XmlDocument doc3 = null;

                wc3 = new WebClient() { Encoding = Encoding.UTF8 };
                doc3 = new XmlDocument();

                StringBuilder str = new StringBuilder();
                StringBuilder str1 = new StringBuilder();

                str.Append("http://61.43.246.153/openapi-data/service/busanBIMS2/stopArr");
                str.Append("?ServiceKey=De7wGblOoulgq0pk85stfmRe3ZjeMWN2nc4%2BdoO1NKCjb8fJ9GFgulC2Vu1HcXzeu0Jn2vHJtfUgTfb9QuieGw%3D%3D");
                str.Append("&bstopid=" + bstopNum);

                str1.Append("http://61.43.246.153/openapi-data/service/busanBIMS2/busInfo");
                str1.Append("?ServiceKey=De7wGblOoulgq0pk85stfmRe3ZjeMWN2nc4%2BdoO1NKCjb8fJ9GFgulC2Vu1HcXzeu0Jn2vHJtfUgTfb9QuieGw%3D%3D");
                
                string xml = wc2.DownloadString(str.ToString());
                doc2.LoadXml(xml);
                string xml1 = null;

                // XmlElement root = doc.DocumentElement;
                XmlNodeList items = doc2.GetElementsByTagName("item");
                XmlNodeList item1;

                dgvBustopInfo.Rows.Clear();
                WaitingBar.Maximum = items.Count + 1;
                int count = 1;
                WaitingBar.Value = count;
                
                foreach (XmlNode item in items)
                {
                    str1.Append($"&lineid={item["lineid"].InnerText}");
                    str1.Append($"&lineno={item["lineNo"].InnerText}");

                    xml1 = wc3.DownloadString(str1.ToString());
                    doc3.LoadXml(xml1);
                    item1 = doc3.GetElementsByTagName("item");

                    dgvBustopInfo.Rows.Add(item["bstopId"] == null ? string.Empty : item["bstopId"].InnerText,
                        item["nodeNm"] == null ? string.Empty : item["nodeNm"].InnerText,
                        item["lineNo"] == null ? string.Empty : item["lineNo"].InnerText,
                        item["bustype"] == null ? string.Empty : item["bustype"].InnerText,
                        item["min1"] == null ? "알 수 없음" : item["min1"].InnerText + "분남음",
                        item["min2"] == null ? "알 수 없음" : item["min2"].InnerText + "분남음",
                        items[0]["gpsY"].InnerText + "," + items[0]["gpsX"].InnerText,
                        item1[0] == null ? "알 수 없음" : item1[0]["startpoint"].InnerText,
                        item1[0] == null ? "알 수 없음" : item1[0]["endpoint"].InnerText
                        );

                    str1.Clear();
                    str1.Append("http://61.43.246.153/openapi-data/service/busanBIMS2/busInfo");
                    str1.Append("?ServiceKey=De7wGblOoulgq0pk85stfmRe3ZjeMWN2nc4%2BdoO1NKCjb8fJ9GFgulC2Vu1HcXzeu0Jn2vHJtfUgTfb9QuieGw%3D%3D");
                    WaitingBar.Value = ++count;
                }
                //t1.Abort();
                WaitingTxt.Text = string.Empty;
                WaitingBar.Value = 0;
                metroTabControl1.SelectTab(1);
                dgvBustopInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            }
            catch (NullReferenceException)
            {
                MessageBox.Show($"정류소 구분은 값이 있을때만 가능합니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"에러발생 {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SerachBusStop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                SearchBus_Click(sender, new EventArgs());
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        #region 크롬 브라우저 띄우기 연습
        //private void WebButton_Click(object sender, EventArgs e)
        //{
        //    #region 크롬 Browser띄우기
        //    //Cef.Initialize(new CefSettings());
        //    //browser = new ChromiumWebBrowser("https://www.google.com/maps/@35.1135432,129.0241434,10z?hl=ko");
        //    //this.ShowWebPannel.Controls.Add(browser);

        //    //browser.Dock = DockStyle.Fill;
        //    //webBrowser1.Navigate("https://www.google.com/maps/@35.1135432,129.0241434,25z?hl=ko");
        //    #endregion
        //}
        #endregion

        private void dgvBustopInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            browser = null;
            this.ShowWebPannel.Controls.Clear();
            try
            {
                string busGps = dgvBustopInfo.Rows[e.RowIndex].Cells[6].Value.ToString();
                string url = "https://www.google.com/maps/dir//" + busGps + "/@" + busGps + ",18.86z?hl=ko";
                browser = new ChromiumWebBrowser(url);
                this.ShowWebPannel.Controls.Add(browser);
                metroTabControl1.SelectTab(2);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"에러발생 {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #region 기존 WebBrowser사용
            //webBrowser1.ScriptErrorsSuppressed = true;

            //string busGps = dgvBustopInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //string url = "https://www.google.com/maps/dir//" + busGps + "/@" + busGps + ",19z?hl=ko";
            //webBrowser1.Navigate(url);
            //metroTabControl1.SelectTab(2); // 만약 필요하다면, 사용한다.

            //string busGps = dgvBustopInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //string url = "https://www.google.com/maps/@" + busGps + ",19z?hl=ko";
            //webBrowser1.Navigate(url);
            //metroTabControl1.SelectTab(2);

            //BrowserView browserView = new WinFormsBrowserView();

            //Cef.Initialize(new CefSettings());
            //browser = new ChromiumWebBrowser("http://www.webgl3d.co.kr/demo/atlas/");

            //this.panel2.Controls.Add(browser);
            //browser.Dock = DockStyle.Fill;
            #endregion
        }

        private void ExitTile_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            BusInformation busInfo = new BusInformation();
            busInfo.Location = this.Location;
            busInfo.ShowDialog();
            this.Close();
        }
    }
}
