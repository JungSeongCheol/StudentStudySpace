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
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SearchBus_Click(object sender, EventArgs e)
        {
            WebClient wc = null;
            XmlDocument doc = null;

            wc = new WebClient() { Encoding = Encoding.UTF8 };
            doc = new XmlDocument();
            StringBuilder str = new StringBuilder();
            str.Append("http://61.43.246.153/openapi-data/service/busanBIMS2/busStop");
            str.Append("?serviceKey=De7wGblOoulgq0pk85stfmRe3ZjeMWN2nc4%2BdoO1NKCjb8fJ9GFgulC2Vu1HcXzeu0Jn2vHJtfUgTfb9QuieGw%3D%3D");
            str.Append("&bstopNm=" + SerachBusStop.Text);

            string xml = wc.DownloadString(str.ToString());
            doc.LoadXml(xml);
           // XmlElement root = doc.DocumentElement;
            XmlNodeList items = doc.GetElementsByTagName("item");

            dgvBusStop.Rows.Clear();
            foreach (XmlNode item in items)
            {
                dgvBusStop.Rows.Add(item["bustopnm"] == null ? "" : item["bstopnm"].InnerText);
            }
            dgvBusStop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }

        private void dgvBusStop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
