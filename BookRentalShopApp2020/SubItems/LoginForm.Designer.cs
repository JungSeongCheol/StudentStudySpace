namespace BookRentalShopApp2020.SubItems
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.TextUserID = new MetroFramework.Controls.MetroTextBox();
            this.TxtPassWord = new MetroFramework.Controls.MetroTextBox();
            this.BtnOK = new MetroFramework.Controls.MetroButton();
            this.BtnCancel = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(23, 110);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(127, 23);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "PASSWORD:";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel2
            // 
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(23, 60);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(127, 23);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "ID:";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextUserID
            // 
            // 
            // 
            // 
            this.TextUserID.CustomButton.Image = null;
            this.TextUserID.CustomButton.Location = new System.Drawing.Point(185, 1);
            this.TextUserID.CustomButton.Name = "";
            this.TextUserID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextUserID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextUserID.CustomButton.TabIndex = 1;
            this.TextUserID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextUserID.CustomButton.UseSelectable = true;
            this.TextUserID.CustomButton.Visible = false;
            this.TextUserID.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TextUserID.Lines = new string[0];
            this.TextUserID.Location = new System.Drawing.Point(156, 60);
            this.TextUserID.MaxLength = 12;
            this.TextUserID.Name = "TextUserID";
            this.TextUserID.PasswordChar = '\0';
            this.TextUserID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextUserID.SelectedText = "";
            this.TextUserID.SelectionLength = 0;
            this.TextUserID.SelectionStart = 0;
            this.TextUserID.ShortcutsEnabled = true;
            this.TextUserID.Size = new System.Drawing.Size(207, 23);
            this.TextUserID.TabIndex = 0;
            this.TextUserID.UseSelectable = true;
            this.TextUserID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextUserID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TextUserID.Click += new System.EventHandler(this.TextUserID_Click);
            this.TextUserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextUserID_KeyPress);
            // 
            // TxtPassWord
            // 
            // 
            // 
            // 
            this.TxtPassWord.CustomButton.Image = null;
            this.TxtPassWord.CustomButton.Location = new System.Drawing.Point(185, 1);
            this.TxtPassWord.CustomButton.Name = "";
            this.TxtPassWord.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxtPassWord.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtPassWord.CustomButton.TabIndex = 1;
            this.TxtPassWord.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtPassWord.CustomButton.UseSelectable = true;
            this.TxtPassWord.CustomButton.Visible = false;
            this.TxtPassWord.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TxtPassWord.Lines = new string[0];
            this.TxtPassWord.Location = new System.Drawing.Point(156, 110);
            this.TxtPassWord.MaxLength = 32767;
            this.TxtPassWord.Name = "TxtPassWord";
            this.TxtPassWord.PasswordChar = '●';
            this.TxtPassWord.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtPassWord.SelectedText = "";
            this.TxtPassWord.SelectionLength = 0;
            this.TxtPassWord.SelectionStart = 0;
            this.TxtPassWord.ShortcutsEnabled = true;
            this.TxtPassWord.Size = new System.Drawing.Size(207, 23);
            this.TxtPassWord.TabIndex = 1;
            this.TxtPassWord.UseSelectable = true;
            this.TxtPassWord.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtPassWord.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TxtPassWord.Click += new System.EventHandler(this.TxtPassWord_Click);
            this.TxtPassWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPassWord_KeyPress);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(86, 153);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(112, 35);
            this.BtnOK.TabIndex = 2;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseSelectable = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(228, 153);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(112, 35);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseSelectable = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 249);
            this.ControlBox = false;
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.TxtPassWord);
            this.Controls.Add(this.TextUserID);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Resizable = false;
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox TextUserID;
        private MetroFramework.Controls.MetroTextBox TxtPassWord;
        private MetroFramework.Controls.MetroButton BtnOK;
        private MetroFramework.Controls.MetroButton BtnCancel;
    }
}