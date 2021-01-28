using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace esinibul
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(Baglanti.conn);
        private void Form9_Load(object sender, EventArgs e)
        {
           
            this.WindowState = FormWindowState.Maximized;
            button1.Select();
            textBox1.Text = Form8.gonderilecekveri;
            label1.Text = Form8.gonderilecekveri;
            if (label1.Text== "1 Harfli")
            {
                label3.Text = "1";
            }
            else if (label1.Text == "2 Harfli")
            {
                label3.Text = "2";
            }
            else if (label1.Text == "3 Harfli")
            {
                label3.Text = "3";
            }
            else if (label1.Text == "4 Harfli")
            {
                label3.Text = "4";
            }
            else if (label1.Text == "Cümle")
            {
                label3.Text = "5";
            }
            label1.Visible = false;
            label3.Visible = false;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Location = new Point(
               this.ClientSize.Width / 2 - panel1.Size.Width / 2,
               this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
            panel1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form8 frm = new Form8();
            frm.Show();
            this.Hide();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                if (label1.Text=="1 Harfli")
                {
                    if (textBox1.Text == "1 Harfli" || textBox2.Text == "Seçenek-1" || textBox3.Text == "Seçenek-2" || textBox4.Text == "Seçenek-3" || textBox5.Text == "Seçenek-4" || textBox6.Text == "Doğru Seçenek")
                    {
                        MessageBox.Show("Lütfen bilgilerinizi kontrol ediniz.");
                    }
                    else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                    {
                        MessageBox.Show("Lütfen bilgilerinizi kontrol ediniz.");

                    }
                    else
                    {
                        SqlCommand komut = new SqlCommand("insert into SoruCevap (Soru,Seviye,BirinciSecenek,IkinciSecenek,UcuncuSecenek,DorduncuSecenek,Cevap) values ('" + textBox1.Text.ToString() + "','" + label3.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "')", cnn);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kelime ekleme işlemi tamamlanmıştır.");
                        Form1 frm = new Form1();
                        frm.Show();
                        this.Hide();
                    }
                }
                if (label1.Text == "2 Harfli")
                {
                    if (textBox1.Text == "2 Harfli" || textBox2.Text == "Seçenek-1" || textBox3.Text == "Seçenek-2" || textBox4.Text == "Seçenek-3" || textBox5.Text == "Seçenek-4" || textBox6.Text == "Doğru Seçenek")
                    {
                        MessageBox.Show("Lütfen bilgilerinizi kontrol ediniz.");
                    }
                    else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                    {
                        MessageBox.Show("Lütfen bilgilerinizi kontrol ediniz.");

                    }
                    else
                    {
                        SqlCommand komut = new SqlCommand("insert into SoruCevap (Soru,Seviye,BirinciSecenek,IkinciSecenek,UcuncuSecenek,DorduncuSecenek,Cevap) values ('" + textBox1.Text.ToString() + "','" + label3.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "')", cnn);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kelime ekleme işlemi tamamlanmıştır.");
                        Form1 frm = new Form1();
                        frm.Show();
                        this.Hide();
                    }
                }
                if (label1.Text == "3 Harfli")
                {
                    if (textBox1.Text == "3 Harfli" || textBox2.Text == "Seçenek-1" || textBox3.Text == "Seçenek-2" || textBox4.Text == "Seçenek-3" || textBox5.Text == "Seçenek-4" || textBox6.Text == "Doğru Seçenek")
                    {
                        MessageBox.Show("Lütfen bilgilerinizi kontrol ediniz.");
                    }
                    else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                    {
                        MessageBox.Show("Lütfen bilgilerinizi kontrol ediniz.");

                    }
                    else
                    {
                        SqlCommand komut = new SqlCommand("insert into SoruCevap (Soru,Seviye,BirinciSecenek,IkinciSecenek,UcuncuSecenek,DorduncuSecenek,Cevap) values ('" + textBox1.Text.ToString() + "','" + label3.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "')", cnn);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kelime ekleme işlemi tamamlanmıştır.");
                        Form1 frm = new Form1();
                        frm.Show();
                        this.Hide();
                    }
                }
                if (label1.Text == "4 Harfli")
                {
                    if (textBox1.Text == "4 Harfli" || textBox2.Text == "Seçenek-1" || textBox3.Text == "Seçenek-2" || textBox4.Text == "Seçenek-3" || textBox5.Text == "Seçenek-4" || textBox6.Text == "Doğru Seçenek")
                    {
                        MessageBox.Show("Lütfen bilgilerinizi kontrol ediniz.");
                    }
                    else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                    {
                        MessageBox.Show("Lütfen bilgilerinizi kontrol ediniz.");

                    }
                    else
                    {
                        SqlCommand komut = new SqlCommand("insert into SoruCevap (Soru,Seviye,BirinciSecenek,IkinciSecenek,UcuncuSecenek,DorduncuSecenek,Cevap) values ('" + textBox1.Text.ToString() + "','" + label3.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "')", cnn);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kelime ekleme işlemi tamamlanmıştır.");
                        Form1 frm = new Form1();
                        frm.Show();
                        this.Hide();
                    }
                }
                if (label1.Text == "Cümle")
                {
                    if (textBox1.Text == "Cümle" || textBox2.Text == "Seçenek-1" || textBox3.Text == "Seçenek-2" || textBox4.Text == "Seçenek-3" || textBox5.Text == "Seçenek-4" || textBox6.Text == "Doğru Seçenek")
                    {
                        MessageBox.Show("Lütfen bilgilerinizi kontrol ediniz.");
                    }
                    else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                    {
                        MessageBox.Show("Lütfen bilgilerinizi kontrol ediniz.");

                    }
                    else
                    {
                        SqlCommand komut = new SqlCommand("insert into SoruCevap (Soru,Seviye,BirinciSecenek,IkinciSecenek,UcuncuSecenek,DorduncuSecenek,Cevap) values ('" + textBox1.Text.ToString() + "','" + label3.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "')", cnn);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Kelime ekleme işlemi tamamlanmıştır.");
                        Form1 frm = new Form1();
                        frm.Show();
                        this.Hide();
                    }
                }
                cnn.Close();
            }
            catch 
            {

                MessageBox.Show("Lütfen bilgilerinizi kontrol ediniz.");
            }
            
          
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }
    }
}
