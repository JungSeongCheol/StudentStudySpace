namespace WinFormGomku
{
    partial class InviteForm
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
            this.DgvInvitingUsers = new System.Windows.Forms.DataGridView();
            this.WaitingRoomUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InviteButton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExitTile = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.DgvInvitingUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvInvitingUsers
            // 
            this.DgvInvitingUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvInvitingUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WaitingRoomUser,
            this.InviteButton});
            this.DgvInvitingUsers.Location = new System.Drawing.Point(23, 63);
            this.DgvInvitingUsers.Name = "DgvInvitingUsers";
            this.DgvInvitingUsers.RowHeadersVisible = false;
            this.DgvInvitingUsers.RowHeadersWidth = 51;
            this.DgvInvitingUsers.RowTemplate.Height = 27;
            this.DgvInvitingUsers.Size = new System.Drawing.Size(398, 340);
            this.DgvInvitingUsers.TabIndex = 0;
            // 
            // WaitingRoomUser
            // 
            this.WaitingRoomUser.HeaderText = "사용자";
            this.WaitingRoomUser.MinimumWidth = 6;
            this.WaitingRoomUser.Name = "WaitingRoomUser";
            this.WaitingRoomUser.Width = 125;
            // 
            // InviteButton
            // 
            this.InviteButton.HeaderText = "버튼";
            this.InviteButton.MinimumWidth = 6;
            this.InviteButton.Name = "InviteButton";
            this.InviteButton.Width = 125;
            // 
            // ExitTile
            // 
            this.ExitTile.ActiveControl = null;
            this.ExitTile.Location = new System.Drawing.Point(177, 408);
            this.ExitTile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitTile.Name = "ExitTile";
            this.ExitTile.Size = new System.Drawing.Size(99, 42);
            this.ExitTile.TabIndex = 6;
            this.ExitTile.Text = "나가기";
            this.ExitTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ExitTile.UseSelectable = true;
            this.ExitTile.Click += new System.EventHandler(this.ExitTile_Click);
            // 
            // InviteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 471);
            this.Controls.Add(this.ExitTile);
            this.Controls.Add(this.DgvInvitingUsers);
            this.Name = "InviteForm";
            this.Text = "초대하기";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InviteForm_FormClosing);
            this.Load += new System.EventHandler(this.InviteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvInvitingUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView DgvInvitingUsers; // MultiPlay에서 데이터그리드뷰의 값을 읽어올수 있게 하기위해서
        private MetroFramework.Controls.MetroTile ExitTile;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaitingRoomUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn InviteButton;
    }
}