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

namespace _1_finalOdevOtelOtomasyonu
{
    public partial class YeniMüşteriEkle : Form
    {
        public YeniMüşteriEkle()
        {
            InitializeComponent();
        }

        private void YeniMüşteriEkle_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA";
            string query = "SELECT * FROM Musteriler";

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
                        // Veritabanından gelen her satırı ListView'e ekleme
                        ListViewItem item = new ListViewItem(reader["MusteriId"].ToString());
                        item.SubItems.Add(reader["MusteriAd"].ToString());
                        item.SubItems.Add(reader["MusteriSoyad"].ToString());
                        item.SubItems.Add(reader["MusteriTelefon"].ToString());
                        item.SubItems.Add(reader["MusteriMail"].ToString());
                        item.SubItems.Add(reader["MusteriTc"].ToString());
                        item.SubItems.Add(reader["MusteriCinsiyet"].ToString());
                        item.SubItems.Add(reader["MusteriOdaNumarasi"].ToString());

                        item.SubItems.Add(Convert.ToDateTime(reader["MusteriGirisTarihi"]).ToString("dd.MM.yyyy"));
                        item.SubItems.Add(Convert.ToDateTime(reader["MusteriCikisTarihi"]).ToString("dd.MM.yyyy"));
                        item.SubItems.Add(reader["MusteriUcret"].ToString());
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

            comboBox1.Items.Add("Tümü");
            comboBox1.Items.Add("Aktif");
            comboBox1.Items.Add("Pasif");
            comboBox1.SelectedIndex = 0;  // Varsayılan olarak 'Tümü' seçili olsun

            LoadData("Tümü");
        }


        string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;";

        private void LoadData(string filter)
        {
            listView1.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        m.MusteriId, 
                        m.MusteriAd, 
                        m.MusteriSoyad, 
                        m.MusteriTelefon, 
                        m.MusteriMail, 
                        m.MusteriTc, 
                        m.MusteriCinsiyet, 
                        m.MusteriOdaNumarasi, 
                        m.MusteriGirisTarihi, 
                        m.MusteriCikisTarihi,
                        m.MusteriUcret,  -- Bu satırı ekleyin
                        o.Durum
                    FROM 
                        Musteriler m
                    LEFT JOIN 
                        Odalar o ON m.MusteriOdaNumarasi = o.OdaNumarasi";

                if (filter == "Aktif")
                {
                    query += " WHERE m.MusteriCikisTarihi > NOW() AND o.Durum != 0";
                }
                else if (filter == "Pasif")
                {
                    query += " WHERE m.MusteriCikisTarihi <= NOW() OR o.Durum = 0";
                }

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["MusteriId"].ToString());
                    item.SubItems.Add(reader["MusteriAd"].ToString());
                    item.SubItems.Add(reader["MusteriSoyad"].ToString());
                    item.SubItems.Add(reader["MusteriTelefon"].ToString());
                    item.SubItems.Add(reader["MusteriMail"].ToString());
                    item.SubItems.Add(reader["MusteriTc"].ToString());
                    item.SubItems.Add(reader["MusteriCinsiyet"].ToString());
                    item.SubItems.Add(reader["MusteriOdaNumarasi"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(reader["MusteriGirisTarihi"]).ToShortDateString());
                    item.SubItems.Add(Convert.ToDateTime(reader["MusteriCikisTarihi"]).ToShortDateString());
                    item.SubItems.Add(reader["MusteriUcret"].ToString());

                    listView1.Items.Add(item);
                }
                reader.Close();
            }
        }








        private void anaSayfayaGeriDönBtn_Click(object sender, EventArgs e)
        {
            anaForm fr = new anaForm();
            fr.Show();
            this.Hide();
        }

        private void musteriEkleSayfasinaGeriDonBtn_Click(object sender, EventArgs e)
        {
            rezervasyonSayfasi fr = new rezervasyonSayfasi();
            fr.Show();
            this.Hide();
        }

        private void adAraButton_Click(object sender, EventArgs e)
        {
            //listView1.Items.Clear();
            //string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA";
            //string query = @"
            //    SELECT 
            //        m.MusteriId, 
            //        m.MusteriAd, 
            //        m.MusteriSoyad, 
            //        m.MusteriTelefon, 
            //        m.MusteriMail, 
            //        m.MusteriTc, 
            //        m.MusteriCinsiyet, 
            //        m.MusteriOdaNumarasi, 
            //        m.MusteriGirisTarihi, 
            //        m.MusteriCikisTarihi,
            //        m.MusteriUcret,  -- Bu satırı ekleyin
            //        o.Durum
            //    FROM 
            //        Musteriler m
            //    LEFT JOIN 
            //        Odalar o ON m.MusteriOdaNumarasi = o.OdaNumarasi";

            //using (MySqlConnection connection = new MySqlConnection(connectionString))
            //{
            //    try
            //    {
            //        connection.Open();
            //        MySqlCommand command = new MySqlCommand(query, connection);
            //        command.Parameters.AddWithValue("@MusteriAd", "%" + adAraTextBox.Text + "%");
            //        MySqlDataReader reader = command.ExecuteReader();

            //        while (reader.Read())
            //        {
            //            ListViewItem item = new ListViewItem(reader["MusteriId"].ToString());
            //            item.SubItems.Add(reader["MusteriAd"].ToString());
            //            item.SubItems.Add(reader["MusteriSoyad"].ToString());
            //            item.SubItems.Add(reader["MusteriTelefon"].ToString());
            //            item.SubItems.Add(reader["MusteriMail"].ToString());
            //            item.SubItems.Add(reader["MusteriTc"].ToString());
            //            item.SubItems.Add(reader["MusteriCinsiyet"].ToString());
            //            item.SubItems.Add(reader["MusteriOdaNumarasi"].ToString());
            //            item.SubItems.Add(reader["MusteriUcret"].ToString());
            //            item.SubItems.Add(Convert.ToDateTime(reader["MusteriGirisTarihi"]).ToString("dd.MM.yyyy"));
            //            item.SubItems.Add(Convert.ToDateTime(reader["MusteriCikisTarihi"]).ToString("dd.MM.yyyy"));

            //            listView1.Items.Add(item);
            //        }

            //        reader.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Veri çekme hatası: " + ex.Message);
            //    }
            //}



            listView1.Items.Clear();
            string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA";
            string query = "SELECT * FROM Musteriler WHERE MusteriAd LIKE @MusteriAd";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MusteriAd", "%" + adAraTextBox.Text + "%");
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["MusteriId"].ToString());
                        item.SubItems.Add(reader["MusteriAd"].ToString());
                        item.SubItems.Add(reader["MusteriSoyad"].ToString());
                        item.SubItems.Add(reader["MusteriTelefon"].ToString());
                        item.SubItems.Add(reader["MusteriMail"].ToString());
                        item.SubItems.Add(reader["MusteriTc"].ToString());
                        item.SubItems.Add(reader["MusteriCinsiyet"].ToString());
                        item.SubItems.Add(reader["MusteriOdaNumarasi"].ToString());
                        item.SubItems.Add(reader["MusteriUcret"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["MusteriGirisTarihi"]).ToString("dd.MM.yyyy"));
                        item.SubItems.Add(Convert.ToDateTime(reader["MusteriCikisTarihi"]).ToString("dd.MM.yyyy"));

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(comboBox1.SelectedItem.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            YeniMüşteriEkle fr = new YeniMüşteriEkle();
            fr.Show();
            this.Hide();
        }
    }
}
