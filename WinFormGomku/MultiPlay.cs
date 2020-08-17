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

namespace WinFormGomku
{
    public partial class MultiPlay : MetroForm
    {
        //private Thread thread; // 통신용 스레드 선언
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
            this.Invoke(new Action(delegate ()
            {
                this.PlayButton.Enabled = false;
                playing = false;    // 플레이, 들어온상태, 스레딩, 보드, 턴상태 모두 초기화시켜서 처음 들어왔을때의 상태를 만듬
                entered = false;
                threading = false;
                board = new Horse[edgeCount, edgeCount];
                nowTurn = false;
                tcpClient = LoginForm.tcpClient;
            }));

        }

        private void CheckerBoard_MouseDown(object sender, MouseEventArgs e)
        {
            this.Invoke(new Action(delegate ()
            {
                if (!playing)
                {
                    MetroMessageBox.Show(this, "게임을 실행해야 작동합니다. '게임시작' 버튼을 눌러주세요.");
                    return;
                }
                if (!nowTurn) // 현재 턴이 아닐시 실행안됨
                    return;

                Graphics g = this.CheckerBoard.CreateGraphics();
                int x = e.X / rectSize; // 마우스의 위치의 X좌표를 이용 (rectSize는 바둑알의 위치를 잡아 주기위해, 이 좌표안에 들어갔을시 놓아짐)
                int y = e.Y / rectSize; // 마우스의 위치의 Y좌표를 이용
            
                if(x < 0 || y < 0 || x >= edgeCount || y >= edgeCount)
                {
                    // 좌표를 벗어났을시
                    MetroMessageBox.Show(this, "바둑판 안에 만 놓을수 있습니다.", "규칙을 지켜주세요");
                    return;
                }

                if (board[x, y] != Horse.none) return;
                board[x, y] = nowPlayer;

                SolidBrush brush;
                Pen pen = new Pen(Color.Black, 2);

                if (nowPlayer == Horse.BLACK)
                {
                     brush = new SolidBrush(Color.Black); // 검은색깔돌로 원을 채우기 위한 브러쉬 사용
                }
                else
                {
                    brush = new SolidBrush(Color.White); //하얀색돌로 원을 그림
                }

                g.DrawEllipse(pen, x * rectSize, y * rectSize, rectSize, rectSize); //흰색돌의 테두리부분을 잡아주기위해서
                g.FillEllipse(brush, x * rectSize, y * rectSize, rectSize, rectSize);

                string message = "[Put]" + roomTextBox.Text + "," + x + "," + y; // 놓은 위치 메세지
                byte[] buf = Encoding.ASCII.GetBytes(message);
                stream.Write(buf, 0, buf.Length);

                if (judge(nowPlayer))
                {
                    status.Text = "플레이어가 승리했습니다.";
                    playing = false;
                    PlayButton.Text = "재시작";
                    PlayButton.Enabled = true;
                    MetroMessageBox.Show(this, status.Text);
                    return;
                }

                else
                {
                    this.Invoke(new Action(delegate ()
                    {
                        status.Text = " 상대 플레이어의 차례입니다. ";
                        nowTurn = false;
                    }));
                }
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
            this.Invoke(new Action(delegate ()
            {
                if (!playing)
                {
                    refresh();
                    playing = true;
                    string message = "[Play]";
                    byte[] buf = Encoding.ASCII.GetBytes(message + this.roomTextBox.Text); // 아스키 코드로 읽어야됨.
                    stream.Write(buf, 0, buf.Length);
                    this.status.Text = "상대 플레이어를 기다립니다.";
                    this.PlayButton.Enabled = false;
                }
            }));
        }

        private void refresh()
        {
            this.Invoke(new Action(delegate ()
            {
                this.CheckerBoard.Refresh();
                for (int i = 0; i < edgeCount; i++)
                    for (int j = 0; j < edgeCount; j++)
                        board[i, j] = Horse.none;
                PlayButton.Enabled = false; // 지금 Playbutton을 누르지 못하게 만든다.
            }));

        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    tcpClient.Connect("127.0.0.1", 9876); // localhost로 임시로 사용한것일뿐, 나중에는 얼마든 변경가능
            //}
            //catch(Exception)
            //{
            //    MetroMessageBox.Show(this, $"서버가 켜져있지 않습니다.", "접속오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}


            //stream = tcpClient.GetStream();

            stream = LoginForm.tcpClient.GetStream();

            WaitingRoom.thread = new Thread(new ThreadStart(read));
            WaitingRoom.thread.Start();
            threading = true; // 스레드가 시작되는것을 알림

            string message = "[Enter]";
            byte[] buf = Encoding.ASCII.GetBytes(message + this.roomTextBox.Text);
            stream.Write(buf, 0, buf.Length);

        }

        private void read()
        {
            while (true)
            {
                byte[] buf = new byte[1024]; // 1024의 바이트를 넣는다
                int bufBytes = stream.Read(buf, 0, buf.Length);
                string message = Encoding.ASCII.GetString(buf, 0, bufBytes);
                Pen pen = new Pen(Color.Black, 2);
                // 접속성공시 Enter반환(enterButton Click 참조
                if (message.Contains("[Enter]")) //Contains는 message에 포함된 문자열이 있을시 불형태!! 로 true, false반환하는것이다.
                {
                    this.Invoke(new Action(delegate ()
                    {
                        this.status.Text = "[" + this.roomTextBox.Text + "] 방에 접속했습니다.";
                        this.roomTextBox.Enabled = false;
                        this.enterButton.Enabled = false;
                        entered = true;
                    }));
                }

                if(message.Contains("[Full"))
                {
                    this.status.Text = "이미 가득 찬 방입니다.";
                    //closeNetwork();
                }
                // 게임시작시
                if (message.Contains("[Play]"))
                {
                    refresh();
                    string horse = message.Split(']')[1];
                    if (horse.Contains("Black"))
                    {
                        this.Invoke(new Action(delegate ()
                        {
                            this.status.Text = "당신의 차례입니다.";
                            nowTurn = true;
                            nowPlayer = Horse.BLACK;
                        }));

                    }
                    else
                    {
                        this.Invoke(new Action(delegate ()
                        {
                            this.status.Text = "상대방의 차례입니다.";
                            nowTurn = false;
                            nowPlayer = Horse.WHITE;
                        }));
                    }
                    playing = true;
                }

                if (message.Contains("[Exit]"))
                {

                    this.Invoke(new Action(delegate ()
                    {
                        this.status.Text = "상대방이 나갔습니다.";
                        refresh();
                    }));

                }

                if (message.Contains("[Put]"))
                {
                    string position = message.Split(']')[1];
                    int x = Convert.ToInt32(position.Split(',')[0]);
                    int y = Convert.ToInt32(position.Split(',')[1]);
                    Horse enemyPlayer = Horse.none;
                    SolidBrush brush;
                    if(nowPlayer == Horse.BLACK)
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
                    
                    if (enemyPlayer == Horse.BLACK)
                        brush = new SolidBrush(Color.Black);
                    else
                        brush = new SolidBrush(Color.White);

                    g.DrawEllipse(pen, x * rectSize, y * rectSize, rectSize, rectSize);
                    g.FillEllipse(brush, x * rectSize, y * rectSize, rectSize, rectSize);

                    if (judge(enemyPlayer))
                    {
                        status.Text = "패배했습니다.";
                        playing = false;
                        PlayButton.Text = "재시작";
                        PlayButton.Enabled = true;
                    }

                    else
                    {
                        status.Text = "당신이 둘 차례입니다.";
                    }
                    nowTurn = true;
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
            //closeNetwork();
            WaitingRoom waitingRoom = new WaitingRoom();
            waitingRoom.FormClosed += new FormClosedEventHandler(childForm_Closed);
            waitingRoom.Show();
        }

        private void childForm_Closed(object sender, FormClosedEventArgs e)
        {
            //GomkuWinForm gomkuWinForm = new GomkuWinForm();
            //gomkuWinForm.Show();

        }

        private void MultiPlay_Load(object sender, EventArgs e)
        {
            this.Invoke(new Action(delegate ()
            {
                this.Activate();
            }));
        }

        private void roomTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Invoke(new Action(delegate ()
            {
                if (e.KeyChar == (char)13)
                {
                    enterButton_Click(sender, e);
                }
            }));
        }
    }
}
