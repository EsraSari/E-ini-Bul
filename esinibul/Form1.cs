using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esinibul
{
    public partial class Form1 : Form
    {
        SqlConnection cnn = new SqlConnection(Baglanti.conn);
        
        public Form1()
        {
            InitializeComponent();


        }
        public static string ad;
        
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            button1.Select();
            
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Location = new Point(
                this.ClientSize.Width / 2 - panel1.Size.Width / 2,
                this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
            panel1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ad = textBox2.Text;
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();

            if (textBox1.Text == "" || textBox1.Text=="Öğrenci Numarası")
            {
                MessageBox.Show("Lütfen öğrenci numarası giriniz.");
                return;
            }

            SqlCommand sqlCommand = new SqlCommand("Select * From OgrenciGiris where OgrenciNumarasi=" + Convert.ToInt32(textBox1.Text),cnn);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                Form2 frm = new Form2();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Böyle bir kullanıcı bulunamadı.");
            }

            cnn.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 frm = new Form8();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form11 frm = new Form11();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 frm = new Form10();
            frm.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox2.Clear();
                textBox3.Clear();
            }

            if (cnn.State == ConnectionState.Closed)
                cnn.Open();

            if (textBox1.Text == "")
            {
                return;
            }

            SqlCommand sqlCommand = new SqlCommand("Select * From OgrenciGiris where OgrenciNumarasi=" + Convert.ToInt32(textBox1.Text),cnn);
            
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (!string.IsNullOrEmpty(reader["OgrenciAdi"].ToString())) textBox2.Text = reader["OgrenciAdi"].ToString();
                    if (!string.IsNullOrEmpty(reader["OgrenciSoyadi"].ToString())) textBox3.Text = reader["OgrenciSoyadi"].ToString();
                }
            }
            cnn.Close();
                    
        }

       
    }
}
