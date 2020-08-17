namespace WinFormGomku
{
    partial class LoginForm
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
            this.LoginButton = new MetroFramework.Controls.MetroButton();
            this.ExitButton = new MetroFramework.Controls.MetroButton();
            this.LoginIdTextBox = new MetroFramework.Controls.MetroTextBox();
            this.PasswordTestBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.SignUpLink = new MetroFramework.Controls.MetroLink();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(55, 187);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(180, 40);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "로그인";
            this.LoginButton.UseSelectable = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(273, 187);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(180, 40);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "나가기";
            this.ExitButton.UseSelectable = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // LoginIdTextBox
            // 
            // 
            // 
            // 
            this.LoginIdTextBox.CustomButton.Image = null;
            this.LoginIdTextBox.CustomButton.Location = new System.Drawing.Point(209, 1);
            this.LoginIdTextBox.CustomButton.Name = "";
            this.LoginIdTextBox.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.LoginIdTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.LoginIdTextBox.CustomButton.TabIndex = 1;
            this.LoginIdTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.LoginIdTextBox.CustomButton.UseSelectable = true;
            this.LoginIdTextBox.CustomButton.Visible = false;
            this.LoginIdTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.LoginIdTextBox.Lines = new string[0];
            this.LoginIdTextBox.Location = new System.Drawing.Point(238, 83);
            this.LoginIdTextBox.MaxLength = 12;
            this.LoginIdTextBox.Name = "LoginIdTextBox";
            this.LoginIdTextBox.PasswordChar = '\0';
            this.LoginIdTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.LoginIdTextBox.SelectedText = "";
            this.LoginIdTextBox.SelectionLength = 0;
            this.LoginIdTextBox.SelectionStart = 0;
            this.LoginIdTextBox.ShortcutsEnabled = true;
            this.LoginIdTextBox.Size = new System.Drawing.Size(237, 29);
            this.LoginIdTextBox.TabIndex = 0;
            this.LoginIdTextBox.UseSelectable = true;
            this.LoginIdTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.LoginIdTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.LoginIdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginIdTextBox_KeyPress);
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
            // SignUpLink
            // 
            this.SignUpLink.Location = new System.Drawing.Point(55, 245);
            this.SignUpLink.Name = "SignUpLink";
            this.SignUpLink.Size = new System.Drawing.Size(180, 33);
            this.SignUpLink.TabIndex = 4;
            this.SignUpLink.Text = "회원가입";
            this.SignUpLink.UseSelectable = true;
            this.SignUpLink.Click += new System.EventHandler(this.SignUpLink_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(507, 301);
            this.ControlBox = false;
            this.Controls.Add(this.SignUpLink);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.PasswordTestBox);
            this.Controls.Add(this.LoginIdTextBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.LoginButton);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton LoginButton;
        private MetroFramework.Controls.MetroButton ExitButton;
        private MetroFramework.Controls.MetroTextBox LoginIdTextBox;
        private MetroFramework.Controls.MetroTextBox PasswordTestBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLink SignUpLink;
    }
}