namespace MyStockSystem
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MtlSerachItem = new MetroFramework.Controls.MetroTile();
            this.MtlStockAnals = new MetroFramework.Controls.MetroTile();
            this.MtlInvestSimuls = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // MtlSerachItem
            // 
            this.MtlSerachItem.Location = new System.Drawing.Point(26, 84);
            this.MtlSerachItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MtlSerachItem.Name = "MtlSerachItem";
            this.MtlSerachItem.Size = new System.Drawing.Size(343, 200);
            this.MtlSerachItem.TabIndex = 0;
            this.MtlSerachItem.Text = "주식정보검색";
            this.MtlSerachItem.TileImage = global::MyStockSystem.Properties.Resources.marketing2;
            this.MtlSerachItem.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MtlSerachItem.UseTileImage = true;
            this.MtlSerachItem.Click += new System.EventHandler(this.MtlSerachItem_Click);
            // 
            // MtlStockAnals
            // 
            this.MtlStockAnals.BackColor = System.Drawing.Color.White;
            this.MtlStockAnals.Location = new System.Drawing.Point(375, 84);
            this.MtlStockAnals.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MtlStockAnals.Name = "MtlStockAnals";
            this.MtlStockAnals.Size = new System.Drawing.Size(171, 200);
            this.MtlStockAnals.Style = MetroFramework.MetroColorStyle.Orange;
            this.MtlStockAnals.TabIndex = 0;
            this.MtlStockAnals.Text = "주식정보분석";
            this.MtlStockAnals.TileImage = global::MyStockSystem.Properties.Resources.analysis2;
            this.MtlStockAnals.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MtlStockAnals.UseTileImage = true;
            // 
            // MtlInvestSimuls
            // 
            this.MtlInvestSimuls.Location = new System.Drawing.Point(375, 292);
            this.MtlInvestSimuls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MtlInvestSimuls.Name = "MtlInvestSimuls";
            this.MtlInvestSimuls.Size = new System.Drawing.Size(343, 200);
            this.MtlInvestSimuls.Style = MetroFramework.MetroColorStyle.Lime;
            this.MtlInvestSimuls.TabIndex = 0;
            this.MtlInvestSimuls.Text = "투자시뮬레이션";
            this.MtlInvestSimuls.TileImage = global::MyStockSystem.Properties.Resources.simulator2;
            this.MtlInvestSimuls.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MtlInvestSimuls.UseTileImage = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.Controls.Add(this.MtlInvestSimuls);
            this.Controls.Add(this.MtlStockAnals);
            this.Controls.Add(this.MtlSerachItem);
            this.Font = new System.Drawing.Font("나눔고딕코딩", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(23, 80, 23, 27);
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "주식분석시스템";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile MtlSerachItem;
        private MetroFramework.Controls.MetroTile MtlStockAnals;
        private MetroFramework.Controls.MetroTile MtlInvestSimuls;
    }
}

