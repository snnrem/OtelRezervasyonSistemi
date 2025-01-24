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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace _1_finalOdevOtelOtomasyonu
{
    public partial class personelBilgileriniGuncelle : Form
    {
        public personelBilgileriniGuncelle()
        {
            InitializeComponent();
        }

        private void personelBilgileriniGuncelleBtn_Click(object sender, EventArgs e)
        {
            personelBilgileriniGuncelle personelBilgileriniGuncelle = new personelBilgileriniGuncelle();
            personelBilgileriniGuncelle.Show();
            this.Hide();
        }

        private void personelİşlemleriSayfasınaDönBtn_Click(object sender, EventArgs e)
        {
            otelPersonelleri otelPersonelleri = new otelPersonelleri();
            otelPersonelleri.Show();
            this.Hide();
        }

        private void anaSayfayaDönBtn_Click(object sender, EventArgs e)
        {
            anaForm anaForm = new anaForm();
            anaForm.Show();
            this.Hide();
        }

        private void personelBilgileriniGuncelleButton_Click(object sender, EventArgs e)
        {



            using (MySqlConnection baglanti = new MySqlConnection("Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;"))
            {
                try
                {
                    baglanti.Open();

                    // Güncelleme sorgusu
                    string query = @"UPDATE Personel
                         SET PersonelAd = @Ad, 
                             PersonelSoyad = @Soyad, 
                             PersonelTC = @TC, 
                             PersonelTelefon = @Telefon, 
                             PersonelMail = @Mail, 
                             PersonelAdres = @Adres, 
                             PersonelDepartmanAdi = @Departman, 
                             PersonelGorev = @Gorev, 
                             PersonelMaas = @Maas, 
                             PersonelGirisTarihi = @GirisTarihi
                         WHERE PersonelId = @Id";

                    using (MySqlCommand komut = new MySqlCommand(query, baglanti))
                    {
                        // Parametrelerin atanması
                        komut.Parameters.AddWithValue("@Ad", personelAdGuncelleTxt.Text);
                        komut.Parameters.AddWithValue("@Soyad", personelSoyadGuncelleTxt.Text);
                        komut.Parameters.AddWithValue("@TC", personelTcGuncelleTxt.Text);
                        komut.Parameters.AddWithValue("@Telefon", personelTelefonGuncelleMtb.Text);
                        komut.Parameters.AddWithValue("@Mail", personelMailGuncelleTxt.Text);
                        komut.Parameters.AddWithValue("@Adres", personelAdresGuncelleTxt.Text);
                        komut.Parameters.AddWithValue("@Departman", personelDepartmanAdiGuncelleTxt.Text);
                        komut.Parameters.AddWithValue("@Gorev", personelGorevGuncelleTxt.Text);
                        komut.Parameters.AddWithValue("@Maas", Convert.ToInt32(personelMaasGuncelleTxt.Text));
                        komut.Parameters.AddWithValue("@GirisTarihi", personelGirisTarihiGuncelleDtp.Value.ToString("yyyy-MM-dd"));
                        komut.Parameters.AddWithValue("@Id", Convert.ToInt32(personelIdGuncelleTxt.Text));

                        // Sorguyu çalıştır
                        int result = komut.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Personel bilgileri başarıyla güncellendi!");
                            personelListView.Items.Clear();
                            personelBilgileriniGuncelle_Load(sender, e);
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




            //try
            //{
            //    using (MySqlConnection baglanti = new MySqlConnection("Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;"))
            //    {
            //        baglanti.Open();

            //        string GirisTarihi = personelGirisTarihiGuncelleDtp.Value.ToString("yyyy-MM-dd");

            //        MySqlCommand komutum = new MySqlCommand("UPDATE Personel SET PersonelAd = '" + personelAdGuncelleTxt.Text + "', PersonelSoyad = '" + personelSoyadGuncelleTxt.Text + "' , " +
            //    "PersonelTc = '" + personelTcGuncelleTxt.Text + "', PersonelTelefon = '" + personelTelefonGuncelleMtb.Text + "', PersonelMail = '" + personelMailGuncelleTxt.Text + "', " +
            //    "PersonelAdres = '" + personelAdresGuncelleTxt.Text + "', PersonelDepartmanAdi = '" + personelDepartmanAdiGuncelleTxt.Text + "', PersonelGorev = '" + personelGorevGuncelleTxt.Text + "', " +
            //    "PersonelGirisTarihi = '" + GirisTarihi + "', " + "' WHERE PersonelId = " + personelIdGuncelleTxt.Text + "");
            //        komutum.Connection = baglanti;
            //        komutum.ExecuteNonQuery();


            //        //oku
            //        foreach (ListViewItem item in personelListView.Items)
            //        {
            //            if (item.SubItems[0].Text == personelIdGuncelleTxt.Text)
            //            {
            //                item.SubItems[1].Text = personelAdGuncelleTxt.Text;
            //                item.SubItems[2].Text = personelSoyadGuncelleTxt.Text;
            //                item.SubItems[3].Text = personelTcGuncelleTxt.Text;
            //                item.SubItems[4].Text = personelTelefonGuncelleMtb.Text;
            //                item.SubItems[5].Text = personelMailGuncelleTxt.Text;
            //                item.SubItems[6].Text = personelAdresGuncelleTxt.Text;
            //                item.SubItems[7].Text = personelDepartmanAdiGuncelleTxt.Text;
            //                item.SubItems[8].Text = personelGorevGuncelleTxt.Text;
            //                item.SubItems[9].Text = GirisTarihi;
            //            }
            //        }
            //        MySqlCommand komut = new MySqlCommand("SELECT * FROM Personel ");
            //        komut.Connection = baglanti;
            //        MySqlDataReader okunanlar = komut.ExecuteReader();

            //        MessageBox.Show("Güncelleme Başarılı!");
            //        baglanti.Close();



            //        //MySqlCommand komutum = new MySqlCommand("UPDATE Personel SET PersonelAd = @Ad, PersonelSoyad = @Soyad, PersonelTc = @Tc, PersonelTelefon = @Telefon, PersonelMail = @Mail, PersonelAdres = @Adres, PersonelDepartmanAdi = @DepartmanAdi, PersonelGorev = @Gorev, PersonelGirisTarihi = @GirisTarihi WHERE PersonelId = @Id", baglanti);
            //        //komutum.Parameters.AddWithValue("@Ad", personelAdGuncelleTxt.Text);
            //        //komutum.Parameters.AddWithValue("@Soyad", personelSoyadGuncelleTxt.Text);
            //        //komutum.Parameters.AddWithValue("@Tc", personelTcGuncelleTxt.Text);
            //        //komutum.Parameters.AddWithValue("@Telefon", personelTelefonGuncelleMtb.Text);
            //        //komutum.Parameters.AddWithValue("@Mail", personelMailGuncelleTxt.Text);
            //        //komutum.Parameters.AddWithValue("@Adres", personelAdresGuncelleTxt.Text);
            //        //komutum.Parameters.AddWithValue("@DepartmanAdi", personelDepartmanAdiGuncelleTxt.Text);
            //        //komutum.Parameters.AddWithValue("@Gorev", personelGorevGuncelleTxt.Text);
            //        //komutum.Parameters.AddWithValue("@GirisTarihi", GirisTarihi);
            //        //komutum.Parameters.AddWithValue("@Id", id);

            //        //komutum.ExecuteNonQuery();

            //        //MessageBox.Show("Personel Başarı İle Güncellendi!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hata!! " + ex.Message);
            //}
        }

        private void personelBilgileriniGuncelle_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA";
            string query = "SELECT * FROM Personel";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    personelListView.Items.Clear();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["PersonelId"].ToString());
                        item.SubItems.Add(reader["PersonelAd"].ToString());
                        item.SubItems.Add(reader["PersonelSoyad"].ToString());
                        item.SubItems.Add(reader["PersonelTc"].ToString());
                        item.SubItems.Add(reader["PersonelTelefon"].ToString());
                        item.SubItems.Add(reader["PersonelMail"].ToString());
                        item.SubItems.Add(reader["PersonelAdres"].ToString());
                        item.SubItems.Add(reader["PersonelDepartmanAdi"].ToString());
                        item.SubItems.Add(reader["PersonelGorev"].ToString());

                        item.SubItems.Add(reader["PersonelMaas"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["PersonelGirisTarihi"]).ToString("dd.MM.yyyy"));
                        personelListView.Items.Add(item);
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

        private void personelListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        int id = 0;
        private void personelListView_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(personelListView.SelectedItems[0].SubItems[0].Text);
            personelAdGuncelleTxt.Text = personelListView.SelectedItems[0].SubItems[1].Text;
            personelSoyadGuncelleTxt.Text = personelListView.SelectedItems[0].SubItems[2].Text;
            personelTcGuncelleTxt.Text = personelListView.SelectedItems[0].SubItems[3].Text;
            personelTelefonGuncelleMtb.Text = personelListView.SelectedItems[0].SubItems[4].Text;
            personelMailGuncelleTxt.Text = personelListView.SelectedItems[0].SubItems[5].Text;
            personelAdresGuncelleTxt.Text = personelListView.SelectedItems[0].SubItems[6].Text;
            personelDepartmanAdiGuncelleTxt.Text = personelListView.SelectedItems[0].SubItems[7].Text;
            personelGorevGuncelleTxt.Text = personelListView.SelectedItems[0].SubItems[8].Text;
            personelMaasGuncelleTxt.Text = personelListView.SelectedItems[0].SubItems[9].Text;
            personelGirisTarihiGuncelleDtp.Text = personelListView.SelectedItems[0].SubItems[10].Text;
        }

        private void adAraButton_Click(object sender, EventArgs e)
        {
            personelListView.Items.Clear();
            string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA";
            string query = "SELECT * FROM Personel WHERE PersonelAd LIKE @PersonelAd";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PersonelAd", "%" + adAraTextBox.Text + "%");
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["PersonelId"].ToString());
                        item.SubItems.Add(reader["PersonelAd"].ToString());
                        item.SubItems.Add(reader["PersonelSoyad"].ToString());
                        item.SubItems.Add(reader["PersonelTc"].ToString());
                        item.SubItems.Add(reader["PersonelTelefon"].ToString());
                        item.SubItems.Add(reader["PersonelMail"].ToString());
                        item.SubItems.Add(reader["PersonelAdres"].ToString());
                        item.SubItems.Add(reader["PersonelDepartmanAdi"].ToString());
                        item.SubItems.Add(reader["PersonelGorev"].ToString());
                        item.SubItems.Add(reader["PersonelMaas"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["PersonelGirisTarihi"]).ToString("dd.MM.yyyy"));

                        personelListView.Items.Add(item);
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
