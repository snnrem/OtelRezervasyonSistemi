using _1_finalOdevOtelOtomasyonu.DAL;
using _1_finalOdevOtelOtomasyonu.SERVICE;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Button = System.Windows.Forms.Button;

namespace _1_finalOdevOtelOtomasyonu
{
    public partial class rezervasyonSayfasi : Form
    {
        private object odaNo;

        public rezervasyonSayfasi()
        {
            InitializeComponent();
        }
        //private Color RenkDurumuAl(int odaNumarasi)
        //{
        //    using (MySqlConnection baglanti = new MySqlConnection("Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;"))
        //    {
        //        baglanti.Open();
        //        string sorgu = "SELECT Durum FROM Odalar WHERE OdaNumarasi = @OdaNumarasi";
        //        MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
        //        komut.Parameters.AddWithValue("@OdaNumarasi", odaNumarasi);

        //        object durum = komut.ExecuteScalar();
        //        if (durum != null && durum.ToString() == "Dolu")
        //        {
        //            return Color.Red; // Dolu odalar kırmızı
        //        }
        //        else
        //        {
        //            return Color.Green; // Boş odalar yeşil
        //        }
        //    }
        //}

        private void rezervasyon_Load(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection("Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;"))
            {
                connection.Open();

                // Tüm odaları veritabanından al
                MySqlCommand command = new MySqlCommand("SELECT OdaNumarasi, Durum FROM Odalar", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int odaNo = reader.GetInt32(0);
                    int durum = reader.GetInt32(1);

                    // İlgili butonu bul
                    foreach (Control control in this.Controls)
                    {
                        if (control is Button button && button.Name == "button" + odaNo)
                        {
                            // Duruma göre renk belirle
                            if (durum == 0)
                                button.BackColor = Color.Green; // Boş oda (yeşil)
                            else if (durum == 1)
                                button.BackColor = Color.Red; // Dolu oda (kırmızı)
                                
                        }
                    }
                    //reader.Close();
                }
            }


            AddButtonClickEvents(); // Tüm butonlara olay ekle
                                    // Mevcut renkleri ayarla
            using (MySqlConnection connection = new MySqlConnection("Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;"))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT OdaNumarasi, Durum FROM Odalar", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int odaNo = reader.GetInt32(0);
                    int durum = reader.GetInt32(1);

