namespace WinFormGomku
{
    partial class SinglePlay
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
            this.CheckerBoard = new System.Windows.Forms.PictureBox();
            this.PlayButton = new MetroFramework.Controls.MetroButton();
            this.status = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.CheckerBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckerBoard
            // 
            this.CheckerBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(103)))), ((int)(((byte)(0)))));
            this.CheckerBoard.Location = new System.Drawing.Point(23, 64);
            this.CheckerBoard.Name = "CheckerBoard";
            this.CheckerBoard.Size = new System.Drawing.Size(500, 500);
            this.CheckerBoard.TabIndex = 0;
            this.CheckerBoard.TabStop = false;
            this.CheckerBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.CheckerBoard_Paint);
            this.CheckerBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckerBoard_MouseDown);
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(634, 64);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(148, 52);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "게임시작";
            this.PlayButton.UseSelectable = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(641, 149);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(65, 19);
            this.status.TabIndex = 2;
            this.status.Text = "현재상태";
            // 
            // SinglePlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 600);
            this.Controls.Add(this.status);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.CheckerBoard);
            this.Name = "SinglePlay";
            this.Text = "SinglePlay";
            ((System.ComponentModel.ISupportInitialize)(this.CheckerBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CheckerBoard;
        private MetroFramework.Controls.MetroButton PlayButton;
        private MetroFramework.Controls.MetroLabel status;
    }
}