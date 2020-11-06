using BookRentalShopApp2020.NewFolder1;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace BookRentalShopApp2020.SubItems
{
    public partial class RentalMngForm : MetroForm
    {
        //DataGridViewRow data = GrdBooksTbl.Rows[e.RowIndex];
        #region 멤버변수 영역
        private string strTblName = "RentalTbl";

        BaseMode myMode = BaseMode.NONE;    // 초기 상태(아무것도 하지 않음)
        #endregion;

        #region 생성자 영역
        public RentalMngForm()
        {
            InitializeComponent();
            TxtIdx.Select();
        }
        #endregion

        #region 이벤트 핸들러 영역
        private void DevMngForm_Load(object sender, EventArgs e)
        {
            UpdateComboMember();
            UpdateData();
            UpdateComboBook();
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
            TxtIdx.Text = string.Empty;
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

        private void GrdRentalTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdRentalTbl.Rows[e.RowIndex];

                // TODO : 클릭시 입력컨트롤에 데이터 할당
                TxtIdx.Text = data.Cells[0].Value.ToString();
                CboMember.SelectedValue = data.Cells[6].Value.ToString();   //ToStirng해줘야
                CboBook.SelectedValue = data.Cells[7].Value.ToString();    //ToStirng해줘야 함
                DtpRentalData.Value = DateTime.Parse(data.Cells[4].Value.ToString());

                if(!string.IsNullOrEmpty(data.Cells[5].Value.ToString()))
                {
                    DtpReturnDate.CustomFormat = "yyyy-MM-dd"; // " "에서 변경하기 위해서
                    DtpReturnDate.Format = DateTimePickerFormat.Custom;
                    DtpReturnDate.Value = DateTime.Parse(data.Cells[5].Value.ToString());
                }

                else
                {
                    DtpReturnDate.CustomFormat = " "; // " "에서 변경하기 위해서
                    DtpReturnDate.Format = DateTimePickerFormat.Custom;
                }

                TxtIdx.ReadOnly = true;
                //TxtNames.Focus();

                myMode = BaseMode.UPDATE; // 수정 모드 변경(셀 눌렀을시)
            }
        }

        private void DtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            DtpReturnDate.CustomFormat = "yyyy-MM-dd";
            DtpReturnDate.Format = DateTimePickerFormat.Custom;
            DtpReturnDate.Value = DateTime.Now;
        }

        #endregion

        #region 커스텀 메서드 영역
        private void UpdateComboMember()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.COMNSTR))
            {
                string strQuery = $" SELECT Idx, Names FROM membertbl ";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", "");

                while (reader.Read())
                {
                    temps.Add(reader[1].ToString(), reader[0].ToString());
                }
                CboMember.DataSource = new BindingSource(temps, null);
                CboMember.DisplayMember = "Key";
                CboMember.ValueMember = "Value";
                //CboDivision.SelectedIndex = -1;
            }
        }

        private void UpdateComboBook()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.COMNSTR))
            {
                string strQuery = $" SELECT Idx,          " +
                                   "        Names,        " +
                                   "(SELECT Names         " +
                                   "   FROM divtbl        "  +
                                   "  WHERE Division =    " +
                                   "        b.Division)   "  +
                                   "     AS Division      "  +
                                   "   FROM bookstbl as b ";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", "");

                while (reader.Read())
                {
                    temps.Add($"[{reader[2]}] {reader[1]}", $"{reader[0]}");
                }
                CboBook.DataSource = new BindingSource(temps, null);
                CboBook.DisplayMember = "Key";
                CboBook.ValueMember = "Value";
                //CboDivision.SelectedIndex = -1;
            }
        }

        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.COMNSTR))
            {
                string strQuery = $"      SELECT    r.idx AS '번호', " +
                                   "                m.Names AS '대여회원', " +
                                   "                b.Names AS '대여책제목', " +
                                   "                b.ISBN, " +
                                   "                r.rentalDate AS '대여일' , " +
                                   "                r.returnDate AS '반납일' , " +
                                   "                r.memberIdx, " +
                                   "                r.bookIdx " +
                                   "        FROM    rentaltbl AS r " +
                                   "  INNER JOIN    membertbl AS m " +
                                   "          ON    r.memberIdx = m.Idx " +
                                   "  INNER JOIN    bookstbl AS b " +
                                   "          ON    r.bookIdx = b.Idx; ";

                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);    //소켓처럼 생성(데이터를 넣을수 있는 어뎁터를 생성)
                DataSet ds = new DataSet();
                adapter.Fill(ds, strTblName);

                GrdRentalTbl.DataSource = ds;
                GrdRentalTbl.DataMember = strTblName;
            }

            SetColumHeaders();
        }

        private void SetColumHeaders()
        {
            DataGridViewColumn column;

            column = GrdRentalTbl.Columns[0];
            column.Width = 100;
            column.HeaderText = "번호";

            column = GrdRentalTbl.Columns[1];
            column.Width = 120;
            column.HeaderText = "이름";

            column = GrdRentalTbl.Columns[2];
            column.Width = 120;
            column.HeaderText = "책";

            column = GrdRentalTbl.Columns[3]; 
            column.Width = 150;
            column.HeaderText = "ISBN";

            column = GrdRentalTbl.Columns[4];
            column.Width = 120;

            column = GrdRentalTbl.Columns[5];  
            column.Width = 150;

            column = GrdRentalTbl.Columns[6];    
            column.Visible = false;            //memberIdx

            column = GrdRentalTbl.Columns[7];    // 출간일
            column.Visible = false;
            //column.Visible = false;
        }

        private void InitControls()
        {
            TxtIdx.Text = String.Empty;
            TxtIdx.ReadOnly = true;

            CboBook.SelectedIndex = CboMember.SelectedIndex = 0;

            DtpRentalData.CustomFormat = "yyyy-MM-dd";
            DtpRentalData.Format = DateTimePickerFormat.Custom;
            DtpRentalData.Value = DateTime.Now;

            DtpReturnDate.CustomFormat = " ";
            DtpReturnDate.Format = DateTimePickerFormat.Custom;

            //TxtNames.Focus();

            myMode = BaseMode.NONE;
        }


        /// <summary>
        /// DB 업데이트 및 입력 처리
        /// </summary>
        private void SaveData()
        {
            //if (string.IsNullOrEmpty(/*TxtNames*/.Text) ||
            //    CboBook.SelectedIndex == 0 ||
            //    string.IsNullOrEmpty(/*TxtAddr*/.Text) ||
            //    string.IsNullOrEmpty(/*TxtMobile*/.Text) ||
            //    string.IsNullOrEmpty(/*TxtEmail*/.Text))
            //{
            //    MetroMessageBox.Show(this, "빈값을 넣을 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

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
                        cmd.CommandText = "UPDATE rentaltbl " +
                                          "   SET Idx = @Idx " +
                                          "     , memberIdx = @memberIdx " +
                                          "     , bookIdx = @bookIdx " +
                                          "     , rentalDate = @rentalDate " +
                                          "     , returnDate = @returnDate " +
                                          " WHERE Idx = @Idx ";

                    }

                    else if (myMode == BaseMode.INSERT)
                    {
                        cmd.CommandText = "INSERT INTO rentaltbl " +
                                          "( " +
                                          "            memberIdx " +
                                          "         ,  bookIdx " +
                                          "         ,  rentalDate " +
                                          //"         ,  returnDate " +
                                          ") " +
                                          "VALUES " +
                                          "( " +
                                          "            @memberIdx " +
                                          "         ,  @bookIdx " +
                                          "         ,  @rentalDate " +
                                          //"         ,  @returnDate " +
                                          ") ";

                    }

                    MySqlParameter paramMemberIdx = new MySqlParameter("@memberIdx", MySqlDbType.Int32);
                    paramMemberIdx.Value = CboMember.SelectedValue;
                    cmd.Parameters.Add(paramMemberIdx);

                    MySqlParameter paramBookIdx = new MySqlParameter("@bookIdx", MySqlDbType.Int32);
                    paramBookIdx.Value = CboBook.SelectedValue;
                    cmd.Parameters.Add(paramBookIdx);

                    MySqlParameter paramRentalDate = new MySqlParameter("@rentalDate", MySqlDbType.Date);
                    paramRentalDate.Value = DtpRentalData.Value;
                    cmd.Parameters.Add(paramRentalDate);

                    if(myMode == BaseMode.UPDATE)
                    {
                        MySqlParameter paramReturnDate = new MySqlParameter("@returnDate", MySqlDbType.Date);
                        paramReturnDate.Value = DtpReturnDate.Value;
                        cmd.Parameters.Add(paramReturnDate);    //returnData
                    }

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

        private void BtnExcelExport_Click_Click(object sender, EventArgs e)
        {
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet1 = workbook.CreateSheet("sheet1");
            sheet1.CreateRow(0).CreateCell(0).SetCellValue("Rental Book Data");

            DataSet ds = GrdRentalTbl.DataSource as DataSet;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                IRow row = sheet1.CreateRow(i);
                for (int j = 0; j < ds.Tables[0].Rows[0].ItemArray.Length; j++)
                {
                    if( j == 4 || j == 5)
                    {
                        var value = string.IsNullOrEmpty(ds.Tables[0].Rows[i].ItemArray[j].ToString()) ?
                            "" : ds.Tables[0].Rows[i].ItemArray[j].ToString().Substring(0, 10);
                        row.CreateCell(j).SetCellValue(value);
                    }
                    else if (j > 5)
                    {
                        break;
                    }
                    else
                    {
                        row.CreateCell(j).SetCellValue(ds.Tables[0].Rows[i].ItemArray[j].ToString());
                    }
                    
                }
            }
            FileStream file = File.Create(Environment.CurrentDirectory + $@"\export.xls");
            workbook.Write(file);
            file.Close();

            MessageBox.Show("Export done!!");
        }
    }
}