                    foreach (Control control in this.Controls)
                    {
                        if (control is Button button && button.Name == "button" + odaNo)
                        {
                            if (durum == 0)
                                button.BackColor = Color.Green; // Boş oda
                            else if (durum == 1)
                                button.BackColor = Color.Red; // Dolu oda
                        }
                    }
                }
                reader.Close();
            }



            cikisTarihiDtp.MinDate = girisTarihiDtp.Value.AddDays(1);
        }

        private void AddButtonClickEvents()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button.Name.StartsWith("button"))
                {
                    button.Click += button3_Click; // Her butona tıklama olayı ekle
                }
            }
        }


        private void cikisTarihiDtp_ValueChanged(object sender, EventArgs e)
        {
            //DateTime baslangicTarihi = girisTarihiDtp.Value;
            //DateTime bitisTarihi = cikisTarihiDtp.Value;
            //TimeSpan sonuc = bitisTarihi - baslangicTarihi;

            //int gunSayisi = (int)sonuc.TotalDays;
            //long toplamUcret = gunSayisi * 3000;
            //ucretTxt.Text = toplamUcret.ToString();

            // Kullanıcının girdiği oda numarasını al
            string odaNumarasi = odaNoTxt.Text;

            // Eğer oda numarası girilmemişse uyarı ver
            if (string.IsNullOrEmpty(odaNumarasi))
            {
                //MessageBox.Show("Lütfen geçerli bir oda numarası girin.");
                return;
            }

            // Oda fiyatını veritabanından al ve hesapla
            OdaUcretiniHesapla(odaNumarasi);
        }


        private void OdaUcretiniHesapla(string odaNumarasi)
        {
            // MySQL bağlantı cümlesi (kendi bilgilerinize göre düzenleyin)
            string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA";

            // Oda fiyatını veritabanından çekmek için SQL sorgusu
            string query = "SELECT OdaFiyat FROM Odalar WHERE OdaNumarasi = @OdaNumarasi";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OdaNumarasi", odaNumarasi);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            // Veritabanından gelen oda fiyatını al
                            int odaFiyati = Convert.ToInt32(result);

                            // Giriş ve çıkış tarihleri arasındaki gün sayısını hesapla
                            int gunSayisi = (cikisTarihiDtp.Value - girisTarihiDtp.Value).Days;

                            if (gunSayisi > 0)
                            {
                                int toplamTutar = odaFiyati * gunSayisi;
                                ucretTxt.Text = toplamTutar.ToString() + " TL";
                            }
                            else
                            {
                                MessageBox.Show("Çıkış tarihi, giriş tarihinden sonra olmalıdır.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bu oda numarasına ait fiyat bilgisi bulunamadı.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veritabanından fiyat alınırken hata oluştu: " + ex.Message);
                    }
                }
            }
        }







        private void rezervasyonKaydetBtn_Click(object sender, EventArgs e)
        {
            int odaNumarasi;

            // Oda numarası textbox'ını kontrol et
            if (int.TryParse(odaNoTxt.Text, out odaNumarasi))
            {
                using (MySqlConnection connection = new MySqlConnection("Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;"))
                {
                    connection.Open();

                    // Odanın durumunu güncelle (dolu yap)
                    MySqlCommand updateCommand = new MySqlCommand("UPDATE Odalar SET Durum = 1 WHERE OdaNumarasi = @OdaNumarasi", connection);
                    updateCommand.Parameters.AddWithValue("@OdaNumarasi", odaNumarasi);
                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // İlgili butonu bul ve rengini değiştir
                        foreach (Control control in this.Controls)
                        {
                            if (control is Button button && button.Name == "button" + odaNumarasi)
                            {
                                button.BackColor = Color.Red; // Dolu oda (kırmızı)
                                MessageBox.Show("Rezervasyon yapıldı. Oda artık dolu.");
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hata: Oda bulunamadı veya zaten dolu.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Geçerli bir oda numarası girin.");
            }




            (new MusterilerService()).MusterileriKaydet(adTxt.Text, soyadTxt.Text, telefonMtb.Text, mailTxt.Text, tcTxt.Text,
            cinsiyetComboBox.Text, odaNoTxt.Text, ucretTxt.Text, DateTime.Parse(girisTarihiDtp.Text), DateTime.Parse(cikisTarihiDtp.Text));

          
            string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open(); 
            }
            try
                {
                //MessageBox.Show("Müşteri kaydı yapıldı.");
            }
            catch (Exception)
            {
                //MessageBox.Show("!!!Müşteri kaydı yapılamadı!!!");
                throw;
            }



}

        #region Oda Numaraları
        
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    odaNoTxt.Text = "101";

        //    OdaDurumGuncelle(sender, 101);
        //}

        #endregion

        #region buttonClick
        private void button109_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeşil renkli butonlar boş odaları gösterir.");
        }

        private void button110_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kırmızı renkli butonlar dolu odaları gösterir.");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void personelBilgileriniSilBtn_Click(object sender, EventArgs e)
        {
            anaForm fr = new anaForm();
            fr.Show();
            this.Hide();
        }

        private void button111_Click(object sender, EventArgs e)
        {
            YeniMüşteriEkle fr = new YeniMüşteriEkle();
            fr.Show();
            this.Hide();
        }

        private void tekKişilikOdagroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button112_Click(object sender, EventArgs e)
        {
            musterileriGoruntule fr = new musterileriGoruntule();
            fr.Show();
            this.Hide();
        }

        private void button114_Click(object sender, EventArgs e)
        {
            musteriBilgileriSil fr = new musteriBilgileriSil();
            fr.Show();
            this.Hide();
        }

        private void yeniEkleBtn_Click(object sender, EventArgs e)
        {
            rezervasyonSayfasi fr = new rezervasyonSayfasi();
            fr.Show();
            this.Hide();
        }

        private void odaNoTxt_TextChanged(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                odaNoTxt.Text = btn.Text; // TextBox'a oda numarasını yaz
            }
        }


        private void button1_Click_2(object sender, EventArgs e)
        {

        }
        #endregion

        #region OdaNumaralari    
        private void button3_Click(object sender, EventArgs e)
        {
            odaNoTxt.Text = "103";



            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                // Butonun üzerindeki numarayı al ve textbox'a yaz
                odaNoTxt.Text = clickedButton.Text; // Oda numarasını odaNoTxt'ye aktar
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            odaNoTxt.Text = "101";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            odaNoTxt.Text = "102";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            odaNoTxt.Text = "104";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            odaNoTxt.Text = "107";
        }

        private void button73_Click(object sender, EventArgs e)
        {

        }

        private void button105_Click(object sender, EventArgs e)
        {
            odaNoTxt.Text = "105";
        }

        private void button106_Click(object sender, EventArgs e)
        {
            odaNoTxt.Text = "106";
        }

        private void button108_Click(object sender, EventArgs e)
        {
            odaNoTxt.Text = "108";
        }

        private void button109_Click_1(object sender, EventArgs e)
        {
            odaNoTxt.Text = "109";
        }

        private void button110_Click_1(object sender, EventArgs e)
        {
            odaNoTxt.Text = "110";
        }

        private void button111_Click_1(object sender, EventArgs e)
        {
            odaNoTxt.Text = "111";
        }

        private void button112_Click_1(object sender, EventArgs e)
        {
            odaNoTxt.Text = "112";
        }

        private void button201_Click(object sender, EventArgs e)
        {
            odaNoTxt.Text = "201";
        }

        private void button202_Click(object sender, EventArgs e)
        {
            odaNoTxt.Text = "202";
        }

        private void button603_Click(object sender, EventArgs e)
        {

        }


        #endregion

        private void button511_Click(object sender, EventArgs e)
        {

        }
    }
}
