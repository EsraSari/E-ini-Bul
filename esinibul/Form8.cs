using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esinibul
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Location = new Point(
               this.ClientSize.Width / 2 - panel1.Size.Width / 2,
               this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
            panel1.Visible = true;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            button1.Select();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
       
        public static string gonderilecekveri;
        private void button1_Click(object sender, EventArgs e)
        {
            gonderilecekveri = button1.Text;
            Form9 frm = new Form9();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gonderilecekveri = button2.Text;
            Form9 frm = new Form9();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gonderilecekveri = button3.Text;
            Form9 frm = new Form9();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gonderilecekveri = button4.Text;
            Form9 frm = new Form9();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gonderilecekveri = button5.Text;
            Form9 frm = new Form9();
            frm.Show();
            this.Hide();
        }
    }
}
