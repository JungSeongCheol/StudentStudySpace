namespace BusInformation.BusStop
{
    partial class BusStopInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchBus = new MetroFramework.Controls.MetroButton();
            this.SerachBusStop = new MetroFramework.Controls.MetroTextBox();
            this.dgvBusStop = new System.Windows.Forms.DataGridView();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.MetroBusTap1 = new MetroFramework.Controls.MetroTabPage();
            this.metroBusTap2 = new MetroFramework.Controls.MetroTabPage();
            this.dgvBustopInfo = new System.Windows.Forms.DataGridView();
            this.bstopnm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bstopId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stoptype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bstopIdStop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nodeNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bustype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.min1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.min2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusStop)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.MetroBusTap1.SuspendLayout();
            this.metroBusTap2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBustopInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchBus
            // 
            this.SearchBus.Location = new System.Drawing.Point(709, 63);
            this.SearchBus.Name = "SearchBus";
            this.SearchBus.Size = new System.Drawing.Size(97, 45);
            this.SearchBus.TabIndex = 0;
            this.SearchBus.Text = "검색";
            this.SearchBus.Click += new System.EventHandler(this.SearchBus_Click);
            // 
            // SerachBusStop
            // 
            this.SerachBusStop.Location = new System.Drawing.Point(492, 63);
            this.SerachBusStop.Name = "SerachBusStop";
            this.SerachBusStop.Size = new System.Drawing.Size(200, 45);
            this.SerachBusStop.TabIndex = 1;
            this.SerachBusStop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SerachBusStop_KeyPress);
            // 
            // dgvBusStop
            // 
            this.dgvBusStop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusStop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bstopnm,
            this.bstopId,
            this.stoptype});
            this.dgvBusStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBusStop.GridColor = System.Drawing.SystemColors.Control;
            this.dgvBusStop.Location = new System.Drawing.Point(0, 0);
            this.dgvBusStop.Name = "dgvBusStop";
            this.dgvBusStop.RowHeadersWidth = 51;
            this.dgvBusStop.RowTemplate.Height = 23;
            this.dgvBusStop.Size = new System.Drawing.Size(771, 281);
            this.dgvBusStop.TabIndex = 2;
            this.dgvBusStop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusStop_CellClick);
            this.dgvBusStop.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusStop_CellContentClick);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.MetroBusTap1);
            this.metroTabControl1.Controls.Add(this.metroBusTap2);
            this.metroTabControl1.Location = new System.Drawing.Point(27, 123);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(779, 321);
            this.metroTabControl1.TabIndex = 3;
            // 
            // MetroBusTap1
            // 
            this.MetroBusTap1.BackColor = System.Drawing.SystemColors.Control;
            this.MetroBusTap1.Controls.Add(this.dgvBusStop);
            this.MetroBusTap1.HorizontalScrollbarBarColor = true;
            this.MetroBusTap1.Location = new System.Drawing.Point(4, 36);
            this.MetroBusTap1.Name = "MetroBusTap1";
            this.MetroBusTap1.Size = new System.Drawing.Size(771, 281);
            this.MetroBusTap1.TabIndex = 0;
            this.MetroBusTap1.Text = "버스정류장검색";
            this.MetroBusTap1.VerticalScrollbarBarColor = true;
            // 
            // metroBusTap2
            // 
            this.metroBusTap2.BackColor = System.Drawing.Color.White;
            this.metroBusTap2.Controls.Add(this.dgvBustopInfo);
            this.metroBusTap2.HorizontalScrollbarBarColor = true;
            this.metroBusTap2.Location = new System.Drawing.Point(4, 36);
            this.metroBusTap2.Name = "metroBusTap2";
            this.metroBusTap2.Size = new System.Drawing.Size(771, 281);
            this.metroBusTap2.TabIndex = 1;
            this.metroBusTap2.Text = "버스정류장도착버스";
            this.metroBusTap2.VerticalScrollbarBarColor = true;
            // 
            // dgvBustopInfo
            // 
            this.dgvBustopInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBustopInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bstopIdStop,
            this.nodeNm,
            this.lineNo,
            this.bustype,
            this.min1,
            this.min2});
            this.dgvBustopInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBustopInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvBustopInfo.Name = "dgvBustopInfo";
            this.dgvBustopInfo.RowTemplate.Height = 23;
            this.dgvBustopInfo.Size = new System.Drawing.Size(771, 281);
            this.dgvBustopInfo.TabIndex = 2;
            // 
            // bstopnm
            // 
            this.bstopnm.HeaderText = "버스정류장이름";
            this.bstopnm.MinimumWidth = 6;
            this.bstopnm.Name = "bstopnm";
            this.bstopnm.Width = 150;
            // 
            // bstopId
            // 
            this.bstopId.HeaderText = "버스정류장ID";
            this.bstopId.MinimumWidth = 6;
            this.bstopId.Name = "bstopId";
            this.bstopId.Width = 150;
            // 
            // stoptype
            // 
            this.stoptype.HeaderText = "정류소구분(클릭시 상세정보확인)";
            this.stoptype.MinimumWidth = 6;
            this.stoptype.Name = "stoptype";
            this.stoptype.Width = 239;
            // 
            // bstopIdStop
            // 
            this.bstopIdStop.HeaderText = "버스정류소ID";
            this.bstopIdStop.Name = "bstopIdStop";
            this.bstopIdStop.Width = 120;
            // 
            // nodeNm
            // 
            this.nodeNm.HeaderText = "버스정류장이름";
            this.nodeNm.Name = "nodeNm";
            this.nodeNm.Width = 120;
            // 
            // lineNo
            // 
            this.lineNo.HeaderText = "버스번호";
            this.lineNo.Name = "lineNo";
            // 
            // bustype
            // 
            this.bustype.HeaderText = "버스종류";
            this.bustype.Name = "bustype";
            // 
            // min1
            // 
            this.min1.HeaderText = "첫버스도착시간";
            this.min1.Name = "min1";
            this.min1.Width = 120;
            // 
            // min2
            // 
            this.min2.HeaderText = "2번째시간";
            this.min2.Name = "min2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 496);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.SerachBusStop);
            this.Controls.Add(this.SearchBus);
            this.Name = "Form1";
            this.Text = "버스정류장정보";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusStop)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.MetroBusTap1.ResumeLayout(false);
            this.metroBusTap2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBustopInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton SearchBus;
        private MetroFramework.Controls.MetroTextBox SerachBusStop;
        private System.Windows.Forms.DataGridView dgvBusStop;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage MetroBusTap1;
        private MetroFramework.Controls.MetroTabPage metroBusTap2;
        private System.Windows.Forms.DataGridView dgvBustopInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn bstopnm;
        private System.Windows.Forms.DataGridViewTextBoxColumn bstopId;
        private System.Windows.Forms.DataGridViewTextBoxColumn stoptype;
        private System.Windows.Forms.DataGridViewTextBoxColumn bstopIdStop;
        private System.Windows.Forms.DataGridViewTextBoxColumn nodeNm;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn bustype;
        private System.Windows.Forms.DataGridViewTextBoxColumn min1;
        private System.Windows.Forms.DataGridViewTextBoxColumn min2;
    }
}