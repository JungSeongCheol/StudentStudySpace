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
using System.Windows.Forms;
using WinFormGomku.Helpers;

namespace WinFormGomku
{
    public partial class MultiPlay : MetroForm
    {
        private Thread thread; // 통신용 스레드 선언
        private TcpClient tcpClient; // TCP Client선언
        private NetworkStream stream; // 내부 스트림

        private const int rectSize = 33; // 오목판 셀 수
        private const int edgeCount = 15; // 오목판 선 갯수

        private enum Horse { none = 0, BLACK, WHITE};
        private Horse[,] board; // 보드 판 (가로줄 * 세로줄 선언시 필요)
        private Horse nowPlayer; // 현재 플레이어를 나타내기위해(흰색, 검은색)
        private bool nowTurn;

        private bool playing; // 플레이 중인지 확인용
        private bool entered; // 지금 들어와있는지 확인
        private bool threading; // 지금 스레드가 돌아가는지 확인

        public MultiPlay()
        {
            InitializeComponent();
            playing = false;    // 플레이, 들어온상태, 스레딩, 보드, 턴상태 모두 초기화시켜서 처음 들어왔을때의 상태를 만듬
            entered = false;
            threading = false;
            board = new Horse[edgeCount, edgeCount];
            nowTurn = false;
            tcpClient = LoginForm.tcpClient;
            stream = LoginForm.stream;
            if (Status.player == false)
            {
                readyButton.Visible = false;

                status.Text = "관전중....";
            }

            Thread.Sleep(10);
            thread = new Thread(new ThreadStart(read));
            thread.Start();
            threading = true; // 스레드가 시작되는것을 알림

            if (Status.player == false)
            {
                byte[] buf = Encoding.ASCII.GetBytes("[Observer]");
                stream.Write(buf, 0, buf.Length);
            }
        }

        private void CheckerBoard_MouseDown(object sender, MouseEventArgs e)
        {
            this.Invoke(new Action(delegate ()
            {
                if (Status.player == false)
                {
                    //MetroMessageBox.Show(this,"관전중입니다.");
                    return;
                }
                else if (!playing)
                {
                    MetroMessageBox.Show(this, "게임을 실행해주세요.");
                    return;
                }
                if (!nowTurn)
                {
                    return;
                }
                Graphics g = this.CheckerBoard.CreateGraphics();
                int x = e.X / rectSize;
                int y = e.Y / rectSize;
                if (x < 0 || y < 0 || x >= edgeCount || y >= edgeCount)
                {
                    MessageBox.Show("테두리를 벗어날 수 없습니다.");
                    return;
                }
                if (board[x, y] != Horse.none) return;
                
                board[x, y] = nowPlayer;
                SolidBrush brush;
                Pen pen = new Pen(Color.Black, 2);

                if (nowPlayer == Horse.BLACK)
                {
                     brush = new SolidBrush(Color.Black);
                }
                else
                {
                    brush = new SolidBrush(Color.White);
                }

                g.DrawEllipse(pen, x * rectSize, y * rectSize, rectSize, rectSize);
                g.FillEllipse(brush, x * rectSize, y * rectSize, rectSize, rectSize);

                /* 놓은 바둑돌의 위치 보내기 */
                //string message = "[Put]" + roomTextBox.Text + "," + x + "," + y;
                string message = "[Put]" + x + "," + y + "," + (nowPlayer == Horse.BLACK ? "B" : "W"); //[Put]1,2,B 전송
                byte[] buf = Encoding.ASCII.GetBytes(message);
                stream.Write(buf, 0, buf.Length);

                if (judge(nowPlayer))
                {
                    status.Text = "플레이어가 승리했습니다.";
                    playing = false;
                    readyButton.Text = "재시작";
                    readyButton.Enabled = true;
                    MetroMessageBox.Show(this, status.Text);
                    return;
                }

                else
                {
                    this.Invoke(new Action(delegate ()
                    {
                        status.Text = " 상대 플레이어의 차례입니다. ";
                    }));
                }
                nowTurn = false;
            }));
        }

