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
        //private Thread thread; // 통신을 위한 쓰레드
        private NetworkStream stream;

        public MakingRoom()
        {
            InitializeComponent();
            initialized();
        }

        void initialized()
        {
            stream = LoginForm.tcpClient.GetStream();
            byte[] buf = Encoding.ASCII.GetBytes("[WaitingRoom]Users");
            stream.Write(buf, 0, buf.Length);

            WaitingRoom.thread = new Thread(new ThreadStart(read));
            WaitingRoom.thread.Start();
        }



        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MakingRoomButton_Click(object sender, EventArgs e)
        {
            stream = LoginForm.tcpClient.GetStream();
            byte[] buf = Encoding.ASCII.GetBytes("[PlayingRoom]Create" + (char)0x01 + MakingRoomTextBox1.Text);
            stream.Write(buf, 0, buf.Length);
        }

        private void read()
        {
            byte[] buf = new byte[1024]; // 1024의 바이트를 넣는다
            int bufBytes = stream.Read(buf, 0, buf.Length);
            string message = Encoding.ASCII.GetString(buf, 0, bufBytes);

            if (message.Contains("[Create]"))
            {
                this.Invoke(new Action(delegate ()
                {
                    Hide();
                    this.DialogResult = DialogResult.OK;
                    MultiPlay multiPlay = new MultiPlay();
                    multiPlay.FormClosed += new FormClosedEventHandler(childForm_Closed);
                    multiPlay.Show();
                }));
            }
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
