using _1_finalOdevOtelOtomasyonu.DAL;
using MySql.Data.MySqlClient;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace _1_finalOdevOtelOtomasyonu
{
    public partial class anaForm : Form
    {
        public anaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Personel_Giriş fr = new Personel_Giriş();
            fr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            odaDurumu fr = new odaDurumu();
            fr.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            musterileriGoruntule fr = new musterileriGoruntule();
            fr.Show();
            this.Hide();
        }

        private void anaForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            DolulukOraniniGuncelle();



            string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT İcerik FROM Duyurular ORDER BY Tarih DESC LIMIT 3";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    List<string> duyurular = new List<string>();

                    while (reader.Read())
                    {
                        duyurular.Add(reader["İcerik"].ToString());
                    }
                    reader.Close();

                    // Label'lara duyuruları yerleştir
                    if (duyurular.Count > 0) textBox1.Text = duyurular[0];
                    if (duyurular.Count > 1) textBox2.Text = duyurular[1];
                    if (duyurular.Count > 2) textBox3.Text = duyurular[2];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Duyurular yüklenirken hata oluştu: " + ex.Message);
                }
            }
        }
        private void DolulukOraniniGuncelle()
        {
            string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;";
            int doluOdaSayisi = 0;
            int toplamOdaSayisi = 108;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Odalar WHERE Durum = 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        doluOdaSayisi = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                // Doluluk oranını hesapla
                int dolulukOrani = (doluOdaSayisi * 100) / toplamOdaSayisi;

                // TrackBar'ı güncelle
                dolulukOranıTrackBar.Minimum = 0;
                dolulukOranıTrackBar.Maximum = 100;
                dolulukOranıTrackBar.Value = dolulukOrani;

                lblDolulukOranı.Text = $"Doluluk Oranı: %{dolulukOrani}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    



        private void MusteriEklebtn_Click(object sender, EventArgs e)
        {
            rezervasyonSayfasi fr = new rezervasyonSayfasi();
            fr.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Gelirler fr = new Gelirler();
            fr.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            otelPersonelleri fr = new otelPersonelleri();
            fr.Show();
            this.Hide();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void geridonbtn_Click(object sender, EventArgs e)
        {
            Personel_Giriş fr = new Personel_Giriş();   
            fr.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sifreYenile fr = new sifreYenile();
            fr.Show();
            this.Hide();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            DolulukOraniniGuncelle();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ayarlarYoneticiİşlemleri fr = new ayarlarYoneticiİşlemleri();
            fr.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            saatGosterLbl.Text = DateTime.Now.ToLongTimeString();
        }




        private void chartOdaDoluluk_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            duyurular fr = new duyurular();
            fr.Show();
            this.Hide();
        }
    }
}
