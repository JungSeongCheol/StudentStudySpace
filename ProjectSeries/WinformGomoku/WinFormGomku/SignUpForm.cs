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

namespace WinFormGomku
{
    public partial class SignUpForm : MetroForm
    {
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void childForm_Closed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Activate();
            IdTextBox.Focus(); // 로드시 자동으로 액티브하고(활성화 시키고) 그걸로 자동 포커스 가게 만들었습니다.
        }

        private void PasswordTestBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SignUpButton_Click(sender, e);
            }
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect("127.0.0.1", 9876);
            networkStream = tcpClient.GetStream();

            if (string.IsNullOrEmpty(IdTextBox.Text) && string.IsNullOrEmpty(PasswordTestBox.Text))
            {
                MetroMessageBox.Show(this, "아이디, 비밀번호를 입력해 주세요", "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginForm_Load(sender, e);
                tcpClient.Close();
                return;
            }

            else if (string.IsNullOrEmpty(IdTextBox.Text))
            {
                MetroMessageBox.Show(this, "아이디를 입력해 주세요", "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginForm_Load(sender, e);
                tcpClient.Close();
                return;
            }

            else if (string.IsNullOrEmpty(PasswordTestBox.Text))
            {
                MetroMessageBox.Show(this, "비밀번호를 입력해 주세요", "회원가입 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginForm_Load(sender, e);
                tcpClient.Close();
                return;
            }

            byte[] buf = new byte[256];
            buf = Encoding.ASCII.GetBytes("[SignUp]" + IdTextBox.Text + "," + PasswordTestBox.Text);
            networkStream.Write(buf, 0, buf.Length);
            int bufBytes = networkStream.Read(buf, 0, buf.Length);

            string message = Encoding.ASCII.GetString(buf, 0, bufBytes);

            if(message == "SignUpOk")
            {
                MetroMessageBox.Show(this, "회원가입이 완료되었습니다.", "회원가입 완료");
                tcpClient.Close();
                this.Close();
            }
            else if(message == "SignUpFalse")
            {
                MetroMessageBox.Show(this, "회원가입이 실패했습니다.", "회원가입 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tcpClient.Close();
            }
        }

        private void IdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SignUpButton_Click(sender, e);
            }
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }
    }
}
