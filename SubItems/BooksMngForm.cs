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
    public partial class BooksMngForm : MetroForm
    {
        #region 멤버변수 영역
        private string strTblName = "bookstbl";

        BaseMode myMode = BaseMode.NONE;    // 초기 상태(아무것도 하지 않음)
        #endregion

        #region 생성자 영역
        public BooksMngForm()
        {
            InitializeComponent();
            TxtIdx.Select();
        }
        #endregion

        #region 이벤트 핸들러 영역
        private void DevMngForm_Load(object sender, EventArgs e)
        {
            UpdateComboset();
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
            TxtIdx.Text = TxtAuthor.Text = string.Empty;
            TxtIdx.ReadOnly = true;
            myMode = BaseMode.INSERT;   //신규 입력 모드
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            InitControls();
        }

        /// <summary>
        /// DB 업데이트 및 입력 처리
        /// </summary>



        private void BtnCancel_Click(object sender, EventArgs e)
        {
            InitControls();
        }

        private void GrdDivTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = GrdBooksTbl.Rows[e.RowIndex];
                // TODO : 클릭시 입력컨트롤에 데이터 할당
                TxtIdx.Text = data.Cells[0].Value.ToString();
                TxtAuthor.Text = data.Cells[1].Value.ToString();

                // 로맨스, 추리등 디스플레이 되는 글자로 인덱스 찾기
                // CboDivision.SelectedIndex = CboDivision.FindString(data.Cells[3].Value.ToString());
                // 코드값을 그대로 할당하는 방법 B001, B002
                CboDivision.SelectedValue = data.Cells[2].Value.ToString();

                TxtNames.Text = data.Cells[4].Value.ToString();
                // TODO : 출간일 날짜픽커 Cells[5]
                DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
                DtpReleaseDate.Format = DateTimePickerFormat.Custom;
                DtpReleaseDate.Value = DateTime.Parse(data.Cells[5].Value.ToString());

                TxtIsbn.Text = data.Cells[6].Value.ToString();
                TxtPrice.Text = data.Cells[7].Value.ToString();

                TxtIdx.ReadOnly = true;
                TxtAuthor.Focus();

                myMode = BaseMode.UPDATE; // 수정 모드 변경(셀 눌렀을시)
            }
        }

        #endregion

        #region 커스텀 메서드 영역
        private void UpdateComboset()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.COMNSTR))
            {
                string strQuery = $" SELECT division, Names FROM divTbl ";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", "");

                while (reader.Read())
                {
                    temps.Add(reader[1].ToString(), reader[0].ToString());
                }
                CboDivision.DataSource = new BindingSource(temps, null);
                CboDivision.DisplayMember = "Key";
                CboDivision.ValueMember = "Value";
                //CboDivision.SelectedIndex = -1;
            }
        }


        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.COMNSTR))
            {
                string strQuery = $"SELECT b.Idx, " +
                                   "       b.Author, " +
                                   "       b.Division, " +
                                   "       d.Names As DivisionName, " +
                                   "       b.Names, " +
                                   "       b.ReleaseDate, " +
                                   "       b.ISBN, " +
                                   "       b.Price " +
                                   "  FROM bookstbl as b " +
                                   " INNER JOIN divtbl as d " +
                                   "    ON b.Division = d.Division ";
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
            column.HeaderText = "저자명";

            column = GrdBooksTbl.Columns[2];
            column.Visible = false;

            column = GrdBooksTbl.Columns[3];    // 구분코드명
            column.Width = 150;
            column.HeaderText = "장르";

            column = GrdBooksTbl.Columns[4];
            column.Width = 200;
            column.HeaderText = "이름";

            column = GrdBooksTbl.Columns[5];    // 출간일
            column.Width = 150;
            column.HeaderText = "출간일";

            column = GrdBooksTbl.Columns[6];    //ISBN
            column.Width = 150;
            column.HeaderText = "ISBN";

            column = GrdBooksTbl.Columns[7];    //가격
            column.Width = 100;
            column.HeaderText = "가격";
        }

        private void InitControls()
        {
            TxtIdx.Text = TxtAuthor.Text = string.Empty;
            TxtIsbn.Text = TxtNames.Text = TxtPrice.Text = string.Empty;
            TxtIdx.ReadOnly = true;
            //CboDivision.SelectedIndex = 0;

            TxtIdx.Focus();

            DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
            DtpReleaseDate.Format = DateTimePickerFormat.Custom;
            DtpReleaseDate.Value = DateTime.Now;

            myMode = BaseMode.NONE;

            #region Dictonary 콤보박스 사용법
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("선택", "00");
            //dic.Add("서울특별시", "11");
            //dic.Add("부산광역시", "21");
            //dic.Add("대구광역시", "22");
            //dic.Add("인천광역시", "23");
            //dic.Add("광주광역시", "24");
            //dic.Add("대전광역시", "25");

            //CboDivision.DataSource = new BindingSource(dic, null);
            //CboDivision.DisplayMember = "Key";
            //CboDivision.ValueMember = "Value";
            #endregion
        }

        private void SaveData()
        {
            if (string.IsNullOrEmpty(TxtAuthor.Text) ||
                CboDivision.SelectedIndex < 1 ||
                string.IsNullOrEmpty(TxtNames.Text) ||
                string.IsNullOrEmpty(TxtIsbn.Text))
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
                        cmd.CommandText = "UPDATE bookstbl " +
                                          "   SET Author      = @Author, " +
                                          "       Division    = @Division, " +
                                          "       Names       = @Names, " +
                                          "       ReleaseDate = @ReleaseDate, " +
                                          "       ISBN        = @ISBN, " +
                                          "       Price       = @Price " +
                                          " WHERE Idx = @Idx ";
                    }

                    else if (myMode == BaseMode.INSERT)
                    {
                        cmd.CommandText = "INSERT   INTO bookstbl" +
                                          " ( " +
                                          "         Author, " +
                                          "         Division, " +
                                          "         Names, " +
                                          "         ReleaseDate, " +
                                          "         ISBN, " +
                                          "         Price) " +
                                          "         VALUES " +
                                          "         ( " +
                                          "     @Author, " +
                                          " @Division, " +
                                          " @Names, " +
                                          " @ReleaseDate, " +
                                          " @ISBN, " +
                                          " @Price) ";
                    }

                    // 저자명
                    MySqlParameter paramAuthor = new MySqlParameter("@Author", MySqlDbType.VarChar, 45)
                    {
                        Value = TxtAuthor.Text
                    };
                    cmd.Parameters.Add(paramAuthor);

                    // 장르
                    MySqlParameter paramDivision = new MySqlParameter("@Division", MySqlDbType.VarChar, 4)
                    {
                        Value = CboDivision.SelectedValue
                    };
                    cmd.Parameters.Add(paramDivision);

                    // 책이름
                    MySqlParameter paramNames = new MySqlParameter("@Names", MySqlDbType.VarChar, 100)
                    {
                        Value = TxtNames.Text
                    };
                    cmd.Parameters.Add(paramNames);

                    // 출간일
                    MySqlParameter paramReleaseDate = new MySqlParameter("@ReleaseDate", MySqlDbType.DateTime, 45)
                    {
                        Value = DtpReleaseDate.Value
                    };
                    cmd.Parameters.Add(paramReleaseDate);

                    //ISBN
                    MySqlParameter paramISBN = new MySqlParameter("@ISBN", MySqlDbType.VarChar, 13)
                    {
                        Value = TxtIsbn.Text
                    };
                    cmd.Parameters.Add(paramISBN);

                    //Price
                    MySqlParameter paramPrice = new MySqlParameter("@Price", MySqlDbType.Decimal)
                    {
                        Value = TxtPrice.Text
                    };
                    cmd.Parameters.Add(paramPrice);

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
