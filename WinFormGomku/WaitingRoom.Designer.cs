namespace WinFormGomku
{
    partial class WaitingRoom
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
            this.dgvRoomInfo = new System.Windows.Forms.DataGridView();
            this.dgvUsersInfo = new System.Windows.Forms.DataGridView();
            this.WaitingRoomUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerIDLabel = new MetroFramework.Controls.MetroLabel();
            this.ChatTextBox = new MetroFramework.Controls.MetroTextBox();
            this.CallMakingRoomTile = new MetroFramework.Controls.MetroTile();
            this.ExitTile = new MetroFramework.Controls.MetroTile();
            this.ChatTile = new MetroFramework.Controls.MetroTile();
            this.ChatDataTextBox = new System.Windows.Forms.RichTextBox();
            this.refreshRoomTile = new MetroFramework.Controls.MetroTile();
            this.RoomNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomUsers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObserveColum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRoomInfo
            // 
            this.dgvRoomInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoomInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomNumber,
            this.RoomName,
            this.RoomUsers,
            this.ObserveColum});
            this.dgvRoomInfo.Location = new System.Drawing.Point(23, 72);
            this.dgvRoomInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvRoomInfo.Name = "dgvRoomInfo";
            this.dgvRoomInfo.ReadOnly = true;
            this.dgvRoomInfo.RowHeadersVisible = false;
            this.dgvRoomInfo.RowHeadersWidth = 51;
            this.dgvRoomInfo.RowTemplate.Height = 27;
            this.dgvRoomInfo.Size = new System.Drawing.Size(925, 421);
            this.dgvRoomInfo.TabIndex = 0;
            this.dgvRoomInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoomInfo_CellDoubleClick);
            // 
            // dgvUsersInfo
            // 
            this.dgvUsersInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WaitingRoomUserID,
            this.UserLocation});
            this.dgvUsersInfo.Location = new System.Drawing.Point(978, 72);
            this.dgvUsersInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvUsersInfo.Name = "dgvUsersInfo";
            this.dgvUsersInfo.ReadOnly = true;
            this.dgvUsersInfo.RowHeadersVisible = false;
            this.dgvUsersInfo.RowHeadersWidth = 51;
            this.dgvUsersInfo.RowTemplate.Height = 27;
            this.dgvUsersInfo.Size = new System.Drawing.Size(279, 421);
            this.dgvUsersInfo.TabIndex = 5;
            // 
            // WaitingRoomUserID
            // 
            this.WaitingRoomUserID.HeaderText = "유저ID";
            this.WaitingRoomUserID.MinimumWidth = 6;
            this.WaitingRoomUserID.Name = "WaitingRoomUserID";
            this.WaitingRoomUserID.ReadOnly = true;
            this.WaitingRoomUserID.Width = 125;
            // 
            // UserLocation
            // 
            this.UserLocation.HeaderText = "방위치";
            this.UserLocation.MinimumWidth = 6;
            this.UserLocation.Name = "UserLocation";
            this.UserLocation.ReadOnly = true;
            this.UserLocation.Width = 125;
            // 
            // PlayerIDLabel
            // 
            this.PlayerIDLabel.AutoSize = true;
            this.PlayerIDLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.PlayerIDLabel.Location = new System.Drawing.Point(978, 518);
            this.PlayerIDLabel.Name = "PlayerIDLabel";
            this.PlayerIDLabel.Size = new System.Drawing.Size(105, 25);
            this.PlayerIDLabel.TabIndex = 1;
            this.PlayerIDLabel.Text = "플레이어ID";
            this.PlayerIDLabel.Click += new System.EventHandler(this.PlayerIDLabel_Click);
            // 
            // ChatTextBox
            // 
            // 
            // 
            // 
            this.ChatTextBox.CustomButton.Image = null;
            this.ChatTextBox.CustomButton.Location = new System.Drawing.Point(618, 2);
            this.ChatTextBox.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChatTextBox.CustomButton.Name = "";
            this.ChatTextBox.CustomButton.Size = new System.Drawing.Size(37, 37);
            this.ChatTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ChatTextBox.CustomButton.TabIndex = 1;
            this.ChatTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ChatTextBox.CustomButton.UseSelectable = true;
            this.ChatTextBox.CustomButton.Visible = false;
            this.ChatTextBox.Lines = new string[0];
            this.ChatTextBox.Location = new System.Drawing.Point(23, 698);
            this.ChatTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChatTextBox.MaxLength = 32767;
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.PasswordChar = '\0';
            this.ChatTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ChatTextBox.SelectedText = "";
            this.ChatTextBox.SelectionLength = 0;
            this.ChatTextBox.SelectionStart = 0;
            this.ChatTextBox.ShortcutsEnabled = true;
            this.ChatTextBox.Size = new System.Drawing.Size(658, 42);
            this.ChatTextBox.TabIndex = 0;
            this.ChatTextBox.UseSelectable = true;
            this.ChatTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ChatTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.ChatTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChatTextBox_KeyPress);
            // 
            // CallMakingRoomTile
            // 
            this.CallMakingRoomTile.ActiveControl = null;
            this.CallMakingRoomTile.Location = new System.Drawing.Point(796, 592);
            this.CallMakingRoomTile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CallMakingRoomTile.Name = "CallMakingRoomTile";
            this.CallMakingRoomTile.Size = new System.Drawing.Size(143, 57);
            this.CallMakingRoomTile.TabIndex = 4;
            this.CallMakingRoomTile.Text = "방만들기";
            this.CallMakingRoomTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CallMakingRoomTile.UseSelectable = true;
            this.CallMakingRoomTile.Click += new System.EventHandler(this.CallMakingRoomTile_Click);
            // 
            // ExitTile
            // 
            this.ExitTile.ActiveControl = null;
            this.ExitTile.Location = new System.Drawing.Point(795, 672);
            this.ExitTile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitTile.Name = "ExitTile";
            this.ExitTile.Size = new System.Drawing.Size(143, 66);
            this.ExitTile.TabIndex = 4;
            this.ExitTile.Text = "나가기";
            this.ExitTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ExitTile.UseSelectable = true;
            this.ExitTile.Click += new System.EventHandler(this.ExitTile_Click);
            // 
            // ChatTile
            // 
            this.ChatTile.ActiveControl = null;
            this.ChatTile.Location = new System.Drawing.Point(687, 698);
            this.ChatTile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChatTile.Name = "ChatTile";
            this.ChatTile.Size = new System.Drawing.Size(103, 42);
            this.ChatTile.TabIndex = 4;
            this.ChatTile.Text = "채팅";
            this.ChatTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChatTile.UseSelectable = true;
            this.ChatTile.Click += new System.EventHandler(this.ChatTile_Click);
            // 
            // ChatDataTextBox
            // 
            this.ChatDataTextBox.Location = new System.Drawing.Point(23, 518);
            this.ChatDataTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChatDataTextBox.Name = "ChatDataTextBox";
            this.ChatDataTextBox.ReadOnly = true;
            this.ChatDataTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ChatDataTextBox.Size = new System.Drawing.Size(767, 173);
            this.ChatDataTextBox.TabIndex = 5;
            this.ChatDataTextBox.Text = "";
            // 
            // refreshRoomTile
            // 
            this.refreshRoomTile.ActiveControl = null;
            this.refreshRoomTile.Location = new System.Drawing.Point(796, 518);
            this.refreshRoomTile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.refreshRoomTile.Name = "refreshRoomTile";
            this.refreshRoomTile.Size = new System.Drawing.Size(143, 57);
            this.refreshRoomTile.TabIndex = 4;
            this.refreshRoomTile.Text = "방 새로고침";
            this.refreshRoomTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.refreshRoomTile.UseSelectable = true;
            this.refreshRoomTile.Click += new System.EventHandler(this.refreshRoomTile_Click);
            // 
            // RoomNumber
            // 
            this.RoomNumber.HeaderText = "방번호";
            this.RoomNumber.MinimumWidth = 6;
            this.RoomNumber.Name = "RoomNumber";
            this.RoomNumber.ReadOnly = true;
            this.RoomNumber.Width = 125;
            // 
            // RoomName
            // 
            this.RoomName.HeaderText = "방제목";
            this.RoomName.MinimumWidth = 6;
            this.RoomName.Name = "RoomName";
            this.RoomName.ReadOnly = true;
            this.RoomName.Width = 200;
            // 
            // RoomUsers
            // 
            this.RoomUsers.HeaderText = "인원수";
            this.RoomUsers.MinimumWidth = 6;
            this.RoomUsers.Name = "RoomUsers";
            this.RoomUsers.ReadOnly = true;
            this.RoomUsers.Width = 125;
            // 
            // ObserveColum
            // 
            this.ObserveColum.HeaderText = "관전인원";
            this.ObserveColum.MinimumWidth = 6;
            this.ObserveColum.Name = "ObserveColum";
            this.ObserveColum.ReadOnly = true;
            this.ObserveColum.Width = 125;
            // 
            // WaitingRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.ChatDataTextBox);
            this.Controls.Add(this.ExitTile);
            this.Controls.Add(this.ChatTile);
            this.Controls.Add(this.refreshRoomTile);
            this.Controls.Add(this.CallMakingRoomTile);
            this.Controls.Add(this.ChatTextBox);
            this.Controls.Add(this.PlayerIDLabel);
            this.Controls.Add(this.dgvUsersInfo);
            this.Controls.Add(this.dgvRoomInfo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "WaitingRoom";
            this.Padding = new System.Windows.Forms.Padding(21, 75, 21, 20);
            this.Text = "WaitingRoom";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WaitingRoom_FormClosed);
            this.Load += new System.EventHandler(this.WaitingRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRoomInfo;
        private System.Windows.Forms.DataGridView dgvUsersInfo;
        private MetroFramework.Controls.MetroLabel PlayerIDLabel;
        private MetroFramework.Controls.MetroTextBox ChatTextBox;
        private MetroFramework.Controls.MetroTile CallMakingRoomTile;
        private MetroFramework.Controls.MetroTile ExitTile;
        private MetroFramework.Controls.MetroTile ChatTile;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaitingRoomUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserLocation;
        private System.Windows.Forms.RichTextBox ChatDataTextBox;
        private MetroFramework.Controls.MetroTile refreshRoomTile;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObserveColum;
    }
}