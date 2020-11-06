using System;
using BookRentalShopApp2020.SubItems;
using MetroFramework;
using MetroFramework.Forms;
using System.Windows.Forms;

namespace BookRentalShopApp2020
{
    public partial class MainForm : MetroForm // Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }

        private void 관리MToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MetroMessageBox.Show(this, "종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes) // 프로그램 종료
            {
                e.Cancel = false; // 종료
                Environment.Exit(0); // 완전종료
            }
            else
            {
                e.Cancel = true; // 프로그램 종료 하지 않음
            }
        }

        private void MnuItemExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void MnuItemCodeMng_Click(object sender, EventArgs e)
        {
            DevMngForm form = new DevMngForm();
            form.MdiParent = this;
            form.Text = "구분코드 관리";
            form.Dock = DockStyle.Fill;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }
    }
}
