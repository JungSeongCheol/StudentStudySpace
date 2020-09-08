namespace BogusMqttWinPublishApp
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.TxtBrokerIp = new MetroFramework.Controls.MetroTextBox();
            this.BtnConnect = new MetroFramework.Controls.MetroButton();
            this.RtbLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(50, 70);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(103, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "MQTT Broker IP";
            // 
            // TxtBrokerIp
            // 
            // 
            // 
            // 
            this.TxtBrokerIp.CustomButton.Image = null;
            this.TxtBrokerIp.CustomButton.Location = new System.Drawing.Point(500, 1);
            this.TxtBrokerIp.CustomButton.Name = "";
            this.TxtBrokerIp.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxtBrokerIp.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtBrokerIp.CustomButton.TabIndex = 1;
            this.TxtBrokerIp.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtBrokerIp.CustomButton.UseSelectable = true;
            this.TxtBrokerIp.CustomButton.Visible = false;
            this.TxtBrokerIp.Lines = new string[] {
        "Localhost"};
            this.TxtBrokerIp.Location = new System.Drawing.Point(159, 70);
            this.TxtBrokerIp.MaxLength = 32767;
            this.TxtBrokerIp.Name = "TxtBrokerIp";
            this.TxtBrokerIp.PasswordChar = '\0';
            this.TxtBrokerIp.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtBrokerIp.SelectedText = "";
            this.TxtBrokerIp.SelectionLength = 0;
            this.TxtBrokerIp.SelectionStart = 0;
            this.TxtBrokerIp.ShortcutsEnabled = true;
            this.TxtBrokerIp.Size = new System.Drawing.Size(522, 23);
            this.TxtBrokerIp.TabIndex = 1;
            this.TxtBrokerIp.Text = "Localhost";
            this.TxtBrokerIp.UseSelectable = true;
            this.TxtBrokerIp.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtBrokerIp.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(687, 70);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(75, 23);
            this.BtnConnect.TabIndex = 3;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseSelectable = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // RtbLog
            // 
            this.RtbLog.Location = new System.Drawing.Point(50, 99);
            this.RtbLog.Name = "RtbLog";
            this.RtbLog.Size = new System.Drawing.Size(712, 325);
            this.RtbLog.TabIndex = 4;
            this.RtbLog.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RtbLog);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.TxtBrokerIp);
            this.Controls.Add(this.metroLabel1);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "MQTT Fake Publisher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox TxtBrokerIp;
        private MetroFramework.Controls.MetroButton BtnConnect;
        private System.Windows.Forms.RichTextBox RtbLog;
    }
}

