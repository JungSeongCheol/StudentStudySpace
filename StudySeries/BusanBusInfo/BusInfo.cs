using BusInformation.BusStop;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace BusInformation
{
    public partial class BusInformation : MetroForm
    {
        public BusInformation()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            BusStopInfo busInfo = new BusStopInfo();
            busInfo.Location = this.Location;
            busInfo.ShowDialog();

            this.Close();
        }

        private void ExitTile_Click(object sender, EventArgs e)
        {
            ExitProcess();
        }

        private void BusInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ExitProcess();
        }

        private void ExitProcess()
        {
            var result = MessageBox.Show(this, "종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) // 프로그램 종료
            {
                Environment.Exit(0); // 완전종료
            }
        }
    }
}
