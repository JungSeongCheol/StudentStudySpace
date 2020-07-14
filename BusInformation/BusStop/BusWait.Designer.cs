namespace BusInformation.BusStop
{
    partial class BusWait
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
            this.SearchBusStop = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.DgvBus = new System.Windows.Forms.DataGridView();
            this.lineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBus)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchBusStop
            // 
            this.SearchBusStop.Location = new System.Drawing.Point(478, 63);
            this.SearchBusStop.Name = "SearchBusStop";
            this.SearchBusStop.Size = new System.Drawing.Size(117, 37);
            this.SearchBusStop.TabIndex = 0;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(625, 63);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(104, 37);
            this.metroButton1.TabIndex = 1;
            this.metroButton1.Text = "검색";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // DgvBus
            // 
            this.DgvBus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvBus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lineNo});
            this.DgvBus.Location = new System.Drawing.Point(34, 108);
            this.DgvBus.Name = "DgvBus";
            this.DgvBus.RowTemplate.Height = 23;
            this.DgvBus.Size = new System.Drawing.Size(695, 298);
            this.DgvBus.TabIndex = 2;
            // 
            // lineNo
            // 
            this.lineNo.HeaderText = "버스번호";
            this.lineNo.Name = "lineNo";
            // 
            // BusWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DgvBus);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.SearchBusStop);
            this.Name = "BusWait";
            this.Text = "BusWait";
            ((System.ComponentModel.ISupportInitialize)(this.DgvBus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox SearchBusStop;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.DataGridView DgvBus;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineNo;
    }
}