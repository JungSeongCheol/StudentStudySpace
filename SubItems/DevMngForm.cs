using BookRentalShopApp2020.NewFolder1;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BookRentalShopApp2020.SubItems
{
    public partial class DevMngForm : MetroForm
    {
        private string strTblName = "divTbl";

        BaseMode myMode = BaseMode.NONE;    // 초기 상태(아무것도 하지 않음)

        public DevMngForm()
        {
            InitializeComponent();
            TxtDivision.Select();
        }

        private void DevMngForm_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.COMNSTR))
            {
                string strQuery = $"SELECT division, Names FROM divTbl {strTblName} ";
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);    //소켓처럼 생성(데이터를 넣을수 있는 어뎁터를 생성)
                DataSet ds = new DataSet();
                adapter.Fill(ds, strTblName);

                GrdDivTbl.DataSource = ds;
                GrdDivTbl.DataMember = strTblName;
            }

            SetColumHeaders();
        }

        private void SetColumHeaders()
        {
            DataGridViewColumn column;

            column = GrdDivTbl.Columns[0];
            column.Width = 100;
            column.HeaderText = "구분코드";

            column = GrdDivTbl.Columns[1];
            column.Width = 150;
            column.HeaderText = "이름";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(myMode != BaseMode.UPDATE)
            {
                MetroMessageBox.Show(this, "삭제할 데이터를 선택하세요", "알림");
                return;
            }

            myMode = BaseMode.DELETE;
            SaveDate();
            InitControls();
        }

        private void InitControls()
        {
            TxtDivision.Text = TxtNames.Text = string.Empty;
            TxtDivision.Focus();

            myMode = BaseMode.NONE;
        }

        #region Delete삭제처리
        //   private void DeleteProcess()
        // {

        //try
        //{
        //    using (MySqlConnection conn = new MySqlConnection(Commons.COMNSTR))
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand();
        //        cmd.Connection = conn;

        //        cmd.CommandText = " DELETE FROM divtbl " +
        //                          " WHERE Division = @Division ";

        //        MySqlParameter paramDivision = new MySqlParameter("@Division", MySqlDbType.VarChar);
        //        paramDivision.Value = TxtDivision.Text;
        //        cmd.Parameters.Add(paramDivision);

        //        var result = cmd.ExecuteNonQuery();


        //    }
        //}
        //catch (Exception ex)
        //{
        //    MetroMessageBox.Show(this, $"에러발생 {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        //finally
        //{
        //    UpdateData();
        //}

        //      SaveDate();
        //    }
        #endregion
        private void BtnNew_Click(object sender, EventArgs e)
        {
            TxtDivision.Text = TxtNames.Text = string.Empty;
            TxtDivision.ReadOnly = false;
            myMode = BaseMode.INSERT;   //신규 입력 모드
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
   //         myMode = BaseMode.UPDATE;
            SaveDate();
            InitControls();
        }

        /// <summary>
        /// DB 업데이트 및 입력 처리
        /// </summary>
        private void SaveDate()
        {
            if (string.IsNullOrEmpty(TxtDivision.Text) || string.IsNullOrEmpty(TxtNames.Text))
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

                    if(myMode == BaseMode.UPDATE)
                    {
                        cmd.CommandText = "UPDATE divtbl " + //UPDATE문
                                          "   SET Names = @Names " +
                                          " WHERE Division = @Division ";
                    }

                    else if(myMode == BaseMode.INSERT)
                    {
                        cmd.CommandText = " INSERT INTO " +
                                          " divtbl (Division, Names) " +
                                          " VALUES (@Division, @Names) ";

                    }

                    else if(myMode == BaseMode.DELETE)
                    {
                        cmd.CommandText = " DELETE FROM divtbl " +
                                          " WHERE Division = @Division ";
                    }

                    if(myMode == BaseMode.INSERT || myMode ==BaseMode.UPDATE)
                    {
                        MySqlParameter paramNames = new MySqlParameter("@Names", MySqlDbType.VarChar, 45);
                        paramNames.Value = TxtNames.Text;
                        cmd.Parameters.Add(paramNames);
                    }

                    MySqlParameter paramDivision = new MySqlParameter("@Division", MySqlDbType.VarChar);
                    paramDivision.Value = TxtDivision.Text;
                    cmd.Parameters.Add(paramDivision);

                    var result = cmd.ExecuteNonQuery();


                    if(myMode == BaseMode.INSERT)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 신규입력되었습니다.", "신규입력");
                    }
                    else if (myMode == BaseMode.UPDATE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 수정되었습니다.", "수정");
                    }
                    else if (myMode == BaseMode.DELETE)
                    {
                        MetroMessageBox.Show(this, $"{result}건이 삭제되었습니다.", "삭제");
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


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            InitControls();
        }

        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                DataGridViewRow data = GrdDivTbl.Rows[e.RowIndex];
                TxtDivision.Text = data.Cells[0].Value.ToString();
                TxtNames.Text = data.Cells[1].Value.ToString();
                TxtNames.Focus();
                TxtDivision.ReadOnly = true;

                myMode = BaseMode.UPDATE; // 수정 모드 변경(셀 눌렀을시)
            }
        }
    }
}
