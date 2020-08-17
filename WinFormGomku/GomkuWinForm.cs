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
    public partial class GomkuWinForm : MetroForm
    {
        public GomkuWinForm()
        {
            InitializeComponent();
        }

        private void SinglePlayButton_Click(object sender, EventArgs e)
        {
            Hide();
            SinglePlay singlePlay = new SinglePlay();
            singlePlay.FormClosed += new FormClosedEventHandler(childForm_Closed); // 창닫을때 이 폼이 자동으로 보여줌
            singlePlay.Show();
        }

        private void childForm_Closed(object sender, FormClosedEventArgs e)
        {
            this.Show();

        }

        private void ExitTile_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MultiPlayTile_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += new FormClosedEventHandler(childForm_Closed);
            loginForm.Show();

            //MultiPlay multiPlay = new MultiPlay();
            //multiPlay.FormClosed += new FormClosedEventHandler(childForm_Closed);
            //multiPlay.Show();
        }

        private void AITile_Click(object sender, EventArgs e)
        {
            Hide();
            VsAIForm vsAIForm = new VsAIForm();
            vsAIForm.FormClosed += new FormClosedEventHandler(childForm_Closed); // 창닫을때 이 폼이 자동으로 보여줌
            vsAIForm.Show();
        }

        private void GomkuWinForm_Load(object sender, EventArgs e)
        {

        }
    }
}
