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
            this.readyButton = new MetroFramework.Controls.MetroButton();
            this.status = new MetroFramework.Controls.MetroLabel();
            this.ChatDataTextBox = new System.Windows.Forms.RichTextBox();
            this.ChatTextBox = new MetroFramework.Controls.MetroTextBox();
            this.ChatTile = new MetroFramework.Controls.MetroTile();
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
            // readyButton
            // 
            this.readyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.readyButton.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.readyButton.Location = new System.Drawing.Point(659, 79);
            this.readyButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.readyButton.Name = "readyButton";
            this.readyButton.Size = new System.Drawing.Size(172, 64);
            this.readyButton.TabIndex = 1;
            this.readyButton.Text = "Ready";
            this.readyButton.UseSelectable = true;
            this.readyButton.Click += new System.EventHandler(this.readyButton_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(659, 180);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(264, 20);
            this.status.TabIndex = 2;
            this.status.Text = "다른유저의 레디를 기다리는 중입니다.";
            this.status.Click += new System.EventHandler(this.status_Click);
            // 
            // ChatDataTextBox
            // 
            this.ChatDataTextBox.Location = new System.Drawing.Point(647, 255);
            this.ChatDataTextBox.Name = "ChatDataTextBox";
            this.ChatDataTextBox.ReadOnly = true;
            this.ChatDataTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ChatDataTextBox.Size = new System.Drawing.Size(340, 307);
            this.ChatDataTextBox.TabIndex = 3;
            this.ChatDataTextBox.Text = "";
            // 
            // ChatTextBox
            // 
            // 
            // 
            // 
            this.ChatTextBox.CustomButton.Image = null;
            this.ChatTextBox.CustomButton.Location = new System.Drawing.Point(181, 2);
            this.ChatTextBox.CustomButton.Name = "";
            this.ChatTextBox.CustomButton.Size = new System.Drawing.Size(37, 37);
            this.ChatTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ChatTextBox.CustomButton.TabIndex = 1;
            this.ChatTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ChatTextBox.CustomButton.UseSelectable = true;
            this.ChatTextBox.CustomButton.Visible = false;
            this.ChatTextBox.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.ChatTextBox.Lines = new string[0];
            this.ChatTextBox.Location = new System.Drawing.Point(647, 593);
            this.ChatTextBox.MaxLength = 32767;
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.PasswordChar = '\0';
            this.ChatTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ChatTextBox.SelectedText = "";
            this.ChatTextBox.SelectionLength = 0;
            this.ChatTextBox.SelectionStart = 0;
            this.ChatTextBox.ShortcutsEnabled = true;
            this.ChatTextBox.Size = new System.Drawing.Size(221, 42);
            this.ChatTextBox.TabIndex = 0;
            this.ChatTextBox.UseSelectable = true;
            this.ChatTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ChatTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.ChatTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChatTextBox_KeyPress);
            // 
            // ChatTile
            // 
            this.ChatTile.ActiveControl = null;
            this.ChatTile.Location = new System.Drawing.Point(884, 593);
            this.ChatTile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChatTile.Name = "ChatTile";
            this.ChatTile.Size = new System.Drawing.Size(103, 42);
            this.ChatTile.TabIndex = 5;
            this.ChatTile.Text = "채팅";
            this.ChatTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChatTile.UseSelectable = true;
            this.ChatTile.Click += new System.EventHandler(this.ChatTile_Click);
            // 
            // MultiPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.Controls.Add(this.ChatTile);
            this.Controls.Add(this.ChatTextBox);
            this.Controls.Add(this.ChatDataTextBox);
            this.Controls.Add(this.status);
            this.Controls.Add(this.readyButton);
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
        private MetroFramework.Controls.MetroButton readyButton;
        private MetroFramework.Controls.MetroLabel status;
        private System.Windows.Forms.RichTextBox ChatDataTextBox;
        private MetroFramework.Controls.MetroTextBox ChatTextBox;
        private MetroFramework.Controls.MetroTile ChatTile;
    }
}