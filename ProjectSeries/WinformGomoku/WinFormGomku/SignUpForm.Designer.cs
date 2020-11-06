namespace WinFormGomku
{
    partial class SignUpForm
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
            this.SignUpButton = new MetroFramework.Controls.MetroButton();
            this.ExitButton = new MetroFramework.Controls.MetroButton();
            this.IdTextBox = new MetroFramework.Controls.MetroTextBox();
            this.PasswordTestBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // SignUpButton
            // 
            this.SignUpButton.Location = new System.Drawing.Point(78, 187);
            this.SignUpButton.Name = "SignUpButton";
            this.SignUpButton.Size = new System.Drawing.Size(151, 41);
            this.SignUpButton.TabIndex = 2;
            this.SignUpButton.Text = "가입하기";
            this.SignUpButton.UseSelectable = true;
            this.SignUpButton.Click += new System.EventHandler(this.SignUpButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(259, 187);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(151, 41);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "나가기";
            this.ExitButton.UseSelectable = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // IdTextBox
            // 
            // 
            // 
            // 
            this.IdTextBox.CustomButton.Image = null;
            this.IdTextBox.CustomButton.Location = new System.Drawing.Point(209, 1);
            this.IdTextBox.CustomButton.Name = "";
            this.IdTextBox.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.IdTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.IdTextBox.CustomButton.TabIndex = 1;
            this.IdTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.IdTextBox.CustomButton.UseSelectable = true;
            this.IdTextBox.CustomButton.Visible = false;
            this.IdTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.IdTextBox.Lines = new string[0];
            this.IdTextBox.Location = new System.Drawing.Point(238, 83);
            this.IdTextBox.MaxLength = 12;
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.PasswordChar = '\0';
            this.IdTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.IdTextBox.SelectedText = "";
            this.IdTextBox.SelectionLength = 0;
            this.IdTextBox.SelectionStart = 0;
            this.IdTextBox.ShortcutsEnabled = true;
            this.IdTextBox.Size = new System.Drawing.Size(237, 29);
            this.IdTextBox.TabIndex = 0;
            this.IdTextBox.UseSelectable = true;
            this.IdTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.IdTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.IdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdTextBox_KeyPress);
            // 
            // PasswordTestBox
            // 
            // 
            // 
            // 
            this.PasswordTestBox.CustomButton.Image = null;
            this.PasswordTestBox.CustomButton.Location = new System.Drawing.Point(209, 1);
            this.PasswordTestBox.CustomButton.Name = "";
            this.PasswordTestBox.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.PasswordTestBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PasswordTestBox.CustomButton.TabIndex = 1;
            this.PasswordTestBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PasswordTestBox.CustomButton.UseSelectable = true;
            this.PasswordTestBox.CustomButton.Visible = false;
            this.PasswordTestBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.PasswordTestBox.Lines = new string[0];
            this.PasswordTestBox.Location = new System.Drawing.Point(238, 130);
            this.PasswordTestBox.MaxLength = 32767;
            this.PasswordTestBox.Name = "PasswordTestBox";
            this.PasswordTestBox.PasswordChar = '●';
            this.PasswordTestBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PasswordTestBox.SelectedText = "";
            this.PasswordTestBox.SelectionLength = 0;
            this.PasswordTestBox.SelectionStart = 0;
            this.PasswordTestBox.ShortcutsEnabled = true;
            this.PasswordTestBox.Size = new System.Drawing.Size(237, 29);
            this.PasswordTestBox.TabIndex = 1;
            this.PasswordTestBox.UseSelectable = true;
            this.PasswordTestBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PasswordTestBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.PasswordTestBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordTestBox_KeyPress);
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(78, 83);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(145, 29);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "ID :";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel2
            // 
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(78, 130);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(145, 29);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "PASSWORD :";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SignUpForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(507, 301);
            this.ControlBox = false;
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.PasswordTestBox);
            this.Controls.Add(this.IdTextBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SignUpButton);
            this.MaximizeBox = false;
            this.Name = "SignUpForm";
            this.Text = "SignUp";
            this.Load += new System.EventHandler(this.SignUpForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton SignUpButton;
        private MetroFramework.Controls.MetroButton ExitButton;
        private MetroFramework.Controls.MetroTextBox IdTextBox;
        private MetroFramework.Controls.MetroTextBox PasswordTestBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}