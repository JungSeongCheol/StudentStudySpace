using System;
using BookRentalShopApp2020.SubItems;
using MetroFramework;
using MetroFramework.Forms;
using System.Windows.Forms;
using BookRentalShopApp2020.NewFolder1;

namespace BookRentalShopApp2020
{
    public partial class MainForm : MetroForm // Form
    {
        #region 생성자 영역
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 이벤트 핸들러 영역
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();

            LbUserID.Text = $"LOGIN : {Commons.USERID}";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MetroMessageBox.Show(this, "종료하시겠습니까?", "종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) // 프로그램 종료
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
            ShowFormControl(form, "구분코드관리");
        }

        private void MnuItemBooksMng_Click(object sender, EventArgs e)
        {
            BooksMngForm form = new BooksMngForm();
            ShowFormControl(form, "도서관리");
        }

        private void MnuItemMemsMng_Click(object sender, EventArgs e)
        {
            MembersMngForm form = new MembersMngForm();
            ShowFormControl(form, "멤버관리");
        }

        private void MnuItemRentalMng_Click(object sender, EventArgs e)
        {
            RentalMngForm form = new RentalMngForm();
            ShowFormControl(form, "대여관리");
        }

        private void MnuItemUserMng_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 커스텀 메서드 영역
        private void ShowFormControl(Form form, string title)
        {
            form.MdiParent = this;
            form.Text = title;
            form.Dock = DockStyle.Fill;
            form.Show();
            form.WindowState = FormWindowState.Normal;
        }
        #endregion
    }
}
