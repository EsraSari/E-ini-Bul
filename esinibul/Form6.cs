using System;
using System.Collections;
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
    public partial class Form6 : Form
    {
        SqlConnection cnn = new SqlConnection(Baglanti.conn);
        public Form6()
        {
            InitializeComponent();
        }
        public static string ad;
        static int soruno = 0;
        int count = 0;
        private void Form6_Load(object sender, EventArgs e)
        {
            label1.Text = Form4.ad;
            Doldur();

            this.WindowState = FormWindowState.Maximized;

            label4.Visible = false;
            label2.Visible = false;
            button8.Text = "";
            button8.Visible = false;
            button7.Visible = false;
            button6.Visible = false;
            label1.Visible = false;
        }

        int rndSayi = 0;
        int i = 0;
        static ArrayList sayilar = new ArrayList();

        void Doldur()
        {
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }

                SqlCommand sqlCommand = new SqlCommand("SELECT ROW_NUMBER() OVER(ORDER BY Seviye) SiraNo,* from SoruCevap where Seviye=4", cnn);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    var dt = new DataTable();
                    dt.Load(reader);
                    count = dt.Rows.Count;

                    if (sayilar.Count == 0)
                    {
                        while (i < count)
                        {
                            Random rnd = new Random();
                            rndSayi = rnd.Next(1, count + 1);
                            if (!sayilar.Contains(rndSayi))
                            {
                                sayilar.Add(rndSayi);
                                i++;
                            }
                        }
                    }




                    foreach (DataRow item in dt.Select("SiraNo = " + sayilar[soruno]))
                    {
                        button1.Text = item["Soru"].ToString();
                        button2.Text = item["BirinciSecenek"].ToString();
                        button3.Text = item["IkinciSecenek"].ToString();
                        button4.Text = item["UcuncuSecenek"].ToString();
                        button5.Text = item["DorduncuSecenek"].ToString();
                        label4.Text = item["Cevap"].ToString();
                    }

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
        }
        void ShowPopup(string text, int width, int height)
        {
            // Popup adında bir form oluştur
            Form Popup = new Form
            {
                Width = width, // genişlik parametresini yaz
                Height = height, // yükseklik parametresini yaz
                ShowInTaskbar = false, // Başlat çubuğunda görülmesin
                FormBorderStyle = FormBorderStyle.None, // Form kenarlıkları yok
                BackColor = Color.White, // Arkaplan "Turuncu" rengi olsun
                StartPosition = FormStartPosition.CenterScreen, // Formu ekrana ortasında göster
                TopMost = true, // Her zaman üstte dursun
                Cursor = Cursors.Hand // Mouse şekli el şeklinde olsun
            };


            Popup.Click += delegate // Form click olayı
            {
                Popup.Close(); // tıklanıldığında popup kapat gitsin
            };

            Popup.Paint += delegate // Form içi grafik işlemleri
            {
                // Formun etrafına bir dörtgen çiz
                Popup.CreateGraphics().DrawRectangle(Pens.Silver, 0, 0, (width - 1), (height - 1));
            };


            // lbl_text adında bir label oluştur ve içine text i yaz
            Label lbl_text = new Label
            {
                Left = 30, // sol tarafa uzaklık 30 pixel
                Top = 50, // yukarıya uzaklık 30 pixel
                AutoSize = true, // label boyutunu text'e göre  ayarla
                Font = new Font("Comic Sans", 12, FontStyle.Bold), // font kalın olsun
                Text = text // metin parametresini ata
            };

            // Oluşturulan labeli forma ekle
            Popup.Controls.Add(lbl_text);
            lbl_text.ForeColor = Color.FromArgb(105, 105, 105);

            // Pop-Up formu göster
            Popup.ShowDialog();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Location = new Point(
                this.ClientSize.Width / 2 - panel1.Size.Width / 2,
                this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            button8.Text = button2.Text;

            if (button8.Text == label4.Text)
            {
                button8.Visible = true;

                button2.BackColor = System.Drawing.ColorTranslator.FromHtml("#4eee94");
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button7.Visible = true;
                button6.Visible = true;
            }
            else
            {

                button8.Visible = false;
                button2.Enabled = false;
                ShowPopup("Endişelenme!\n\nPratik yapmak mükemmelleştirir!", 350, 150);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button8.Text = button3.Text;

            if (button8.Text == label4.Text)
            {
                button8.Visible = true;

                button3.BackColor = System.Drawing.ColorTranslator.FromHtml("#4eee94");
                button2.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button7.Visible = true;
                button6.Visible = true;
            }
            else
            {

                button8.Visible = false;
                button3.Enabled = false;
                ShowPopup("Endişelenme!\n\nPratik yapmak mükemmelleştirir!", 350, 150);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button8.Text = button4.Text;

            if (button8.Text == label4.Text)
            {
                button8.Visible = true;

                button4.BackColor = System.Drawing.ColorTranslator.FromHtml("#4eee94");
                button2.Enabled = false;
                button3.Enabled = false;
                button5.Enabled = false;
                button7.Visible = true;
                button6.Visible = true;
            }
            else
            {

                button8.Visible = false;
                button4.Enabled = false;
                ShowPopup("Endişelenme!\n\nPratik yapmak mükemmelleştirir!", 350, 150);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button8.Text = button5.Text;

            if (button8.Text == label4.Text)
            {
                button8.Visible = true;
                button5.BackColor = System.Drawing.ColorTranslator.FromHtml("#4eee94");
                button3.Enabled = false;
                button4.Enabled = false;
                button2.Enabled = false;
                button7.Visible = true;
                button6.Visible = true;
            }
            else
            {

                button8.Visible = false;
                button5.Enabled = false;
                ShowPopup("Endişelenme!\n\nPratik yapmak mükemmelleştirir!", 350, 150);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ad = label1.Text;
            soruno++;
            label2.Text = soruno.ToString();
            if (soruno == count)
            {
                Form7 frm = new Form7();
                frm.Show();
                this.Hide();
            }
            else
            {
                this.Hide();
                Form6 f6 = new Form6();
                f6.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
