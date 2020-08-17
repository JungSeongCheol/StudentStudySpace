namespace WinFormGomku
{
    partial class MakingRoom
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
            this.MakingRoomButton = new MetroFramework.Controls.MetroButton();
            this.ExitButton = new MetroFramework.Controls.MetroButton();
            this.MakingRoomTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // MakingRoomButton
            // 
            this.MakingRoomButton.Location = new System.Drawing.Point(44, 144);
            this.MakingRoomButton.Name = "MakingRoomButton";
            this.MakingRoomButton.Size = new System.Drawing.Size(131, 42);
            this.MakingRoomButton.TabIndex = 1;
            this.MakingRoomButton.Text = "방만들기";
            this.MakingRoomButton.UseSelectable = true;
            this.MakingRoomButton.Click += new System.EventHandler(this.MakingRoomButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(220, 144);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(131, 42);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "나가기";
            this.ExitButton.UseSelectable = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MakingRoomTextBox1
            // 
            // 
            // 
            // 
            this.MakingRoomTextBox1.CustomButton.Image = null;
            this.MakingRoomTextBox1.CustomButton.Location = new System.Drawing.Point(269, 2);
            this.MakingRoomTextBox1.CustomButton.Name = "";
            this.MakingRoomTextBox1.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.MakingRoomTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.MakingRoomTextBox1.CustomButton.TabIndex = 1;
            this.MakingRoomTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MakingRoomTextBox1.CustomButton.UseSelectable = true;
            this.MakingRoomTextBox1.CustomButton.Visible = false;
            this.MakingRoomTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.MakingRoomTextBox1.Lines = new string[0];
            this.MakingRoomTextBox1.Location = new System.Drawing.Point(44, 85);
            this.MakingRoomTextBox1.MaxLength = 32767;
            this.MakingRoomTextBox1.Name = "MakingRoomTextBox1";
            this.MakingRoomTextBox1.PasswordChar = '\0';
            this.MakingRoomTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.MakingRoomTextBox1.SelectedText = "";
            this.MakingRoomTextBox1.SelectionLength = 0;
            this.MakingRoomTextBox1.SelectionStart = 0;
            this.MakingRoomTextBox1.ShortcutsEnabled = true;
            this.MakingRoomTextBox1.Size = new System.Drawing.Size(307, 40);
            this.MakingRoomTextBox1.TabIndex = 0;
            this.MakingRoomTextBox1.UseSelectable = true;
            this.MakingRoomTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.MakingRoomTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.MakingRoomTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MakingRoomTextBox1_KeyPress);
            // 
            // MakingRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 223);
            this.Controls.Add(this.MakingRoomTextBox1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.MakingRoomButton);
            this.Name = "MakingRoom";
            this.Text = "MakingRoom";
            this.Load += new System.EventHandler(this.MakingRoom_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton MakingRoomButton;
        private MetroFramework.Controls.MetroButton ExitButton;
        private MetroFramework.Controls.MetroTextBox MakingRoomTextBox1;
    }
}