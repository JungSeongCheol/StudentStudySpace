namespace BusInformation.BusStop
{
    partial class Form1
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusStop)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchBus
            // 
            this.SearchBus.Location = new System.Drawing.Point(661, 63);
            this.SearchBus.Name = "SearchBus";
            this.SearchBus.Size = new System.Drawing.Size(97, 45);
            this.SearchBus.TabIndex = 0;
            this.SearchBus.Text = "검색";
            this.SearchBus.Click += new System.EventHandler(this.SearchBus_Click);
            // 
            // SerachBusStop
            // 
            this.SerachBusStop.Location = new System.Drawing.Point(455, 63);
            this.SerachBusStop.Name = "SerachBusStop";
            this.SerachBusStop.Size = new System.Drawing.Size(200, 45);
            this.SerachBusStop.TabIndex = 1;
            this.SerachBusStop.Text = "metroTextBox1";
            // 
            // dgvBusStop
            // 
            this.dgvBusStop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusStop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bstopnm});
            this.dgvBusStop.Location = new System.Drawing.Point(33, 114);
            this.dgvBusStop.Name = "dgvBusStop";
            this.dgvBusStop.RowTemplate.Height = 23;
            this.dgvBusStop.Size = new System.Drawing.Size(725, 304);
            this.dgvBusStop.TabIndex = 2;
            this.dgvBusStop.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusStop_CellContentClick);
            // 
            // bstopnm
            // 
            this.bstopnm.HeaderText = "버스위치";
            this.bstopnm.Name = "bstopnm";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvBusStop);
            this.Controls.Add(this.SerachBusStop);
            this.Controls.Add(this.SearchBus);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusStop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton SearchBus;
        private MetroFramework.Controls.MetroTextBox SerachBusStop;
        private System.Windows.Forms.DataGridView dgvBusStop;
        private System.Windows.Forms.DataGridViewTextBoxColumn bstopnm;
    }
}