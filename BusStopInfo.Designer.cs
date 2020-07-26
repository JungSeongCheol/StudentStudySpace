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
            this.bstopnm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bstopId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stoptype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.MetroBusTap1 = new MetroFramework.Controls.MetroTabPage();
            this.metroBusTap2 = new MetroFramework.Controls.MetroTabPage();
            this.dgvBustopInfo = new System.Windows.Forms.DataGridView();
            this.bstopIdStop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nodeNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bustype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.min1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.min2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gps = new System.Windows.Forms.DataGridViewButtonColumn();
            this.startpoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endpoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MetroBusTab3 = new MetroFramework.Controls.MetroTabPage();
            this.ShowWebPannel = new System.Windows.Forms.Panel();
            this.WaitingBar = new MetroFramework.Controls.MetroProgressBar();
            this.WaitingTxt = new MetroFramework.Controls.MetroTextBox();
            this.ExitTile = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusStop)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.MetroBusTap1.SuspendLayout();
            this.metroBusTap2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBustopInfo)).BeginInit();
            this.MetroBusTab3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchBus
            // 
            this.SearchBus.Location = new System.Drawing.Point(1422, 90);
            this.SearchBus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SearchBus.Name = "SearchBus";
            this.SearchBus.Size = new System.Drawing.Size(111, 56);
            this.SearchBus.TabIndex = 0;
            this.SearchBus.Text = "검색";
            this.SearchBus.Click += new System.EventHandler(this.SearchBus_Click);
            // 
            // SerachBusStop
            // 
            this.SerachBusStop.Location = new System.Drawing.Point(1157, 90);
            this.SerachBusStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SerachBusStop.Name = "SerachBusStop";
            this.SerachBusStop.Size = new System.Drawing.Size(229, 56);
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
            this.dgvBusStop.GridColor = System.Drawing.SystemColors.Control;
            this.dgvBusStop.Location = new System.Drawing.Point(0, 4);
            this.dgvBusStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvBusStop.Name = "dgvBusStop";
            this.dgvBusStop.RowHeadersWidth = 51;
            this.dgvBusStop.RowTemplate.Height = 23;
            this.dgvBusStop.Size = new System.Drawing.Size(1486, 516);
            this.dgvBusStop.TabIndex = 2;
            this.dgvBusStop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusStop_CellClick);
            this.dgvBusStop.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusStop_CellContentClick);
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
            this.bstopId.HeaderText = "버스정류장종류";
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
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.MetroBusTap1);
            this.metroTabControl1.Controls.Add(this.metroBusTap2);
            this.metroTabControl1.Controls.Add(this.MetroBusTab3);
            this.metroTabControl1.Location = new System.Drawing.Point(31, 174);
            this.metroTabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(1500, 570);
            this.metroTabControl1.TabIndex = 3;
            // 
            // MetroBusTap1
            // 
            this.MetroBusTap1.BackColor = System.Drawing.SystemColors.Control;
            this.MetroBusTap1.Controls.Add(this.dgvBusStop);
            this.MetroBusTap1.HorizontalScrollbarBarColor = true;
            this.MetroBusTap1.HorizontalScrollbarSize = 12;
            this.MetroBusTap1.Location = new System.Drawing.Point(4, 40);
            this.MetroBusTap1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MetroBusTap1.Name = "MetroBusTap1";
            this.MetroBusTap1.Size = new System.Drawing.Size(1492, 526);
            this.MetroBusTap1.TabIndex = 0;
            this.MetroBusTap1.Text = "버스정류장검색";
            this.MetroBusTap1.VerticalScrollbarBarColor = true;
            this.MetroBusTap1.VerticalScrollbarSize = 11;
            // 
            // metroBusTap2
            // 
            this.metroBusTap2.BackColor = System.Drawing.Color.White;
            this.metroBusTap2.Controls.Add(this.dgvBustopInfo);
            this.metroBusTap2.HorizontalScrollbarBarColor = true;
            this.metroBusTap2.HorizontalScrollbarSize = 12;
            this.metroBusTap2.Location = new System.Drawing.Point(4, 40);
            this.metroBusTap2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroBusTap2.Name = "metroBusTap2";
            this.metroBusTap2.Size = new System.Drawing.Size(1492, 526);
            this.metroBusTap2.TabIndex = 1;
            this.metroBusTap2.Text = "버스정류장도착버스";
            this.metroBusTap2.VerticalScrollbarBarColor = true;
            this.metroBusTap2.VerticalScrollbarSize = 11;
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
            this.min2,
            this.gps,
            this.startpoint,
            this.endpoint});
            this.dgvBustopInfo.Location = new System.Drawing.Point(0, 4);
            this.dgvBustopInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvBustopInfo.Name = "dgvBustopInfo";
            this.dgvBustopInfo.RowHeadersWidth = 51;
            this.dgvBustopInfo.RowTemplate.Height = 23;
            this.dgvBustopInfo.Size = new System.Drawing.Size(1494, 568);
            this.dgvBustopInfo.TabIndex = 2;
            this.dgvBustopInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBustopInfo_CellClick);
            // 
            // bstopIdStop
            // 
            this.bstopIdStop.HeaderText = "버스정류소ID";
            this.bstopIdStop.MinimumWidth = 100;
            this.bstopIdStop.Name = "bstopIdStop";
            this.bstopIdStop.Width = 140;
            // 
            // nodeNm
            // 
            this.nodeNm.HeaderText = "버스정류장이름";
            this.nodeNm.MinimumWidth = 6;
            this.nodeNm.Name = "nodeNm";
            this.nodeNm.Width = 150;
            // 
            // lineNo
            // 
            this.lineNo.HeaderText = "버스번호";
            this.lineNo.MinimumWidth = 6;
            this.lineNo.Name = "lineNo";
            this.lineNo.Width = 125;
            // 
            // bustype
            // 
            this.bustype.HeaderText = "버스종류";
            this.bustype.MinimumWidth = 6;
            this.bustype.Name = "bustype";
            this.bustype.Width = 125;
            // 
            // min1
            // 
            this.min1.HeaderText = "첫버스도착시간";
            this.min1.MinimumWidth = 6;
            this.min1.Name = "min1";
            this.min1.Width = 140;
            // 
            // min2
            // 
            this.min2.HeaderText = "2번째시간";
            this.min2.MinimumWidth = 6;
            this.min2.Name = "min2";
            this.min2.Width = 125;
            // 
            // gps
            // 
            this.gps.HeaderText = "버스정류장위치";
            this.gps.MinimumWidth = 6;
            this.gps.Name = "gps";
            this.gps.Width = 125;
            // 
            // startpoint
            // 
            this.startpoint.HeaderText = "출발지";
            this.startpoint.MinimumWidth = 6;
            this.startpoint.Name = "startpoint";
            this.startpoint.ReadOnly = true;
            this.startpoint.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.startpoint.Width = 150;
            // 
            // endpoint
            // 
            this.endpoint.HeaderText = "도착지";
            this.endpoint.MinimumWidth = 100;
            this.endpoint.Name = "endpoint";
            this.endpoint.ReadOnly = true;
            this.endpoint.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.endpoint.Width = 150;
            // 
            // MetroBusTab3
            // 
            this.MetroBusTab3.Controls.Add(this.ShowWebPannel);
            this.MetroBusTab3.HorizontalScrollbarBarColor = true;
            this.MetroBusTab3.HorizontalScrollbarSize = 12;
            this.MetroBusTab3.Location = new System.Drawing.Point(4, 40);
            this.MetroBusTab3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MetroBusTab3.Name = "MetroBusTab3";
            this.MetroBusTab3.Size = new System.Drawing.Size(1492, 526);
            this.MetroBusTab3.TabIndex = 2;
            this.MetroBusTab3.Text = "버스정류장위치";
            this.MetroBusTab3.VerticalScrollbarBarColor = true;
            this.MetroBusTab3.VerticalScrollbarSize = 11;
            // 
            // ShowWebPannel
            // 
            this.ShowWebPannel.Location = new System.Drawing.Point(3, 2);
            this.ShowWebPannel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShowWebPannel.Name = "ShowWebPannel";
            this.ShowWebPannel.Size = new System.Drawing.Size(1490, 564);
            this.ShowWebPannel.TabIndex = 2;
            // 
            // WaitingBar
            // 
            this.WaitingBar.Location = new System.Drawing.Point(353, 86);
            this.WaitingBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WaitingBar.Name = "WaitingBar";
            this.WaitingBar.Size = new System.Drawing.Size(603, 58);
            this.WaitingBar.TabIndex = 5;
            // 
            // WaitingTxt
            // 
            this.WaitingTxt.BackColor = System.Drawing.SystemColors.Window;
            this.WaitingTxt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.WaitingTxt.Location = new System.Drawing.Point(617, 101);
            this.WaitingTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WaitingTxt.Name = "WaitingTxt";
            this.WaitingTxt.Size = new System.Drawing.Size(104, 25);
            this.WaitingTxt.TabIndex = 6;
            // 
            // ExitTile
            // 
            this.ExitTile.Location = new System.Drawing.Point(1422, 752);
            this.ExitTile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ExitTile.Name = "ExitTile";
            this.ExitTile.Size = new System.Drawing.Size(99, 87);
            this.ExitTile.TabIndex = 7;
            this.ExitTile.TileImage = global::BusInformation.Properties.Resources.iconfinder_exit_to_app_326635;
            this.ExitTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ExitTile.UseTileImage = true;
            this.ExitTile.Click += new System.EventHandler(this.ExitTile_Click);
            // 
            // BusStopInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 849);
            this.Controls.Add(this.WaitingTxt);
            this.Controls.Add(this.WaitingBar);
            this.Controls.Add(this.ExitTile);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.SerachBusStop);
            this.Controls.Add(this.SearchBus);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BusStopInfo";
            this.Padding = new System.Windows.Forms.Padding(23, 75, 23, 25);
            this.Text = "버스정류장정보";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusStop)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.MetroBusTap1.ResumeLayout(false);
            this.metroBusTap2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBustopInfo)).EndInit();
            this.MetroBusTab3.ResumeLayout(false);
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
        private MetroFramework.Controls.MetroTabPage MetroBusTab3;
        private System.Windows.Forms.DataGridViewTextBoxColumn bstopIdStop;
        private System.Windows.Forms.DataGridViewTextBoxColumn nodeNm;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn bustype;
        private System.Windows.Forms.DataGridViewTextBoxColumn min1;
        private System.Windows.Forms.DataGridViewTextBoxColumn min2;
        private System.Windows.Forms.DataGridViewButtonColumn gps;
        private System.Windows.Forms.DataGridViewTextBoxColumn startpoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn endpoint;
        private System.Windows.Forms.Panel ShowWebPannel;
        private MetroFramework.Controls.MetroProgressBar WaitingBar;
        private MetroFramework.Controls.MetroTextBox WaitingTxt;
        private MetroFramework.Controls.MetroTile ExitTile;
    }
}