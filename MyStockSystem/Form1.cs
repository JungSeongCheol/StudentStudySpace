using MetroFramework.Forms;
using MyStockSystem.SubItems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStockSystem
{
    public partial class Form1 : MetroForm // Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Location = new Point(
               Screen.PrimaryScreen.Bounds.Width / 2 - this.Size.Width / 2,
               Screen.PrimaryScreen.Bounds.Height / 2 - this.Size.Height / 2
            );
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Location = new Point(
            //   Screen.PrimaryScreen.Bounds.Width / 2 - this.Size.Width / 2,
            //   Screen.PrimaryScreen.Bounds.Height / 2 - this.Size.Height / 2
            //);
        }

        private void MtlSerachItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SearchItemForm serachItem = new SearchItemForm();
            serachItem.Location = this.Location;
            serachItem.ShowDialog();

            this.Close();
        }
    }
}
