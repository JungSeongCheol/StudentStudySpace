using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WinFormGomku
{
    public partial class WaitingRoom : MetroForm
    {
        public static Thread thread; // 통신을 위한 쓰레드
        private NetworkStream stream;
        bool oneCheck = true;

        public WaitingRoom()
        {
            InitializeComponent();
            initialized();
        }
        void initialized()
        {
            stream = LoginForm.tcpClient.GetStream();
            byte[] buf = Encoding.ASCII.GetBytes("[WaitingRoom]Users");
            stream.Write(buf, 0, buf.Length);

            thread = new Thread(new ThreadStart(read));
            thread.Start();
        }

        private void read()
        {
            while (true)
            {
                byte[] buf = new byte[1024]; // 1024의 바이트를 넣는다
                int bufBytes = stream.Read(buf, 0, buf.Length);
                string message = Encoding.ASCII.GetString(buf, 0, bufBytes);

                if (message.Contains("[Users]"))
                {
                    string[] UserNames = message.Split(']')[1].Split(',');
                    this.Invoke(new Action(delegate ()
                    {
                        dgvUsersInfo.Rows.Clear();
                    }));
                    foreach (var item in UserNames)
                    {
                        this.Invoke(new Action(delegate ()
                        {
                            dgvUsersInfo.Rows.Add(item);
                        }));
                    }

                    if(oneCheck)
                    {
                        this.Invoke(new Action(delegate ()
                        {
                            PlayerIDLabel.Text = "내 ID : " + UserNames[UserNames.Length - 2];
                        }));
                    }
                    oneCheck = false;
                }

                if (message.Contains("[Chat]"))
                {
                    string s = message.Split(']')[1];
                    ChatDataTextBox.AppendText($"{s}\n");
                    ChatDataTextBox.ScrollToCaret();
                }

                //if (message.Contains("[Make]"))
                //{
                //    string s = message.Split(']')[1];
                //    this.Invoke(new Action(delegate ()
                //    {
                //        dgvRoomInfo.Rows.Clear();
                //    }));
                //}

                if (message.Contains("[Refresh]"))
                {
                    string[] RoomInfo = message.Split(']')[1].Split(',');

                    this.Invoke(new Action(delegate ()
                    {
                        dgvRoomInfo.Rows.Clear();
                    }));

                    for (int i = 2; i <= RoomInfo.Count(); i*=2)
                    {
                        dgvRoomInfo.Rows.Add(RoomInfo[i-2], RoomInfo[i - 1]);
                    }

                }
            }
        }

        private void ExitTile_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WaitingRoom_Load(object sender, EventArgs e)
        {
            this.Activate();
            ChatTextBox.Focus();
        }

        private void ChatTile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ChatTextBox.Text))
            {
                byte[] buf = Encoding.ASCII.GetBytes("[WaitingRoom]Chats" + (char)0x01 + ChatTextBox.Text);
                stream.Write(buf, 0, buf.Length);
                ChatTextBox.Clear();
            }
            ChatTextBox.Text = string.Empty;
        }

        private void ChatTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13 )
            {
                ChatTile_Click(sender, e);
            }
        }

        private void WaitingRoom_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
            byte[] buf = Encoding.ASCII.GetBytes("[WaitingRoom]Exit");
            stream.Write(buf, 0, buf.Length);
            LoginForm.tcpClient.Close();
        }

        private void CallMakingRoomTile_Click(object sender, EventArgs e)
        {
            thread.Abort();
            MakingRoom makingRoom = new MakingRoom();
            DialogResult result = makingRoom.ShowDialog();
            if(result == DialogResult.OK)
            {
                Hide();
            }
            if (result == DialogResult.Cancel)
            {
                this.Show();
            }

            makingRoom.FormClosed += new FormClosedEventHandler(childForm_Closed);
        }

        private void childForm_Closed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void PlayerIDLabel_Click(object sender, EventArgs e)
        {

        }

        private void refreshRoomTile_Click(object sender, EventArgs e)
        {
            byte[] buf = Encoding.ASCII.GetBytes("[PlayingRoom]Refresh");
            stream.Write(buf, 0, buf.Length);
        }
    }
}
