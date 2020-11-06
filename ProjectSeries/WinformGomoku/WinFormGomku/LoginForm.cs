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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WinFormGomku
{
    public partial class LoginForm : MetroForm
    {
        public static TcpClient tcpClient;
        public static NetworkStream stream;


        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect("127.0.0.1", 9876);
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "서버가 켜져있지 않습니다. 서버를 먼저 켜주세요", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            stream = tcpClient.GetStream();

            if (string.IsNullOrEmpty(LoginIdTextBox.Text) && string.IsNullOrEmpty(PasswordTestBox.Text))
            {
                MetroMessageBox.Show(this, "아이디, 비밀번호를 입력해 주세요", "로그인 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginForm_Load(sender, e);
                tcpClient.Close();
                return;
            }

            else if (string.IsNullOrEmpty(LoginIdTextBox.Text))
            {
                MetroMessageBox.Show(this, "아이디를 입력해 주세요", "로그인 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginForm_Load(sender, e);
                tcpClient.Close();
                return;
            }

            else if (string.IsNullOrEmpty(PasswordTestBox.Text))
            {
                MetroMessageBox.Show(this, "비밀번호를 입력해 주세요", "로그인 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginForm_Load(sender, e);
                tcpClient.Close();
                return;
            }

            byte[] buf = new byte[256];
            buf = Encoding.ASCII.GetBytes("[Login]" + LoginIdTextBox.Text + "," + PasswordTestBox.Text);
            stream.Write(buf, 0, buf.Length);
            int bufBytes = stream.Read(buf, 0, buf.Length);

            string message = Encoding.ASCII.GetString(buf, 0, bufBytes);

            if(message == "OK"){
                Hide();
                WaitingRoom waitingRoom = new WaitingRoom();
                waitingRoom.FormClosed += new FormClosedEventHandler(childForm_Closed);
                waitingRoom.Show();
            }

            else if(message == "already")
            {
                MetroMessageBox.Show(this, "실행중인 아이디가 있습니다.", "로그인 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tcpClient.Close();
                return;
            }

            else if(message == "invalid")
            {
                MetroMessageBox.Show(this, "아이디, 또는 비밀번호가 일치하지 않습니다.", "로그인 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tcpClient.Close();
                return;
            }
        }

        private void childForm_Closed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = LoginIdTextBox; // 로드시 자동포커스
        }

        private void PasswordTestBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                LoginButton_Click(sender, e);
            }
        }

        private void LoginIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                LoginButton_Click(sender, e);
            }
        }

        private void SignUpLink_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Hide();
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.FormClosed += new FormClosedEventHandler(childForm_Closed);
            signUpForm.Show();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(tcpClient != null)
            {
                tcpClient.Close();
            }
        }
    }
}
