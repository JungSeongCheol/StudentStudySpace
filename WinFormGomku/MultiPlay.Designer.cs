namespace WinFormGomku
{
    partial class MultiPlay
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
            this.roomTextBox = new MetroFramework.Controls.MetroTextBox();
            this.enterButton = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.CheckerBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckerBoard
            // 
            this.CheckerBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(103)))), ((int)(((byte)(0)))));
            this.CheckerBoard.Location = new System.Drawing.Point(26, 80);
            this.CheckerBoard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CheckerBoard.Name = "CheckerBoard";
            this.CheckerBoard.Size = new System.Drawing.Size(571, 625);
            this.CheckerBoard.TabIndex = 0;
            this.CheckerBoard.TabStop = false;
            this.CheckerBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.CheckerBoard_Paint);
            this.CheckerBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckerBoard_MouseDown);
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(725, 130);
            this.PlayButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(120, 40);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "게임시작";
            this.PlayButton.UseSelectable = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(682, 185);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(238, 20);
            this.status.TabIndex = 2;
            this.status.Text = "방을 입력하여 접속할 수 있습니다.";
            // 
            // roomTextBox
            // 
            // 
            // 
            // 
            this.roomTextBox.CustomButton.Image = null;
            this.roomTextBox.CustomButton.Location = new System.Drawing.Point(191, 2);
            this.roomTextBox.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.roomTextBox.CustomButton.Name = "";
            this.roomTextBox.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.roomTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.roomTextBox.CustomButton.TabIndex = 1;
            this.roomTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.roomTextBox.CustomButton.UseSelectable = true;
            this.roomTextBox.CustomButton.Visible = false;
            this.roomTextBox.Lines = new string[0];
            this.roomTextBox.Location = new System.Drawing.Point(624, 80);
            this.roomTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.roomTextBox.MaxLength = 32767;
            this.roomTextBox.Name = "roomTextBox";
            this.roomTextBox.PasswordChar = '\0';
            this.roomTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.roomTextBox.SelectedText = "";
            this.roomTextBox.SelectionLength = 0;
            this.roomTextBox.SelectionStart = 0;
            this.roomTextBox.ShortcutsEnabled = true;
            this.roomTextBox.Size = new System.Drawing.Size(219, 30);
            this.roomTextBox.TabIndex = 3;
            this.roomTextBox.UseSelectable = true;
            this.roomTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.roomTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.roomTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.roomTextBox_KeyPress);
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(850, 69);
            this.enterButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(123, 41);
            this.enterButton.TabIndex = 4;
            this.enterButton.Text = "접속하기";
            this.enterButton.UseSelectable = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // MultiPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.roomTextBox);
            this.Controls.Add(this.status);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.CheckerBoard);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MultiPlay";
            this.Padding = new System.Windows.Forms.Padding(23, 75, 23, 25);
            this.Text = "MultiPlay";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MultiPlay_FormClosed);
            this.Load += new System.EventHandler(this.MultiPlay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CheckerBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CheckerBoard;
        private MetroFramework.Controls.MetroButton PlayButton;
        private MetroFramework.Controls.MetroLabel status;
        private MetroFramework.Controls.MetroTextBox roomTextBox;
        private MetroFramework.Controls.MetroButton enterButton;
    }
}