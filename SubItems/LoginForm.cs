using BookRentalShopApp2020.NewFolder1;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalShopApp2020.SubItems
{
    public partial class LoginForm : MetroForm
    {
        //private readonly string strConnectionString = "Data Source=localhost;Port=3306;Database=bookrentalshop;Uid=root;Password=mysql_p@ssw0rd";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void TxtPassWord_Click(object sender, EventArgs e)
        {

        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }

        private void LoginProcess()
        {
            // 빈값비교 처리
            if(string.IsNullOrEmpty(TextUserID.Text) || string.IsNullOrEmpty(TxtPassWord.Text))
            {
                MetroMessageBox.Show(this, "아이디나 패스워드를 입력하세요!", "로그인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TextUserID.Text = TxtPassWord.Text = string.Empty;
                TextUserID.Focus();
                return;
            }

            //실제 DB처리
            string resultId = string.Empty; // ""

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.COMNSTR))
                {
                    conn.Open();
                    //MetroMessageBox.Show(this, $"DB접속성공!!");
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT userID FROM userTBL " + //반드시 뒤에 SpaceBar를 넣어줘야됨(안넣으면 userTBLWHERE로 붙어져서 Syntax Error나옴)
                                      " WHERE userID = @userID " +    //@userID로 사용안하고 직접적 ID(TxtUserID)를 바로 넣으면 SQL Injection으로 해킹위험이 나옴
                                      "   AND password = @password ";
                    MySqlParameter paramUserId = new MySqlParameter("@UserID", MySqlDbType.VarChar, 12);
                    paramUserId.Value = TextUserID.Text.Trim(); // 공백 넣는 경우가 아주 많기때문에
                    MySqlParameter ParamPassword = new MySqlParameter("@password", MySqlDbType.VarChar);
                    
                    var md5Hash = MD5.Create();
                    var cryptoPassWord = Commons.GETMD5Hash(md5Hash, TxtPassWord.Text.Trim());
                    ParamPassword.Value = cryptoPassWord;

                    cmd.Parameters.Add(paramUserId);
                    cmd.Parameters.Add(ParamPassword);
                    
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    if (!reader.HasRows)
                    {
                        MetroMessageBox.Show(this, "아이디나 패스워드를 정확히 입력하세요", "로그인실패",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextUserID.Text = TxtPassWord.Text = string.Empty;
                        TextUserID.Focus();
                        return;
                    }

                    else
                    {
                        resultId = reader["userID"] != null ? reader["userID"].ToString() : string.Empty;
                        Commons.USERID = resultId; //2020 12:30 추가
                        MetroMessageBox.Show(this, $"{resultId} 로그인 성공");
                    }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"DB접속에러 : {ex.Message}", "로그인에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            if (string.IsNullOrEmpty(resultId))
            {
                TextUserID.Text = TxtPassWord.Text = string.Empty;
                TextUserID.Focus();
                return;
            }
            else this.Close();

        }

        private void TextUserID_Click(object sender, EventArgs e)
        {

        }

        private void TextUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                TxtPassWord.Focus();
            }
        }

        private void TxtPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                BtnOK_Click(sender, new EventArgs());
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            
        }
    }
}
