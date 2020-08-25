namespace WinFormGomku
{
    partial class MultiPlayInvitedRoomForm
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
            this.InvitedLabel = new MetroFramework.Controls.MetroLabel();
            this.OKButton = new MetroFramework.Controls.MetroButton();
            this.RejectButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // InvitedLabel
            // 
            this.InvitedLabel.AutoSize = true;
            this.InvitedLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.InvitedLabel.Location = new System.Drawing.Point(43, 89);
            this.InvitedLabel.Name = "InvitedLabel";
            this.InvitedLabel.Size = new System.Drawing.Size(88, 25);
            this.InvitedLabel.TabIndex = 0;
            this.InvitedLabel.Text = "초대안내";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(102, 144);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(145, 46);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "수락";
            this.OKButton.UseSelectable = true;
            // 
            // RejectButton
            // 
            this.RejectButton.Location = new System.Drawing.Point(336, 144);
            this.RejectButton.Name = "RejectButton";
            this.RejectButton.Size = new System.Drawing.Size(145, 46);
            this.RejectButton.TabIndex = 1;
            this.RejectButton.Text = "거절";
            this.RejectButton.UseSelectable = true;
            this.RejectButton.Click += new System.EventHandler(this.RejectButton_Click);
            // 
            // MultiPlayInvitedRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 225);
            this.Controls.Add(this.RejectButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.InvitedLabel);
            this.Name = "MultiPlayInvitedRoomForm";
            this.Text = "초대안내";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public MetroFramework.Controls.MetroLabel InvitedLabel;
        public MetroFramework.Controls.MetroButton OKButton;
        private MetroFramework.Controls.MetroButton RejectButton;
    }
}