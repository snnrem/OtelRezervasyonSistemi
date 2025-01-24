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

namespace _1_finalOdevOtelOtomasyonu
{
    public partial class yoneticiBilgisiGuncelle : Form
    {
        public yoneticiBilgisiGuncelle()
        {
            InitializeComponent();
        }

        private void yoneticiBilgisiGuncelle_Load(object sender, EventArgs e)
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

                    listView1.Items.Clear();

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

        private void yoneticignc_Click(object sender, EventArgs e)
        {
            yoneticiBilgisiGuncelle fr = new yoneticiBilgisiGuncelle();
            fr.Show();
            this.Hide();
        }

        private void yoneticiGuncelleGeriDon_Click(object sender, EventArgs e)
        {
            ayarlarYoneticiİşlemleri fr = new ayarlarYoneticiİşlemleri();
            fr.Show();
            this.Hide();
        }

        private void yoneticiGuncellDon_Click(object sender, EventArgs e)
        {
            anaForm fr = new anaForm();
            fr.Show();
            this.Hide();
        }

        private void yoneticiGuncelleBtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(yoneticiIdGuncelleTxt.Text, out int yoneticiId))
            {
                MessageBox.Show("Geçersiz Yönetici ID.");
                return;
            }

            using (MySqlConnection baglanti = new MySqlConnection("Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;"))
            {
                try
                {
                    baglanti.Open();

                    // Güncelleme sorgusu
                    string query = @"UPDATE YoneticiGiris
                                     SET YoneticiAdi = @Ad, 
                                         YoneticiSoyadi = @Soyad, 
                                         YoneticiKullaniciAdi = @KullaniciAdi, 
                                         YoneticiSifre = @Sifre
                                     WHERE YoneticiId = @Id";

                    using (MySqlCommand komut = new MySqlCommand(query, baglanti))
                    {
                        // Parametrelerin atanması
                        komut.Parameters.AddWithValue("@Id", yoneticiId);
                        komut.Parameters.AddWithValue("@Ad", yoneticiAdGuncelleTxt.Text);
                        komut.Parameters.AddWithValue("@Soyad", yoneticiSoyadGuncelleTxt.Text);
                        komut.Parameters.AddWithValue("@KullaniciAdi", yoneticiKullaniciAdiGuncelleTxt.Text);
                        komut.Parameters.AddWithValue("@Sifre", yoneticiSifreGuncelleTxt.Text);

                        // Sorguyu çalıştır
                        int result = komut.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Yönetici bilgileri başarıyla güncellendi!");
                            listView1.Items.Clear();
                            yoneticiBilgisiGuncelle_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme sırasında bir hata oluştu.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            yoneticiIdGuncelleTxt.Text = listView1.SelectedItems[0].SubItems[0].Text;
            yoneticiAdGuncelleTxt.Text = listView1.SelectedItems[0].SubItems[1].Text;
            yoneticiSoyadGuncelleTxt.Text = listView1.SelectedItems[0].SubItems[2].Text;
            yoneticiKullaniciAdiGuncelleTxt.Text = listView1.SelectedItems[0].SubItems[3].Text;
            yoneticiSifreGuncelleTxt.Text = listView1.SelectedItems[0].SubItems[4].Text;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
