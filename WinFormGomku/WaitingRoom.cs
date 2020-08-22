using MetroFramework;
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
using WinFormGomku.Helpers;

namespace WinFormGomku
{
    public partial class WaitingRoom : MetroForm
    {
        public static Thread thread; // 통신을 위한 쓰레드
        public static string roomNum;
        MultiPlay multiPlay;

        bool oneCheck = true;
        int DgvroomColum = 0;

        public WaitingRoom()
        {
            InitializeComponent();
            initialized();
        }
        void initialized()
        {
            LoginForm.stream = LoginForm.tcpClient.GetStream();
            byte[] buf = Encoding.UTF8.GetBytes("[WaitingRoom]Refresh");
            LoginForm.stream.Write(buf, 0, buf.Length);

            thread = new Thread(new ThreadStart(read));
            thread.IsBackground = true;
            thread.Start();
        }

        private void read()
        {
            while (true)
            {
                byte[] buf = new byte[1024]; // 1024의 바이트를 넣는다
                int bufBytes = LoginForm.stream.Read(buf, 0, buf.Length);
                string message = Encoding.UTF8.GetString(buf, 0, bufBytes);

                if (message.Contains("[Users]"))
                {
                    string[] UserNames = message.Split(']')[1].Split(',');
                    dgvUsersInfo.Invoke(new Action(delegate ()
                    {
                        dgvUsersInfo.Rows.Clear();
                    }));

                    foreach (var item in UserNames)
                    {
                        dgvUsersInfo.Invoke(new Action(delegate ()
                        {
                            dgvUsersInfo.Rows.Add(item);
                        }));
                    }
                }

                else if (message.Contains("[Chat]"))
                {
                    string s = message.Split(']')[1].Replace((char)0x02, ']');
                    ChatDataTextBox.AppendText($"{s}\n");
                    ChatDataTextBox.ScrollToCaret();
                }

                else if (message.Contains("[PlayRooms]"))
                {
                    string[] RoomInfo = message.Split(']')[1].Split(',');

                    this.Invoke(new Action(delegate ()
                    {
                        dgvRoomInfo.Rows.Clear();
                    }));

                    for (int i = 2; i <= RoomInfo.Count(); i *= 2)
                    {
                        dgvRoomInfo.Rows.Add(RoomInfo[i - 2], RoomInfo[i - 1]);
                    }

                }

                else if (message.Contains("[Create]"))
                {
                    string s = message.Split(']')[1];

                    Room.currentRoomNum = int.Parse(s);

                    BeginInvoke(new Action(() =>
                    {
                        thread.Abort();
                        Hide();
                        multiPlay = new MultiPlay();
                        multiPlay.FormClosed += new FormClosedEventHandler(childForm_Closed);
                        multiPlay.Show();
                    }));
                }

                else if (message.Contains("[Join]"))
                {
                    string[] s = message.Split(']')[1].Split(',');

                    if (s[0] == "success")
                    {
                        if (s[1] == "Player") Status.player = true;
                        else if (s[1] == "Observer") Status.player = false;
                        Room.currentRoomNum = int.Parse(s[2]);
                        BeginInvoke(new Action(() =>
                        {
                            thread.Abort();
                            Hide();
                            multiPlay = new MultiPlay();
                            multiPlay.FormClosed += new FormClosedEventHandler(childForm_Closed);
                            multiPlay.Show();
                        }));

                    }
                    else if (s[0] == "fail")
                    {
                        MetroMessageBox.Show(this, "접속이 실패했습니다. 다른 방이름으로 해주세요", "Join실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else if (message.Contains("[InvUser]"))
                {
                    string[] s = message.Split(']')[1].Split(',');

                    if (s[0] == "success")
                    {
                        if (s[1] == "Player") Status.player = true;
                        else if (s[1] == "Observer") Status.player = false;
                        Room.currentRoomNum = int.Parse(s[2]);
                        BeginInvoke(new Action(() =>
                        {
                            thread.Abort();
                            Hide();
                            multiPlay = new MultiPlay();
                            multiPlay.FormClosed += new FormClosedEventHandler(childForm_Closed);
                            multiPlay.Show();
                        }));

                    }
                    else if (s[0] == "fail")
                    {
                        MetroMessageBox.Show(this, "접속이 실패했습니다. 다른 방이름으로 해주세요", "Join실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else if (message.Contains("[Refresh]"))
                {
                    string s = message.Split(']')[1];
                    string[] room = s.Split('/')[0].Split(';');
                    string[] people = s.Split('/')[1].Split(',');

                    if (InvokeRequired == true)
                    {
                        dgvRoomInfo.Invoke((MethodInvoker)delegate () {
                            dgvUsersInfo.Invoke((MethodInvoker)delegate ()
                            {
                                dgvRoomInfo.Rows.Clear();
                                dgvUsersInfo.Rows.Clear();
                                if (!(room[0] == "empty"))
                                {
                                    foreach (var item in room)
                                    {
                                        string[] temp = item.Split(',');
                                        for (int i = 0; i < temp.Count() - 1; i=i+4)
                                        {
                                            dgvRoomInfo.Rows.Add(temp[i], temp[i + 1], temp[i + 2], temp[i+3]);
                                        }
                                    }
                                }

                                foreach (var item in people)
                                {
                                    dgvUsersInfo.Rows.Add(item);    
                                }
                            });
                        });

                        if (oneCheck)
                        {
                            PlayerIDLabel.Invoke(new Action(delegate ()
                            {
                                PlayerIDLabel.Text = "내 ID : " + people[people.Length - 1];
                            }));
                        }
                        oneCheck = false;
                    }

                    else
                    {
                        dgvRoomInfo.Rows.Clear();
                        dgvUsersInfo.Rows.Clear();
                        if (!(room[0] == "empty"))
                        {
                            foreach (var item in room)
                            {
                                string[] temp = item.Split(',');
                                for (int i = 0; i < temp.Count() - 1; i = i + 3)
                                {
                                    dgvRoomInfo.Rows.Add(temp[i], temp[i + 1], temp[i + 2]);
                                }
                            }
                        }
                        foreach (var item in people)
                        {
                            dgvUsersInfo.Rows.Add(item);
                        }
                    }
                }
            }
        }

        private void MultiPlayForm_Deactivate(object sender, EventArgs e)
        {
            Show();
            thread = new Thread(new ThreadStart(read));
            thread.Start();
            byte[] buf = Encoding.ASCII.GetBytes($"[PlayingRoom]Exit");
            LoginForm.stream.Write(buf, 0, buf.Length);
        }

        private void ExitTile_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WaitingRoom_Load(object sender, EventArgs e)
        {
            this.Activate();
            ChatTextBox.Focus();
            refreshRoomTile_Click(sender, e);
        }

        private void ChatTile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ChatTextBox.Text))
            {
                byte[] buf = Encoding.UTF8.GetBytes("[WaitingRoom]Chats" + (char)0x01 + ChatTextBox.Text);  //한글로 보낼려면 UTF8로.!!
                LoginForm.stream.Write(buf, 0, buf.Length);
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
            //byte[] buf = Encoding.ASCII.GetBytes("[WaitingRoom]Exit");
            //LoginForm.stream.Write(buf, 0, buf.Length);
            LoginForm.tcpClient.Close();
            LoginForm.stream.Close();
        }

        private void CallMakingRoomTile_Click(object sender, EventArgs e)
        {
            MakingRoom makingRoom = new MakingRoom();
            DialogResult result = makingRoom.ShowDialog();

            if(result == DialogResult.OK)
            {
                byte[] buf = Encoding.UTF8.GetBytes("[PlayingRoom]Create" + (char)0x01 + MakingRoom.MakingRoomText);
                LoginForm.stream.Write(buf, 0, buf.Length);
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
            thread = new Thread(new ThreadStart(read));
            thread.Start();
            byte[] buf = Encoding.ASCII.GetBytes($"[PlayingRoom]Exit");
            LoginForm.stream.Write(buf, 0, buf.Length);
        }

        private void PlayerIDLabel_Click(object sender, EventArgs e)
        {

        }

        private void refreshRoomTile_Click(object sender, EventArgs e)
        {
            byte[] buf = Encoding.ASCII.GetBytes("[WaitingRoom]Refresh");
            LoginForm.stream.Write(buf, 0, buf.Length);
        }

        private void dgvRoomInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            byte[] buf = Encoding.ASCII.GetBytes($"[PlayingRoom]Join{(char)0x01}{dgvRoomInfo.Rows[e.RowIndex].Cells[0].Value.ToString()}");
            LoginForm.stream.Write(buf, 0, buf.Length);
        }
    }
}
