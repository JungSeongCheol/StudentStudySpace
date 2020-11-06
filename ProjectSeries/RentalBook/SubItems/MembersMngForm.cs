using BookRentalShopApp2020.NewFolder1;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BookRentalShopApp2020.SubItems
{
    public partial class MembersMngForm : MetroForm
    {
        //DataGridViewRow data = GrdBooksTbl.Rows[e.RowIndex];
        #region 멤버변수 영역
        private string strTblName = "memberTbl";

        BaseMode myMode = BaseMode.NONE;    // 초기 상태(아무것도 하지 않음)
        #endregion;

        #region 생성자 영역
        public MembersMngForm()
        {
            InitializeComponent();
            TxtIdx.Select();
        }
        #endregion

        #region 이벤트 핸들러 영역
        private void DevMngForm_Load(object sender, EventArgs e)
        {
            UpdateData();
            InitControls();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (myMode != BaseMode.UPDATE)
            {
                MetroMessageBox.Show(this, "삭제할 데이터를 선택하세요", "알림");
                return;
            }

            myMode = BaseMode.DELETE;
            SaveData();
            InitControls();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            TxtIdx.Text = TxtNames.Text = string.Empty;
            TxtIdx.ReadOnly = true;
            myMode = BaseMode.INSERT;   //신규 입력 모드
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //         myMode = BaseMode.UPDATE;
            SaveData();
            InitControls();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            InitControls();
        }
        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdBooksTbl.Rows[e.RowIndex];
                int index;
                // TODO : 클릭시 입력컨트롤에 데이터 할당
                TxtIdx.Text = data.Cells[0].Value.ToString();
                TxtNames.Text = data.Cells[1].Value.ToString();

                index = char.Parse(data.Cells[2].Value.ToString()) - 64;
                CboLevel.SelectedIndex = index;
                TxtAddr.Text = data.Cells[3].Value.ToString();
                TxtMobile.Text = data.Cells[4].Value.ToString();
                TxtEmail.Text = data.Cells[5].Value.ToString();

                TxtIdx.ReadOnly = true;
                TxtNames.Focus();

                myMode = BaseMode.UPDATE; // 수정 모드 변경(셀 눌렀을시)
            }
        }
        #endregion

        #region 커스텀 메서드 영역
        private void UpdateComboDivision()
        {
            // A, B, C, D
            var KeyValues = new Dictionary<string, string>();

            KeyValues.Add("선택", "");
            KeyValues.Add("A", "A");
            KeyValues.Add("B", "B");
            KeyValues.Add("C", "C");
            KeyValues.Add("D", "D");

            CboLevel.DataSource = new BindingSource(KeyValues, null);
            CboLevel.DisplayMember = "Key";
            CboLevel.ValueMember = "Value";
        }

        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.COMNSTR))
            {
                string strQuery = $" SELECT Idx, " +
                                   "        Names,  " +
                                   "        Levels, " +
                                   "        Addr, " +
                                   "        Mobile, " +
                                   "        Email " +
                                   " FROM membertbl ";

                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);    //소켓처럼 생성(데이터를 넣을수 있는 어뎁터를 생성)
                DataSet ds = new DataSet();
                adapter.Fill(ds, strTblName);

                GrdBooksTbl.DataSource = ds;
                GrdBooksTbl.DataMember = strTblName;
            }

            SetColumHeaders();
        }

        private void SetColumHeaders()
        {
            DataGridViewColumn column;

            column = GrdBooksTbl.Columns[0];
            column.Width = 100;
            column.HeaderText = "번호";

            column = GrdBooksTbl.Columns[1];
            column.Width = 120;
            column.HeaderText = "이름";

            column = GrdBooksTbl.Columns[2];
            column.Width = 120;
            column.HeaderText = "레벨";

            column = GrdBooksTbl.Columns[3];    // 구분코드명
            column.Width = 150;
            column.HeaderText = "주소";

            column = GrdBooksTbl.Columns[4];
            column.Width = 120;
            column.HeaderText = "전화번호";

            column = GrdBooksTbl.Columns[5];    // 출간일
            column.Width = 150;
            column.HeaderText = "이메일";
        }

        private void InitControls()
        {
            TxtIdx.Text = TxtNames.Text = string.Empty;
            TxtEmail.Text = TxtAddr.Text = TxtMobile.Text = string.Empty;
            TxtIdx.ReadOnly = true;
            CboLevel.SelectedIndex = 0;

            TxtNames.Focus();

            myMode = BaseMode.NONE;
        }


        /// <summary>
        /// DB 업데이트 및 입력 처리
        /// </summary>
        private void SaveData()
        {
            if (string.IsNullOrEmpty(TxtNames.Text) ||
                CboLevel.SelectedIndex == 0 ||
                string.IsNullOrEmpty(TxtAddr.Text) ||
                string.IsNullOrEmpty(TxtMobile.Text) ||
                string.IsNullOrEmpty(TxtEmail.Text))
            {
                MetroMessageBox.Show(this, "빈값을 넣을 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (myMode == BaseMode.NONE)
            {
                MetroMessageBox.Show(this, "신규 등록시 신규 버튼을 눌러주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.COMNSTR))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    if (myMode == BaseMode.UPDATE)
                    {
                        cmd.CommandText = " UPDATE membertbl " +
                                          " SET Names = @Names, " +
                                          "     Levels = @Levels, " +
                                          "     Addr = @Addr, " +
                                          "     Mobile = @Mobile, " +
                                          "     Email = @Email " +
                                          " WHERE Idx = @Idx ";
                    }

                    else if (myMode == BaseMode.INSERT)
                    {
                        cmd.CommandText = " INSERT INTO membertbl " +
                                          "            (Names, " +
                                          "             Levels, " +
                                          "             Addr, " +
                                          "             Mobile, " +
                                          "             Email) " +
                                          "       VALUES " +
                                          "            (@Names, " +
                                          "             @Levels, " +
                                          "             @Addr, " +
                                          "             @Mobile, " +
                                          "             @Email); ";
                    }

                    // 저자명
                    MySqlParameter paramNames = new MySqlParameter("@Names", MySqlDbType.VarChar, 45)
                    {
                        Value = TxtNames.Text
                    };
                    cmd.Parameters.Add(paramNames);

                    // 책이름
                    MySqlParameter paramLevels = new MySqlParameter("@Levels", MySqlDbType.VarChar, 1)
                    {
                        Value = Convert.ToChar(CboLevel.SelectedIndex + 64)
                    };
                    cmd.Parameters.Add(paramLevels);

                    //ISBN
                    MySqlParameter paramAddr = new MySqlParameter("@Addr", MySqlDbType.VarChar, 100)
                    {
                        Value = TxtAddr.Text
                    };
                    cmd.Parameters.Add(paramAddr);

                    //Price
                    MySqlParameter paramMobile = new MySqlParameter("@Mobile", MySqlDbType.VarChar, 13)
                    {
                        Value = TxtMobile.Text
                    };
                    cmd.Parameters.Add(paramMobile);

                    MySqlParameter paramEmail = new MySqlParameter("@Email", MySqlDbType.VarChar, 50)
                    {
                        Value = TxtEmail.Text
                    };
                    cmd.Parameters.Add(paramEmail);

                    if (myMode == BaseMode.UPDATE)
                    {
                        // Idx : PK
                        MySqlParameter paramIdx = new MySqlParameter("@Idx", MySqlDbType.Int32)
                        {
                            Value = TxtIdx.Text
                        };
                        cmd.Parameters.Add(paramIdx);
                    }

                    var result = cmd.ExecuteNonQuery();

                    if (myMode == BaseMode.INSERT)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 신규입력되었습니다.", "신규입력");
                    }
                    else if (myMode == BaseMode.UPDATE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 수정되었습니다.", "수정");
                    }
                }
            }

            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"에러 발생 {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            finally
            {
                UpdateData();
            }
        }

        #endregion

    }
}
