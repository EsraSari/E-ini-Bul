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
    public partial class Form10 : Form
    {
        SqlConnection cnn = new SqlConnection(Baglanti.conn);
        public Form10()
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
        private void button4_Click(object sender, EventArgs e)
        {
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();

            if (textBox1.Text == "" || textBox1.Text=="Öğrenci Numarası")
            {
                MessageBox.Show("Lütfen öğrenci numarası giriniz.");
                return;
            }
            if (textBox2.Text == "" || textBox2.Text=="Öğrenci Adı")
            {
                MessageBox.Show("Lütfen öğrenci adı giriniz.");
                return;
            }
            if (textBox3.Text == "" || textBox3.Text=="Öğrenci Soyadı")
            {
                MessageBox.Show("Lütfen öğrenci soyadı giriniz.");
                return;
            }

            //eklenmeden önce datadan aynı öğrenci numarası var mı kontrol ediliyor
            SqlCommand sqlCommand = new SqlCommand("Select * From OgrenciGiris where OgrenciNumarasi=" + Convert.ToInt32(textBox1.Text), cnn);
            try
            {
                if 
                    (cnn.State == ConnectionState.Closed)
                    cnn.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Bu öğrenci numarasına ait kayıt bulunmaktadır, tekrar deneyiniz.");
                    return;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }

            AddUser();

            Form1 uye = new Form1();
            this.Hide();
            uye.Show();

        }

        private void AddUser()
        {
            try
            {
                //ekleniyor
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();

                SqlCommand cmd = new SqlCommand("Insert Into OgrenciGiris(OgrenciNumarasi, OgrenciAdi, OgrenciSoyadi) Values(@no, @ad, @soyad)", cnn);
                cmd.Parameters.AddWithValue("@no", Convert.ToInt32(textBox1.Text));
                cmd.Parameters.AddWithValue("@ad", textBox2.Text);
                cmd.Parameters.AddWithValue("@soyad", textBox3.Text);

                bool sonuc = cmd.ExecuteNonQuery() > 0;

                MessageBox.Show(sonuc ? "Kayıt ekleme işleminiz başarıyla gerçekleştirilmiştir." : "Kayıt ekleme işlemi sırasında bir hatayla karşılaşıldı, tekrar deneyiniz.", "Kayıt Ekleme Bildirimi", MessageBoxButtons.OK, sonuc ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text=="Öğrenci Numarası")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Öğrenci Numarası";
               
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Öğrenci Adı")
            {
                textBox2.Text = "";
               
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Öğrenci Adı";
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Öğrenci Soyadı")
            {
                textBox3.Text = "";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Öğrenci Soyadı";
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            button4.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 uye = new Form1();
            this.Hide();
            uye.Show();
        }
    }
}
