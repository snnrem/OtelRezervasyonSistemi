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
    public partial class musteriBilgileriSil : Form
    {
        public musteriBilgileriSil()
        {
            InitializeComponent();
        }

        private void LoadMusteriTablosu()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;"))
                {
                    conn.Open();
                    string query = "SELECT * FROM Musteriler";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            listView1.Items.Clear();
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

                                item.SubItems.Add(Convert.ToDateTime(reader["MusteriGirisTarihi"]).ToString("dd.MM.yyyy"));
                                item.SubItems.Add(Convert.ToDateTime(reader["MusteriCikisTarihi"]).ToString("dd.MM.yyyy"));
                                item.SubItems.Add(reader["MusteriUcret"].ToString());
                                listView1.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }





        private void button7_Click(object sender, EventArgs e)
        {
            anaForm fr = new anaForm();
            fr.Show();
            this.Hide();
        }

        private void yeniEkleBtn_Click(object sender, EventArgs e)
        {
            rezervasyonSayfasi fr = new rezervasyonSayfasi();
            fr.Show();
            this.Hide();
        }

        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            

            //try
            //{
            //    MySqlConnection baglanti =
            //    new MySqlConnection("Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;");
            //    baglanti.Open();

            //    MySqlCommand komutum = new MySqlCommand("DELETE FROM Musteriler WHERE MusteriId = " + musteriSilTextBox.Text + "");
            //    komutum.Connection = baglanti;
            //    komutum.ExecuteNonQuery();

            //    foreach (ListViewItem item in listView1.Items)
            //    {
            //        if (item.SubItems[0].Text == musteriSilTextBox.Text)
            //        {
            //            listView1.Items.Remove(item);
            //            break;
            //        }
            //    }

            //    MessageBox.Show("Müşteri Başarı İle Silindi!");
            //    baglanti.Close();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Müşteri Silinemedi!!");
            //    throw;
            //}


            //////////////////////////////////////////////////////////////////////
            if (string.IsNullOrWhiteSpace(musteriSilTextBox.Text))
            {
                MessageBox.Show("Lütfen silmek istediğiniz müşteri ID'sini girin.");
                return;
            }

            string musteriId = musteriSilTextBox.Text; // TextBox'tan müşteri ID'sini alıyoruz
            string odaNumarasi = "";

            // Veritabanı bağlantısı
            string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Adım: Müşteri tablosundan OdaNumarasi'ni alıyoruz
                    string selectQuery = "SELECT MusteriOdaNumarasi FROM Musteriler WHERE MusteriId = @MusteriId";
                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@MusteriID", musteriId);

                        using (MySqlDataReader reader = selectCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                odaNumarasi = reader["MusteriOdaNumarasi"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Girilen müşteri ID bulunamadı.");
                                return;
                            }
                        }
                    }

                    // 2. Adım: Müşteri kaydını siliyoruz
                    string deleteQuery = "DELETE FROM Musteriler WHERE MusteriID = @MusteriID";
                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@MusteriId", musteriId);
                        deleteCmd.ExecuteNonQuery();
                    }

                    // 3. Adım: Odalar tablosunda durum bilgisini güncelliyoruz
                    string updateQuery = "UPDATE Odalar SET Durum = 0 WHERE OdaNumarasi = @OdaNumarasi";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@OdaNumarasi", odaNumarasi);
                        updateCmd.ExecuteNonQuery();
                    }

                    // 4. Adım: Buton rengini yeşile çeviriyoruz
                    Button odaButton = this.Controls.Find("button" + odaNumarasi, true).FirstOrDefault() as Button;
                    if (odaButton != null)
                    {
                        odaButton.BackColor = Color.Green;
                    }

                    MessageBox.Show("Müşteri silindi ve oda durumu güncellendi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            musteriBilgileriSil fr = new musteriBilgileriSil();
            fr.Show();
            this.Hide();
        }



        private void musteriBilgileriSil_Load(object sender, EventArgs e)
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
