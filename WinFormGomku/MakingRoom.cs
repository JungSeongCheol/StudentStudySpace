using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormGomku
{
    public partial class MakingRoom : MetroForm
    {
        public static string MakingRoomText;

        public MakingRoom()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MakingRoomButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MakingRoomTextBox1.Text))
            {
                MetroMessageBox.Show(this, "방제목을 입력해주세요");
                return;
            }

            MakingRoomText = MakingRoomTextBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void childForm_Closed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MakingRoom_Load(object sender, EventArgs e)
        {
            this.Activate();
            MakingRoomTextBox1.Focus();
        }

        private void MakingRoomTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                MakingRoomButton_Click(sender, e);
            }
        }
    }
}
