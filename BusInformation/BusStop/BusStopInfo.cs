using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BusInformation.BusStop
{
    public partial class BusStopInfo : MetroForm
    {
        public BusStopInfo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SearchBus_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(0);
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
           // XmlElement root = doc.DocumentElement;
            XmlNodeList items = doc.GetElementsByTagName("item");

            dgvBusStop.Rows.Clear();
            foreach (XmlNode item in items)
            {
                dgvBusStop.Rows.Add(item["bstopNm"] == null ? string.Empty : item["bstopNm"].InnerText,
                    item["stoptype"] == null ? string.Empty : item["stoptype"].InnerText,
                    item["bstopId"] == null ? string.Empty : item["bstopId"].InnerText);
            }
            dgvBusStop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }

        private void dgvBusStop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBusStop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string bstopNum = dgvBusStop.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                WebClient wc2 = null;
                XmlDocument doc2 = null;

                wc2 = new WebClient() { Encoding = Encoding.UTF8 };
                doc2 = new XmlDocument();
                StringBuilder str = new StringBuilder();
                str.Append("http://61.43.246.153/openapi-data/service/busanBIMS2/stopArr");
                str.Append("?ServiceKey=De7wGblOoulgq0pk85stfmRe3ZjeMWN2nc4%2BdoO1NKCjb8fJ9GFgulC2Vu1HcXzeu0Jn2vHJtfUgTfb9QuieGw%3D%3D");
                str.Append("&bstopid=" + bstopNum);

                string xml = wc2.DownloadString(str.ToString());
                doc2.LoadXml(xml);
                // XmlElement root = doc.DocumentElement;
                XmlNodeList items = doc2.GetElementsByTagName("item");

                dgvBustopInfo.Rows.Clear();

                foreach (XmlNode item in items)
                {
                    dgvBustopInfo.Rows.Add(item["bstopId"] == null ? string.Empty : item["bstopId"].InnerText,
                        item["nodeNm"] == null ? string.Empty : item["nodeNm"].InnerText,
                        item["lineNo"] == null ? string.Empty : item["lineNo"].InnerText,
                        item["bustype"] == null ? string.Empty : item["bustype"].InnerText,
                        item["min1"] == null ? "알 수 없음" : item["min1"].InnerText + "분남음",
                        item["min2"] == null ? "알 수 없음" : item["min2"].InnerText + "분남음"
                        );
                }

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
    }
}
