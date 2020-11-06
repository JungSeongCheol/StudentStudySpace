using BusInformation.BusStop;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
