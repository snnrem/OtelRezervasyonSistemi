using _1_finalOdevOtelOtomasyonu.SERVICE;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace _1_finalOdevOtelOtomasyonu
{
    public partial class ayarlarYoneticiİşlemleri : Form
    {
        public ayarlarYoneticiİşlemleri()
        {
            InitializeComponent();
        }
        private void ayarlarYoneticiİşlemleri_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA";
            string query = "SELECT * FROM YoneticiGiris";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    listView1.Items.Clear(); // ListView'i temizle

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["YoneticiId"].ToString());
                        item.SubItems.Add(reader["YoneticiAdi"].ToString());
                        item.SubItems.Add(reader["YoneticiSoyadi"].ToString());
                        item.SubItems.Add(reader["YoneticiKullaniciAdi"].ToString());
                        item.SubItems.Add(reader["YoneticiSifre"].ToString());
                        
                        listView1.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekme hatası: " + ex.Message);
                    connection.Close();
                }
            }
        }

        
        

        private void yeniEkleBtn_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            anaForm fr = new anaForm();
            fr.Show();
            this.Hide();
        }

        private void yoneticiKaydetBtn_Click(object sender, EventArgs e)
        {

            //(new YoneticiService()).YoneticiKaydet(yoneticiAdTxt.Text, yoneticiSoyadTxt.Text, yoneticiKullaniciAdiTxt.Text, yoneticiSifreTxt.Text);

            //string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;";

            //using (MySqlConnection connection = new MySqlConnection(connectionString))
            //{
            //    connection.Open();
            //}
            //try
            //{
            //    //MessageBox.Show("Müşteri kaydı yapıldı.");
            //}
            //catch (Exception)
            //{
            //    //MessageBox.Show("!!!Müşteri kaydı yapılamadı!!!");
            //    throw;
            //}





            (new YoneticiService()).YoneticiKaydet(yoneticiAdTxt.Text, yoneticiSoyadTxt.Text, yoneticiKullaniciAdiTxt.Text, yoneticiSifreTxt.Text);

            try
            {
                //MessageBox.Show("Yönetici kaydı yapıldı.");
            }
            catch (Exception)
            {
                //MessageBox.Show("!!!Yönetici kaydı yapılamadı!!!");
                throw;
            }



        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void adAraButton_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA";
            string query = "SELECT * FROM Musteriler WHERE MusteriAd LIKE @MusteriAd";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@YoneticiAd", "%" + adAraTextBox.Text + "%");
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["YoneticiId"].ToString());
                        item.SubItems.Add(reader["YoneticiAd"].ToString());
                        item.SubItems.Add(reader["YoneticiSoyad"].ToString());
                        item.SubItems.Add(reader["YoneticiKullaniciAdi"].ToString());
                        item.SubItems.Add(reader["YoneticiSifre"].ToString());
                        

                        listView1.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekme hatası: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yoneticiBilgisiGuncelle fr = new yoneticiBilgisiGuncelle();
            fr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yoneticiBilgileriniSil fr = new yoneticiBilgileriniSil();
            fr.Show();
            this.Hide();
        }
    }
}