        private bool judge(Horse Player)
        {
            for (int i = 0; i < edgeCount - 4; i++) // i를 +4 (가로의 5개확인) 그런데 +4를 하면 최대값이 넘어버린다. 따라서 -4를 해주어야한다.
            {
                for (int j = 0; j < edgeCount; j++)
                {
                    if (board[i, j] == nowPlayer && board[i + 1, j] == nowPlayer && board[i + 2, j] == nowPlayer
                        && board[i + 3, j] == nowPlayer && board[i + 4, j] == nowPlayer)
                    {
                        return true;
                    }
                }
            } // 가로 완성시 nowPlayer 승리!!!(처음 x를 먼저 썻으므로 가로가 x임, CheckerBoard_MouseDown 참조하면 [x, y]로 x가 먼저나옴 

            for (int i = 0; i < edgeCount; i++)
            {
                for (int j = 4; j < edgeCount; j++) // 세로값인 j를 -4(위로가는것을 확인) 따라서 최소값이 0이 되어야하므로 j를 4로둔다.
                {
                    if (board[i, j] == nowPlayer && board[i, j - 1] == nowPlayer && board[i, j - 2] == nowPlayer && board[i, j - 3] == nowPlayer && board[i, j - 4] == nowPlayer)
                    {
                        return true;
                    }
                }
            } // 세로 완성시 nowPlayer 승리!!

            for (int i = 0; i < edgeCount - 4; i++) // 오목은 5개가 만족해야하므로, 줄수 -4 를 넘으면, 절때로 완성할 수 없으므로
            {
                for (int j = 0; j < edgeCount - 4; j++)
                {
                    if (board[i, j] == nowPlayer && board[i + 1, j + 1] == nowPlayer && board[i + 2, j + 2] == nowPlayer && board[i + 3, j + 3] == nowPlayer && board[i + 4, j + 4] == nowPlayer)
                    {
                        return true;
                    }
                }
            } // x=y일때, 즉 아래에서 위, 오른쪽으로 가는 대각선 완성시 nowPlayer 승리!!

            for (int i = 4; i < edgeCount; i++) // 오목은 5개가 만족해야하므로, 줄수 -4 를 넘으면, 절때로 완성할 수 없으므로
            {
                for (int j = 0; j < edgeCount - 4; j++)
                {
                    if (board[i, j] == nowPlayer && board[i - 1, j + 1] == nowPlayer && board[i - 2, j + 2] == nowPlayer && board[i - 3, j + 3] == nowPlayer && board[i - 4, j + 4] == nowPlayer)
                    {
                        return true;
                    }
                }
            } // x=-y일때, 즉 왼쪽에서 오른쪽으로, 위에서 아래로 가능 대각선 완성시 nowPlayer 승리!!
            return false;
        }

