namespace MyStockSystem.SubItems
{
    partial class SearchItemForm
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TextSerachItem = new MetroFramework.Controls.MetroTextBox();
            this.SearchItemButton = new MetroFramework.Controls.MetroButton();
            this.DgvSearchItem = new System.Windows.Forms.DataGridView();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.ISIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISSUDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KORSECNM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SECNKACDNM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHOTNISIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSearchItem)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Location = new System.Drawing.Point(23, 63);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1234, 629);
            this.metroTabControl1.TabIndex = 0;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.metroTabPage1.Controls.Add(this.splitContainer1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 40);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1226, 585);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "주식기초정보수집";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.TextSerachItem);
            this.splitContainer1.Panel1.Controls.Add(this.SearchItemButton);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            this.splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.DgvSearchItem);
            this.splitContainer1.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel2MinSize = 10;
            this.splitContainer1.Size = new System.Drawing.Size(1226, 585);
            this.splitContainer1.SplitterDistance = 54;
            this.splitContainer1.TabIndex = 2;
            // 
            // TextSerachItem
            // 
            this.TextSerachItem.Location = new System.Drawing.Point(919, 3);
            this.TextSerachItem.Name = "TextSerachItem";
            this.TextSerachItem.Size = new System.Drawing.Size(196, 44);
            this.TextSerachItem.TabIndex = 1;
            this.TextSerachItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextSerachItem_KeyPress);
            // 
            // SearchItemButton
            // 
            this.SearchItemButton.Location = new System.Drawing.Point(1121, 3);
            this.SearchItemButton.Name = "SearchItemButton";
            this.SearchItemButton.Size = new System.Drawing.Size(101, 44);
            this.SearchItemButton.TabIndex = 0;
            this.SearchItemButton.Text = "검색";
            this.SearchItemButton.Click += new System.EventHandler(this.SearchItemButton_Click);
            // 
            // DgvSearchItem
            // 
            this.DgvSearchItem.AllowUserToAddRows = false;
            this.DgvSearchItem.AllowUserToDeleteRows = false;
            this.DgvSearchItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ISIN,
            this.ISSUDT,
            this.KORSECNM,
            this.SECNKACDNM,
            this.SHOTNISIN});
            this.DgvSearchItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvSearchItem.Location = new System.Drawing.Point(0, 0);
            this.DgvSearchItem.Name = "DgvSearchItem";
            this.DgvSearchItem.RowTemplate.Height = 23;
            this.DgvSearchItem.Size = new System.Drawing.Size(1224, 525);
            this.DgvSearchItem.TabIndex = 0;
            this.DgvSearchItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSearchItem_CellContentClick);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 40);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(1066, 402);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "해당정보수집";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            // 
            // metroTile1
            // 
            this.metroTile1.Location = new System.Drawing.Point(1198, 698);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(59, 39);
            this.metroTile1.TabIndex = 1;
            this.metroTile1.TileImage = global::MyStockSystem.Properties.Resources.back2;
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // ISIN
            // 
            this.ISIN.HeaderText = "표준코드";
            this.ISIN.Name = "ISIN";
            this.ISIN.Width = 150;
            // 
            // ISSUDT
            // 
            this.ISSUDT.HeaderText = "주식 발행일자";
            this.ISSUDT.Name = "ISSUDT";
            this.ISSUDT.Width = 200;
            // 
            // KORSECNM
            // 
            this.KORSECNM.HeaderText = "한글 종목명";
            this.KORSECNM.Name = "KORSECNM";
            this.KORSECNM.Width = 250;
            // 
            // SECNKACDNM
            // 
            this.SECNKACDNM.HeaderText = "보통주/우선주";
            this.SECNKACDNM.Name = "SECNKACDNM";
            this.SECNKACDNM.Width = 200;
            // 
            // SHOTNISIN
            // 
            this.SHOTNISIN.HeaderText = "단축코드";
            this.SHOTNISIN.Name = "SHOTNISIN";
            this.SHOTNISIN.Width = 150;
            // 
            // SearchItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.metroTabControl1);
            this.MaximizeBox = false;
            this.Name = "SearchItemForm";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "주식정보검색";
            this.Load += new System.EventHandler(this.SearchItemForm_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSearchItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MetroFramework.Controls.MetroTextBox TextSerachItem;
        private MetroFramework.Controls.MetroButton SearchItemButton;
        private System.Windows.Forms.DataGridView DgvSearchItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISSUDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn KORSECNM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SECNKACDNM;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHOTNISIN;
    }
}