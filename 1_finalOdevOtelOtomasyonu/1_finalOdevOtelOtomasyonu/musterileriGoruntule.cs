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
    public partial class musterileriGoruntule : Form
    {
        public musterileriGoruntule()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void musterileriGoruntule_Load(object sender, EventArgs e)
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

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekme hatası: " + ex.Message);
                    connection.Close();
                }


                string odaTipi = "";
                string odaDurumu = "";
            }
        }
        private void listView2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    MySqlConnection baglanti = new MySqlConnection("Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;");
            //    baglanti.Open();

            //    string girisTarihi = girisTarihiGuncelleDtp.Value.ToString("yyyy-MM-dd");
            //    string cikisTarihi = cikisTarihiGuncelleDtp.Value.ToString("yyyy-MM-dd");

            //    MySqlCommand komutum = new MySqlCommand("UPDATE Musteriler SET MusteriAd = '" + adGuncelleTextBox.Text + "', MusteriSoyad = '" + soyadGuncelleTextBox.Text + "' , " +
            //    "MusteriTelefon = '" + telefonGuncelleMtb.Text + "', MusteriMail = '" + mailGuncelleTextBox.Text + "', MusteriTc = '" + tcGuncelleTextBox.Text + "', " +
            //    "MusteriCinsiyet = '" + cinsiyetGuncelleComboBox.Text + "', MusteriOdaNumarasi = '" + odaNumarasiGuncelleTextBox.Text + "', MusteriUcret = '" + ucretGuncelleTextBox.Text + "', " + "MusteriGirisTarihi = '" + girisTarihi + "', " +
            //    "MusteriCikisTarihi = '" + cikisTarihi + "' WHERE MusteriId = " + idGuncelleTextBox.Text + "");
            //    komutum.Connection = baglanti;
            //    komutum.ExecuteNonQuery();


            //    //oku
            //    foreach (ListViewItem item in listView1.Items)
            //    {
            //        if (item.SubItems[0].Text == idGuncelleTextBox.Text)
            //        {
            //            item.SubItems[1].Text = adGuncelleTextBox.Text;
            //            item.SubItems[2].Text = soyadGuncelleTextBox.Text;
            //            item.SubItems[3].Text = telefonGuncelleMtb.Text;
            //            item.SubItems[4].Text = mailGuncelleTextBox.Text;
            //            item.SubItems[5].Text = tcGuncelleTextBox.Text;
            //            item.SubItems[6].Text = cinsiyetGuncelleComboBox.Text;
            //            item.SubItems[7].Text = odaNumarasiGuncelleTextBox.Text;
            //            item.SubItems[8].Text = girisTarihi;
            //            item.SubItems[9].Text = cikisTarihi;
            //            item.SubItems[10].Text = ucretGuncelleTextBox.Text;
            //        }
            //    }
            //    MySqlCommand komut = new MySqlCommand("SELECT * FROM Musteriler ");
            //    komut.Connection = baglanti;
            //    MySqlDataReader okunanlar = komut.ExecuteReader();

            //    MessageBox.Show("Güncelleme Başarılı!");
            //    baglanti.Close();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Bağlantıda Hata Var! " + ex.Message);
            //}

        }

        private void ucretTxt_TextChanged(object sender, EventArgs e)
        {

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
        }

        private void personelBilgileriniGuncelleBtn_Click(object sender, EventArgs e)
        {

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

        private void personelBilgileriniSilBtn_Click(object sender, EventArgs e)
        {
            //musteriBilgileriniGuncelleGroupBox.Visible = true;
            //musteriBilgileriniGuncelleGroupBox.BringToFront();
            //musteriBilgileriniSilGroupBox.Visible = false;
        }

        private void personelBilgileriniBtn_Click(object sender, EventArgs e)
        {
            //musteriBilgileriniSilGroupBox.Visible = true;
            //musteriBilgileriniSilGroupBox.BringToFront();
            //musteriBilgileriniGuncelleGroupBox.Visible = false;
        }

        private void musteriGuncelleBtn_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection baglanti = new MySqlConnection("Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;");
                baglanti.Open();

                string girisTarihi = girisTarihiGuncelleDtp.Value.ToString("yyyy-MM-dd");
                string cikisTarihi = cikisTarihiGuncelleDtp.Value.ToString("yyyy-MM-dd");

                MySqlCommand komutum = new MySqlCommand("UPDATE Musteriler SET MusteriAd = '" + adGuncelleTextBox.Text + "', MusteriSoyad = '" + soyadGuncelleTextBox.Text + "' , " +
                "MusteriTelefon = '" + telefonGuncelleMtb.Text + "', MusteriMail = '" + mailGuncelleTextBox.Text + "', MusteriTc = '" + tcGuncelleTextBox.Text + "', " +
                "MusteriCinsiyet = '" + cinsiyetGuncelleComboBox.Text + "', MusteriOdaNumarasi = '" + odaNumarasiGuncelleTextBox.Text + "', MusteriUcret = '" + ucretGuncelleTextBox.Text + "', " + "MusteriGirisTarihi = '" + girisTarihi + "', " +
                "MusteriCikisTarihi = '" + cikisTarihi + "' WHERE MusteriId = " + idGuncelleTextBox.Text + "");
                komutum.Connection = baglanti;
                komutum.ExecuteNonQuery();


                //oku
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[0].Text == idGuncelleTextBox.Text)
                    {
                        item.SubItems[1].Text = adGuncelleTextBox.Text;
                        item.SubItems[2].Text = soyadGuncelleTextBox.Text;
                        item.SubItems[3].Text = telefonGuncelleMtb.Text;
                        item.SubItems[4].Text = mailGuncelleTextBox.Text;
                        item.SubItems[5].Text = tcGuncelleTextBox.Text;
                        item.SubItems[6].Text = cinsiyetGuncelleComboBox.Text;
                        item.SubItems[7].Text = odaNumarasiGuncelleTextBox.Text;
                        item.SubItems[8].Text = girisTarihi;
                        item.SubItems[9].Text = cikisTarihi;
                        item.SubItems[10].Text = ucretGuncelleTextBox.Text;
                    }
                }
                MySqlCommand komut = new MySqlCommand("SELECT * FROM Musteriler ");
                komut.Connection = baglanti;
                MySqlDataReader okunanlar = komut.ExecuteReader();

                MessageBox.Show("Güncelleme Başarılı!");
                baglanti.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantıda Hata Var! " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            musterileriGoruntule fr = new musterileriGoruntule();
            fr.Show();
            this.Hide();
        }

        int id = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            adGuncelleTextBox.Text = listView1.SelectedItems[0].SubItems[1].Text;
            soyadGuncelleTextBox.Text = listView1.SelectedItems[0].SubItems[2].Text;
            telefonGuncelleMtb.Text = listView1.SelectedItems[0].SubItems[3].Text;
            mailGuncelleTextBox.Text = listView1.SelectedItems[0].SubItems[4].Text;
            tcGuncelleTextBox.Text = listView1.SelectedItems[0].SubItems[5].Text;
            cinsiyetGuncelleComboBox.Text = listView1.SelectedItems[0].SubItems[6].Text;
            odaNumarasiGuncelleTextBox.Text = listView1.SelectedItems[0].SubItems[7].Text;

            DateTime girisTarihi;
            if (DateTime.TryParse(listView1.SelectedItems[0].SubItems[8].Text, out girisTarihi))
            {
                girisTarihiGuncelleDtp.Value = girisTarihi;
            }
            else
            {
                // Handle the error, e.g., show a message to the user
                MessageBox.Show("Geçersiz giriş tarihi formatı.");
            }

            DateTime cikisTarihi;
            if (DateTime.TryParse(listView1.SelectedItems[0].SubItems[9].Text, out cikisTarihi))
            {
                cikisTarihiGuncelleDtp.Value = cikisTarihi;
            }
            else
            {
                // Handle the error, e.g., show a message to the user
                MessageBox.Show("Geçersiz çıkış tarihi formatı.");
            }

            ucretGuncelleTextBox.Text = listView1.SelectedItems[0].SubItems[10].Text;
        }

        private void musteriAraButton_Click(object sender, EventArgs e)
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
                    command.Parameters.AddWithValue("@MusteriAd", "%" + musteriAraTxt.Text + "%");
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

        private void musteriBilgileriniGuncelleGroupBox_Enter(object sender, EventArgs e)
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
                    command.Parameters.AddWithValue("@MusteriAd", "%" + musteriAraTxt.Text + "%");
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
    }

}
