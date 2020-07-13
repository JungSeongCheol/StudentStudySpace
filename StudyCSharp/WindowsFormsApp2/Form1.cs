using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Click Event Occured");
            //return;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click Event Occured");
            return;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox2.Focus();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += Button1_Click;
            textBox1.KeyPress += TextBox1_KeyPress;
        }
    }
}
