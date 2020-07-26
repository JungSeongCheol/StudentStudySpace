namespace BusInformation
{
    partial class BusInformation
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
            this.ExitTile = new MetroFramework.Controls.MetroTile();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // ExitTile
            // 
            this.ExitTile.Location = new System.Drawing.Point(527, 480);
            this.ExitTile.Name = "ExitTile";
            this.ExitTile.Size = new System.Drawing.Size(100, 84);
            this.ExitTile.TabIndex = 1;
            this.ExitTile.TileImage = global::BusInformation.Properties.Resources.iconfinder_exit_to_app_326635;
            this.ExitTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ExitTile.UseTileImage = true;
            this.ExitTile.Click += new System.EventHandler(this.ExitTile_Click);
            // 
            // metroTile1
            // 
            this.metroTile1.Location = new System.Drawing.Point(23, 63);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(332, 325);
            this.metroTile1.TabIndex = 0;
            this.metroTile1.Text = "버스 정보 안내";
            this.metroTile1.TileImage = global::BusInformation.Properties.Resources.busIcon1;
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // BusInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 601);
            this.Controls.Add(this.ExitTile);
            this.Controls.Add(this.metroTile1);
            this.Name = "BusInformation";
            this.Text = "BusInformation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BusInformation_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile ExitTile;
    }
}

