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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _1_finalOdevOtelOtomasyonu
{

    public partial class Gelirler : Form
    {
        public Gelirler()
        {
            InitializeComponent();
        }

        string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA";

        private void button1_Click(object sender, EventArgs e)
        {
            gelirGiderler fr = new gelirGiderler();
            fr.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            anaForm fr = new anaForm();
            fr.Show();
            this.Hide();
        }

        private void yoneticiBilgileriBtn_Click(object sender, EventArgs e)
        {
            Gelirler fr = new Gelirler();
            fr.Show();
            this.Hide();
        }

        private void Gelirler_Load(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Faturalar";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    listViewFaturalar.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["MusteriId"].ToString());
                        item.SubItems.Add(reader["RezervasyonDurumu"].ToString());
                        item.SubItems.Add(reader["ToplamUcret"].ToString());
                        item.SubItems.Add(reader["MusteriUcret"].ToString());
                        item.SubItems.Add(reader["MusteriAd"].ToString());
                        item.SubItems.Add(reader["MusteriSoyad"].ToString());
                        item.SubItems.Add(reader["MusteriTelefon"].ToString());
                        item.SubItems.Add(reader["MusteriMail"].ToString());
                        item.SubItems.Add(reader["MusteriTc"].ToString());
                        item.SubItems.Add(reader["MusteriCinsiyet"].ToString());
                        item.SubItems.Add(reader["MusteriOdaNumarasi"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["MusteriGirisTarihi"]).ToString("dd.MM.yyyy"));
                        item.SubItems.Add(Convert.ToDateTime(reader["MusteriCikisTarihi"]).ToString("dd.MM.yyyy"));
                        listViewFaturalar.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void AddFaturaFromMusteriler()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Müşteriler tablosundan tüm müşteri bilgilerini çek
                    string query = "SELECT * FROM Musteriler";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    List<Musteri> musteriler = new List<Musteri>();

                    while (reader.Read())
                    {
                        Musteri musteri = new Musteri
                        {
                            MusteriId = Convert.ToInt32(reader["MusteriId"]),
                            MusteriAd = reader["MusteriAd"].ToString(),
                            MusteriSoyad = reader["MusteriSoyad"].ToString(),
                            MusteriTelefon = reader["MusteriTelefon"].ToString(),
                            MusteriMail = reader["MusteriMail"].ToString(),
                            MusteriTc = reader["MusteriTc"].ToString(),
                            MusteriCinsiyet = reader["MusteriCinsiyet"].ToString(),
                            MusteriOdaNumarasi = reader["MusteriOdaNumarasi"].ToString(),
                            MusteriGirisTarihi = Convert.ToDateTime(reader["MusteriGirisTarihi"]),
                            MusteriCikisTarihi = Convert.ToDateTime(reader["MusteriCikisTarihi"]),
                            MusteriUcret = Convert.ToInt32(reader["MusteriUcret"])
                        };
                        musteriler.Add(musteri);
                    }
                    reader.Close();

                    int toplamUcret = 0;

                    foreach (var musteri in musteriler)
                    {
                        // Rezervasyon durumunu belirle
                        string rezervasyonDurumu = musteri.MusteriCikisTarihi < DateTime.Now ? "Eski Rezervasyon" : "Aktif Rezervasyon";

                        // Toplam ücreti güncelle
                        toplamUcret += musteri.MusteriUcret;

                        // Eğer müşteri zaten faturalar tablosunda yoksa ekle
                        string insertQuery = @"
                                INSERT INTO Faturalar (MusteriId, RezervasyonDurumu, MusteriUcret, ToplamUcret, MusteriAd, MusteriSoyad, 
                                MusteriTelefon, MusteriMail, MusteriTc, MusteriCinsiyet, MusteriOdaNumarasi, MusteriGirisTarihi, MusteriCikisTarihi) 
                                VALUES (@MusteriId, @RezervasyonDurumu, @MusteriUcret, @ToplamUcret, @MusteriAd, @MusteriSoyad, 
                                @MusteriTelefon, @MusteriMail, @MusteriTc, @MusteriCinsiyet, @MusteriOdaNumarasi, @MusteriGirisTarihi, @MusteriCikisTarihi)
                                ON DUPLICATE KEY UPDATE RezervasyonDurumu = @RezervasyonDurumu, MusteriUcret = @MusteriUcret, ToplamUcret = @ToplamUcret";

                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@MusteriId", musteri.MusteriId);
                            insertCmd.Parameters.AddWithValue("@RezervasyonDurumu", rezervasyonDurumu);
                            insertCmd.Parameters.AddWithValue("@MusteriUcret", musteri.MusteriUcret);
                            insertCmd.Parameters.AddWithValue("@ToplamUcret", toplamUcret); // ToplamUcret alanına güncellenmiş toplam ücreti atıyoruz
                            insertCmd.Parameters.AddWithValue("@MusteriAd", musteri.MusteriAd);
                            insertCmd.Parameters.AddWithValue("@MusteriSoyad", musteri.MusteriSoyad);
                            insertCmd.Parameters.AddWithValue("@MusteriTelefon", musteri.MusteriTelefon);
                            insertCmd.Parameters.AddWithValue("@MusteriMail", musteri.MusteriMail);
                            insertCmd.Parameters.AddWithValue("@MusteriTc", musteri.MusteriTc);
                            insertCmd.Parameters.AddWithValue("@MusteriCinsiyet", musteri.MusteriCinsiyet);
                            insertCmd.Parameters.AddWithValue("@MusteriOdaNumarasi", musteri.MusteriOdaNumarasi);
                            insertCmd.Parameters.AddWithValue("@MusteriGirisTarihi", musteri.MusteriGirisTarihi);
                            insertCmd.Parameters.AddWithValue("@MusteriCikisTarihi", musteri.MusteriCikisTarihi);

                            insertCmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Müşteri bilgileri faturalar tablosuna başarıyla eklendi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }

        private void btnFaturaGetir_Click(object sender, EventArgs e)
        {
            AddFaturaFromMusteriler();
            Gelirler_Load(sender, e);
        }

        private void CalculateTotalRevenue()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT SUM(ToplamUcret) AS Total FROM Faturalar";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    object result = cmd.ExecuteScalar();
                    int total = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                    MessageBox.Show("Toplam Ücret: " + total.ToString("C0"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Toplam ücret hesaplanırken hata oluştu: " + ex.Message);
                }
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            anaForm fr = new anaForm();
            fr.Show();
            this.Hide();
        }

        public class Musteri
        {
            public int MusteriId { get; set; }
            public string MusteriAd { get; set; }
            public string MusteriSoyad { get; set; }
            public string MusteriTelefon { get; set; }
            public string MusteriMail { get; set; }
            public string MusteriTc { get; set; }
            public string MusteriCinsiyet { get; set; }
            public string MusteriOdaNumarasi { get; set; }
            public DateTime MusteriGirisTarihi { get; set; }
            public DateTime MusteriCikisTarihi { get; set; }
            public int MusteriUcret { get; set; }
        }

        private void adAraButton_Click(object sender, EventArgs e)
        {
            listViewFaturalar.Items.Clear();
            string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA";
            string query = "SELECT * FROM Faturalar WHERE MusteriAd LIKE @MusteriAd";

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
                        item.SubItems.Add(reader["RezervasyonDurumu"].ToString());
                        item.SubItems.Add(reader["ToplamUcret"].ToString());
                        item.SubItems.Add(reader["MusteriUcret"].ToString());
                        item.SubItems.Add(reader["MusteriAd"].ToString());
                        item.SubItems.Add(reader["MusteriSoyad"].ToString());
                        item.SubItems.Add(reader["MusteriTelefon"].ToString());
                        item.SubItems.Add(reader["MusteriMail"].ToString());
                        item.SubItems.Add(reader["MusteriTc"].ToString());
                        item.SubItems.Add(reader["MusteriCinsiyet"].ToString());
                        item.SubItems.Add(reader["MusteriOdaNumarasi"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["MusteriGirisTarihi"]).ToString("dd.MM.yyyy"));
                        item.SubItems.Add(Convert.ToDateTime(reader["MusteriCikisTarihi"]).ToString("dd.MM.yyyy"));

                        listViewFaturalar.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekme hatası: " + ex.Message);
                }
            }

        }
    }
    
}