        private void CheckerBoard_Paint(object sender, PaintEventArgs e)
        {
            this.Invoke(new Action(delegate ()
            {
                Graphics gp = e.Graphics;
                Color lineColor = Color.Black;
                Pen p = new Pen(lineColor, 2);
                // rectSize는 마진과 같은 개념으로서, 33 /2 만큼, 같이 떨어진 것을 의미한다.(한칸의 길이와 동일)
                // edgeCount는 줄의 수를 의미하고
                //(rectSize * edgeCount) - rectSize / 2는 줄의 길이를 의미한다. 
                gp.DrawLine(p, rectSize / 2, rectSize / 2, rectSize / 2, (rectSize * edgeCount) - rectSize / 2); // 좌측 선그림
                                                                                                                 // p의 팬슬로 (검은색 컬러로, 2의 두께를가진) (rectSize/2, rectSize/2), (rectSize/2, rectSize*edgeCount - rectSize /2)
                                                                                                                 // 위의 좌표를 잇는다.
                gp.DrawLine(p, rectSize / 2, rectSize / 2, (rectSize * edgeCount) - rectSize / 2, rectSize / 2); // 위측 선그림
                gp.DrawLine(p, rectSize / 2, (rectSize * edgeCount) - rectSize / 2, (rectSize * edgeCount) - rectSize / 2, (rectSize * edgeCount) - rectSize / 2); // 아래 선그림
                gp.DrawLine(p, (rectSize * edgeCount) - rectSize / 2, rectSize / 2, (rectSize * edgeCount) - rectSize / 2, (rectSize * edgeCount) - rectSize / 2);
                p = new Pen(lineColor, 1);

                for (int i = rectSize + rectSize / 2; i < rectSize * edgeCount - rectSize / 2; i += rectSize)
                {
                    // 줄의 길이 만큼 반복하고, 한칸의 길이만큼 띄어서 그린다.
                    gp.DrawLine(p, rectSize / 2, i, rectSize * edgeCount - rectSize / 2, i); // 가로방향 그리기
                    gp.DrawLine(p, i, rectSize / 2, i, rectSize * edgeCount - rectSize / 2); // 세로방향 그리기
                }
            }));
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {

        }

        private void refresh()
        {
            CheckerBoard.Invoke(new Action(delegate ()
            {
                this.CheckerBoard.Refresh();
                for (int i = 0; i < edgeCount; i++)
                    for (int j = 0; j < edgeCount; j++)
                        board[i, j] = Horse.none;
            }));
        }

        //private void enterButton_Click(object sender, EventArgs e)
        //{
        //    stream = LoginForm.tcpClient.GetStream();
        //}

        private void read()
        {
            while (true)
            {
                byte[] buf = new byte[1024]; // 1024의 바이트를 넣는다
                int bufBytes = stream.Read(buf, 0, buf.Length);
                string message = Encoding.UTF8.GetString(buf, 0, bufBytes);
                Pen pen = new Pen(Color.Black, 2);
                // 접속성공시 Enter반환(enterButton Click 참조

                if (Status.player == true)
                {
                    if (message.Contains("[Play]"))
                    {
                        refresh();
                        string horse = message.Split(']')[1];
                        if (horse.Contains("Black"))
                        {
                            status.Invoke(new Action(delegate ()
                            {
                                this.status.Text = "당신의 차례입니다.";
                            }));
                            nowTurn = true;
                            nowPlayer = Horse.BLACK;
                        }
                        else
                        {
                            status.Invoke(new Action(delegate ()
                            {
                                this.status.Text = "상대방의 차례입니다.";
                            }));
                            nowTurn = false;
                            nowPlayer = Horse.WHITE;
                        }
                        playing = true;
                    }
                    if (message.Contains("[Exit]"))
                    {
                        this.status.Text = "상대방이 나갔습니다.";
                        refresh();
                    }
                    /* 상대방이 돌을 둔 경우 (메시지: [Put]{X,Y}) */
                    if (message.Contains("[Put]"))
                    {
                        string position = message.Split(']')[1];
                        int x = Convert.ToInt32(position.Split(',')[0]);
                        int y = Convert.ToInt32(position.Split(',')[1]);
                        Horse enemyPlayer = Horse.none;
                        if (nowPlayer == Horse.BLACK)
                        {
                            enemyPlayer = Horse.WHITE;
                        }
                        else
                        {
                            enemyPlayer = Horse.BLACK;
                        }
                        if (board[x, y] != Horse.none) continue;
                        board[x, y] = enemyPlayer;
                        Graphics g = this.CheckerBoard.CreateGraphics();
                        SolidBrush brush;
                        if (enemyPlayer == Horse.BLACK)
                        {
                            brush = new SolidBrush(Color.Black);
                        }
                        else
                        {
                            brush = new SolidBrush(Color.White);
                        }
                        g.DrawEllipse(pen, x * rectSize, y * rectSize, rectSize, rectSize);
                        g.FillEllipse(brush, x * rectSize, y * rectSize, rectSize, rectSize);
                        if (judge(enemyPlayer))
                        {
                            status.Text = "패배했습니다.";
                            playing = false;
                        }
                        else
                        {
                            status.Text = "당신이 둘 차례입니다.";
                        }
                        nowTurn = true;
                    }
                    if (message.Contains("[Chats]"))
                    {
                        string s = message.Split(']')[1].Replace((char)0x02, ']');
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i] == ' ')
                            {
                                s = s.Insert(i, ": ");
                                break;
                            }
                        }
                        ChatDataTextBox.Invoke((MethodInvoker)delegate ()
                        {
                            ChatDataTextBox.AppendText($"{s} \n");
                            ChatDataTextBox.ScrollToCaret();
                        });
                    }
                }
                else
                {
                    if (message.Contains("[Put]"))
                    {
                        string s = message.Split(']')[1];

                        string[] position = s.Split(';');

                        Graphics g = this.CheckerBoard.CreateGraphics();

                        for (int i = 0; i < position.Length - 1; i++)
                        {
                            SolidBrush brush;
                            if (position[i].Split(',')[0] == "W")
                            {
                                brush = new SolidBrush(Color.White);
                            }
                            else
                            {
                                brush = new SolidBrush(Color.Black);
                            }

                            int x = Convert.ToInt32(position[i].Split(',')[1]);
                            int y = Convert.ToInt32(position[i].Split(',')[2]);
                            g.DrawEllipse(pen, x * rectSize, y * rectSize, rectSize, rectSize);
                            g.FillEllipse(brush, x * rectSize, y * rectSize, rectSize, rectSize);
                        }
                    }

                    else if (message.Contains("[Chats]"))
                    {
                        string s = message.Split(']')[1].Replace((char)0x02, ']');
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i] == ' ')
                            {
                                s = s.Insert(i, ": ");
                                break;
                            }
                        }

                       ChatDataTextBox.Invoke((MethodInvoker)delegate ()
                       {
                           ChatDataTextBox.AppendText($"{s} \n");
                           ChatDataTextBox.ScrollToCaret();
                       });

                    }
                }
            }
        }

        private void closeNetwork()
        {
            if (threading && WaitingRoom.thread.IsAlive)
                WaitingRoom.thread.Abort(); // 스레드가 아직 실행중이면 강제종료(끌시 호출되는 메서드므로)
            if (entered)
            {
                tcpClient.Close();
            }
        }

        private void MultiPlay_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
            
        }

        private void childForm_Closed(object sender, FormClosedEventArgs e)
        {

        }

        private void MultiPlay_Load(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate ()
            {
                this.Activate();
            }));
        }

        private void status_Click(object sender, EventArgs e)
        {

        }

        private void readyButton_Click(object sender, EventArgs e)
        {
            status.Text = "Ready";
            byte[] buf = Encoding.ASCII.GetBytes($"[PlayingRoom]Ready");
            stream.Write(buf, 0, buf.Length);
            readyButton.Enabled = false;
        }

        private void ChatTile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ChatTextBox.Text))
            {
                byte[] buf = Encoding.UTF8.GetBytes("[PlayingRoom]Chats" + (char)0x01 + ChatTextBox.Text);  //한글로 보낼려면 UTF8로.!!
                LoginForm.stream.Write(buf, 0, buf.Length);
                ChatTextBox.Clear();
            }
            ChatTextBox.Text = string.Empty;
        }

        private void ChatTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ChatTile_Click(sender, e);
            }
        }
    }
}
