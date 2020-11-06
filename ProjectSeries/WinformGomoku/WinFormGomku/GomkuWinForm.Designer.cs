namespace WinFormGomku
{
    partial class GomkuWinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GomkuWinForm));
            this.SinglePlayButton = new MetroFramework.Controls.MetroTile();
            this.ExitTile = new MetroFramework.Controls.MetroTile();
            this.MultiPlayTile = new MetroFramework.Controls.MetroTile();
            this.AITile = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // SinglePlayButton
            // 
            this.SinglePlayButton.ActiveControl = null;
            this.SinglePlayButton.Location = new System.Drawing.Point(59, 100);
            this.SinglePlayButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SinglePlayButton.Name = "SinglePlayButton";
            this.SinglePlayButton.Size = new System.Drawing.Size(250, 200);
            this.SinglePlayButton.TabIndex = 0;
            this.SinglePlayButton.Text = "혼자하기";
            this.SinglePlayButton.TileImage = ((System.Drawing.Image)(resources.GetObject("SinglePlayButton.TileImage")));
            this.SinglePlayButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SinglePlayButton.UseSelectable = true;
            this.SinglePlayButton.UseTileImage = true;
            this.SinglePlayButton.Click += new System.EventHandler(this.SinglePlayButton_Click);
            // 
            // ExitTile
            // 
            this.ExitTile.ActiveControl = null;
            this.ExitTile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ExitTile.Location = new System.Drawing.Point(341, 333);
            this.ExitTile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ExitTile.Name = "ExitTile";
            this.ExitTile.Size = new System.Drawing.Size(250, 200);
            this.ExitTile.Style = MetroFramework.MetroColorStyle.Orange;
            this.ExitTile.TabIndex = 1;
            this.ExitTile.Text = "종료하기";
            this.ExitTile.TileImage = ((System.Drawing.Image)(resources.GetObject("ExitTile.TileImage")));
            this.ExitTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ExitTile.UseSelectable = true;
            this.ExitTile.UseTileImage = true;
            this.ExitTile.Click += new System.EventHandler(this.ExitTile_Click);
            // 
            // MultiPlayTile
            // 
            this.MultiPlayTile.ActiveControl = null;
            this.MultiPlayTile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MultiPlayTile.Location = new System.Drawing.Point(340, 100);
            this.MultiPlayTile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MultiPlayTile.Name = "MultiPlayTile";
            this.MultiPlayTile.Size = new System.Drawing.Size(250, 200);
            this.MultiPlayTile.Style = MetroFramework.MetroColorStyle.Teal;
            this.MultiPlayTile.TabIndex = 1;
            this.MultiPlayTile.Text = "함께하기";
            this.MultiPlayTile.TileImage = ((System.Drawing.Image)(resources.GetObject("MultiPlayTile.TileImage")));
            this.MultiPlayTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MultiPlayTile.UseSelectable = true;
            this.MultiPlayTile.UseTileImage = true;
            this.MultiPlayTile.Click += new System.EventHandler(this.MultiPlayTile_Click);
            // 
            // AITile
            // 
            this.AITile.ActiveControl = null;
            this.AITile.Location = new System.Drawing.Point(59, 333);
            this.AITile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AITile.Name = "AITile";
            this.AITile.Size = new System.Drawing.Size(250, 200);
            this.AITile.Style = MetroFramework.MetroColorStyle.Brown;
            this.AITile.TabIndex = 0;
            this.AITile.Text = "AI전투";
            this.AITile.TileImage = ((System.Drawing.Image)(resources.GetObject("AITile.TileImage")));
            this.AITile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AITile.UseSelectable = true;
            this.AITile.UseTileImage = true;
            this.AITile.Click += new System.EventHandler(this.AITile_Click);
            // 
            // GomkuWinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 562);
            this.ControlBox = false;
            this.Controls.Add(this.MultiPlayTile);
            this.Controls.Add(this.ExitTile);
            this.Controls.Add(this.AITile);
            this.Controls.Add(this.SinglePlayButton);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "GomkuWinForm";
            this.Padding = new System.Windows.Forms.Padding(23, 75, 23, 25);
            this.Text = "오목게임";
            this.Load += new System.EventHandler(this.GomkuWinForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile SinglePlayButton;
        private MetroFramework.Controls.MetroTile ExitTile;
        private MetroFramework.Controls.MetroTile MultiPlayTile;
        private MetroFramework.Controls.MetroTile AITile;
    }
}

