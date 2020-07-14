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
    public partial class BusWait : MetroForm
    {
        public BusWait()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            WebClient wc = null;
            XmlDocument doc = null;

            wc = new WebClient() { Encoding = Encoding.UTF8 };
            doc = new XmlDocument();
            StringBuilder str = new StringBuilder();
            str.Append("http://61.43.246.153/openapi-data/service/busanBIMS2/stopArr");
            str.Append("?ServiceKey=De7wGblOoulgq0pk85stfmRe3ZjeMWN2nc4%2BdoO1NKCjb8fJ9GFgulC2Vu1HcXzeu0Jn2vHJtfUgTfb9QuieGw%3D%3D");
            str.Append("&bstopnm=" + DgvBus.Text);

            string xml = wc.DownloadString(str.ToString());
            doc.LoadXml(xml);
            // XmlElement root = doc.DocumentElement;
            XmlNodeList items = doc.GetElementsByTagName("item");

            DgvBus.Rows.Clear();
            foreach (XmlNode item in items)
            {
                DgvBus.Rows.Add(item["bstopNm"] == null ? string.Empty : item["bstopNm"].InnerText,
                    item["stoptype"] == null ? string.Empty : item["stoptype"].InnerText);
            }
            DgvBus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }
    }
}
