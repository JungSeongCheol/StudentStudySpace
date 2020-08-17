using MetroFramework;
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

namespace WinFormGomku
{
    public partial class SinglePlay : MetroForm
    {
        private const int rectSize = 33; // 오목판 셀 수
        private const int edgeCount = 15; // 오목판 선 갯수

        private enum Horse { none = 0, BLACK, WHITE};
        private Horse[,] board = new Horse[edgeCount, edgeCount]; 
        private Horse nowPlayer = Horse.BLACK;

        private bool playing = false;

        public SinglePlay()
        {
            InitializeComponent();
        }

        private void CheckerBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (!playing)
            {
                MetroMessageBox.Show(this, "게임을 실행해야 작동합니다. '게임시작' 버튼을 눌러주세요.");
                return;
            }

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

            SolidBrush brush = new SolidBrush(Color.White); // 기본적으로 하얀색
            Pen pen = new Pen(Color.Black, 2);

            if (nowPlayer == Horse.BLACK)
            {
                 brush = new SolidBrush(Color.Black); // 검은색깔돌로 원을 채우기 위한 브러쉬 사용
            }

            g.DrawEllipse(pen, x * rectSize, y * rectSize, rectSize, rectSize); //흰색돌의 테두리부분을 잡아주기위해서
            g.FillEllipse(brush, x * rectSize, y * rectSize, rectSize, rectSize);

            if (judge())
            {
                status.Text = nowPlayer.ToString() + " 플레이어가 승리했습니다.";
                MetroMessageBox.Show(this, status.Text);
                PlayButton.Text = "게임시작";
            }

            else
            {
                nowPlayer = ((nowPlayer == Horse.BLACK) ? Horse.WHITE : Horse.BLACK); //검은색이면 화이트로, 아니면 블랙으로
                status.Text = nowPlayer.ToString() + " 플레이어의 차례입니다. ";
            }
        }

        private bool judge()
        {
            for(int i = 0; i < edgeCount - 4; i++) // i를 +4 (가로의 5개확인) 그런데 +4를 하면 최대값이 넘어버린다. 따라서 -4를 해주어야한다.
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
                    if (board[i, j] == nowPlayer && board[i, j-1] == nowPlayer && board[i, j -2] == nowPlayer && board[i, j - 3] == nowPlayer && board[i, j-4] == nowPlayer)
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
            gp.DrawLine(p, (rectSize * edgeCount) - rectSize / 2, rectSize/2, (rectSize * edgeCount) - rectSize / 2, (rectSize * edgeCount) - rectSize / 2);
            p = new Pen(lineColor, 1);

            for (int i = rectSize + rectSize / 2; i < rectSize * edgeCount - rectSize / 2; i += rectSize)
            {
                // 줄의 길이 만큼 반복하고, 한칸의 길이만큼 띄어서 그린다.
                gp.DrawLine(p, rectSize / 2, i, rectSize * edgeCount - rectSize / 2, i); // 가로방향 그리기
                gp.DrawLine(p, i, rectSize / 2, i, rectSize * edgeCount - rectSize / 2); // 세로방향 그리기
            }

        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                refresh();
                playing = true;
                PlayButton.Text = "재시작";
                status.Text = nowPlayer.ToString() + " 플레이어의 차례입니다.";
            }
            else
            {
                refresh();
                status.Text = "게임이 재시작되었습니다.";
            }
        }

        private void refresh()
        {
            this.CheckerBoard.Refresh();
            for (int i = 0; i < edgeCount; i++)
                for (int j = 0; j < edgeCount; j++)
                    board[i, j] = Horse.none;
        }
    }
}
