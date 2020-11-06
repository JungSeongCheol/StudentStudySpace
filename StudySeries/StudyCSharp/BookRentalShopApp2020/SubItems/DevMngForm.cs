using BookRentalShopApp2020.NewFolder1;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BookRentalShopApp2020.SubItems
{
    public partial class DevMngForm : MetroForm
    {
        //  private readonly string strConnectionString = "Data Source=localhost;Port=3306;Database=bookrentalshop;Uid=root;Password=mysql_p@ssw0rd";
        private string strTblName = "divTbl";

        public DevMngForm()
        {
            InitializeComponent();
        }

        private void DevMngForm_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.COMNSTR))
            {
                string strQuery = $"SELECT division, Names FROM divTbl {strTblName} ";
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);    //소켓처럼 생성(데이터를 넣을수 있는 어뎁터를 생성)
                DataSet ds = new DataSet();
                adapter.Fill(ds, strTblName);

                GrdDivTbl.DataSource = ds;
                GrdDivTbl.DataMember = strTblName;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
