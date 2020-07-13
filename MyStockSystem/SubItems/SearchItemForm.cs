using System;
using MetroFramework.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace MyStockSystem.SubItems
{
    public partial class SearchItemForm : MetroForm
    {
        public SearchItemForm()
        {
            InitializeComponent();
            this.Location = new Point(
               Screen.PrimaryScreen.Bounds.Width / 2 - this.Size.Width / 2,
               Screen.PrimaryScreen.Bounds.Height / 2 - this.Size.Height / 2
            );
        }

        private void SearchItemForm_Load(object sender, EventArgs e)
        {
            DgvSearchItem.Font = new Font(@"NanumGothic", 10, FontStyle.Regular);
            //this.Location = new Point(
            //    Screen.PrimaryScreen.Bounds.Width / 2 - this.Size.Width / 2,
            //    Screen.PrimaryScreen.Bounds.Height / 2 - this.Size.Height / 2
            //);
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 main = new Form1();
            main.Location = this.Location;
            main.ShowDialog();

            this.Close();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DgvSearchItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearchItemButton_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient { Encoding = Encoding.UTF8 };
            XmlDocument doc = new XmlDocument();

            StringBuilder str = new StringBuilder();
            str.Append("http://api.seibro.or.kr/openapi/service/StockSvc/getStkIsinByNmN1");
            str.Append("?serviceKey=De7wGblOoulgq0pk85stfmRe3ZjeMWN2nc4%2BdoO1NKCjb8fJ9GFgulC2Vu1HcXzeu0Jn2vHJtfUgTfb9QuieGw%3D%3D"); // 일반인증키
            str.Append($"&secnNm={TextSerachItem.Text}"); // 종목 명
            str.Append("&pageNo=1"); // 페이지 수
            str.Append("&numOfRows=200"); // 일겅올 데이터 수
            str.Append("&martTcpd=11"); // 주식시장종류 : 11은 유가증권시장

            string xml = wc.DownloadString(str.ToString());
            doc.LoadXml(xml);

            XmlElement root = doc.DocumentElement;
            XmlNodeList items = doc.GetElementsByTagName("item");

            DgvSearchItem.Rows.Clear();

            try
            {
                foreach (XmlNode item in items)
                {
                    DgvSearchItem.Rows.Add(
                        item["isin"].InnerText,
                        item["issuDt"] == null ? string.Empty : item["issuDt"].InnerText/*== null ? string.Empty : item["issuDt"].InnerText*/,
                        item["korSecnNm"].InnerText,
                        item["secnKacdNm"].InnerText,
                        item["shotnIsin"].InnerText
                        ) ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"에러발생 {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DgvSearchItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void TextSerachItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                SearchItemButton_Click(sender, new EventArgs());
            }
        }
    }
}
