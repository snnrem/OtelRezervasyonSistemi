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
    public partial class sifreYenile : Form
    {
        public sifreYenile()
        {
            InitializeComponent();
        }

        private void personelİşlemleriSayfasınaDönBtn_Click(object sender, EventArgs e)
        {
            Personel_Giriş fr = new Personel_Giriş();
            fr.Show();
            this.Hide();
        }

        private void personelBilgileriniGuncelleBtn_Click(object sender, EventArgs e)
        {
            sifreYenile fr = new sifreYenile();
            fr.Show();
            this.Hide();
        }

        private void yoneticiGuncelleBtn_Click(object sender, EventArgs e)
        {
            string guvenlikKelimesi = yoneticiGuvenlikKelimesiTxt.Text;

            if (string.IsNullOrWhiteSpace(guvenlikKelimesi))
            {
                MessageBox.Show("Geçersiz Yönetici Güvenlik Kelimesi.");
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
                                     WHERE GuvenlikKelimesi = @Kelime";

                    using (MySqlCommand komut = new MySqlCommand(query, baglanti))
                    {
                        // Parametrelerin atanması
                        komut.Parameters.AddWithValue("@Kelime", guvenlikKelimesi);
                        komut.Parameters.AddWithValue("@Ad", yoneticiAdGuncelleTxt.Text);
                        komut.Parameters.AddWithValue("@Soyad", yoneticiSoyadGuncelleTxt.Text);
                        komut.Parameters.AddWithValue("@KullaniciAdi", yoneticiKullaniciAdiGuncelleTxt.Text);
                        komut.Parameters.AddWithValue("@Sifre", yoneticiSifreGuncelleTxt.Text);

                        // Sorguyu çalıştır
                        int result = komut.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Yönetici bilgileri başarıyla güncellendi!");
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

        private void sifreYenile_Load(object sender, EventArgs e)
        {

        }
    }
}
