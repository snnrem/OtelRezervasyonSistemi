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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _1_finalOdevOtelOtomasyonu
{
    public partial class otelPersonelleri : Form
    {
        public otelPersonelleri()
        {
            InitializeComponent();
        }

        private void otelPersonelleri_Load(object sender, EventArgs e)
        {
            //personelBilgileriniGuncelleGroupBox.Visible = false;
            //personelSilGroupBox.Visible = false;
            //personelGroupBox.Visible = false;

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

                }
            }
        }

        private void personelBilgileriniGuncelleButton_Click(object sender, EventArgs e)
        {
           
        }


                //using (MySqlConnection baglanti = new MySqlConnection("Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=inf.ogr22SA;"))
                //{
                //    baglanti.Open();

                //    string PersonelGirisTarihi = personelGirisTarihiGuncelleDtp.Value.ToString("yyyy-MM-dd");

                //    MySqlCommand komut = new MySqlCommand("UPDATE personel SET PersonelAd = @ad, PersonelSoyad = @soyad, PersonelTc = @tc, PersonelTelefon = @telefon, PersonelMail = @mail, PersonelDepartmanId = @departmanId, PersonelGorev = @gorev, PersonelMaas = @maas, PersonelGirisTarihi = @girisTarihi WHERE PersonelId = @id", baglanti);
                //    komut.Parameters.AddWithValue("@ad", personelAdGuncelleTxt.Text);
                //    komut.Parameters.AddWithValue("@soyad", personelSoyadGuncelleTxt.Text);
                //    komut.Parameters.AddWithValue("@tc", personelTcGuncelleTxt.Text);
                //    komut.Parameters.AddWithValue("@telefon", personelTelefonGuncelleMtb.Text);
                //    komut.Parameters.AddWithValue("@mail", personelMailGuncelleTxt.Text);
                //    komut.Parameters.AddWithValue("@departmanId", personelDepartmanAdiGuncelleComboBox.Text);
                //    komut.Parameters.AddWithValue("@gorev", personelGorevGuncelleComboBox.Text);
                //    komut.Parameters.AddWithValue("@maas", personelMaasGuncelleTxt.Text);
                //    komut.Parameters.AddWithValue("@girisTarihi", PersonelGirisTarihi);
                //    komut.Parameters.AddWithValue("@id", personelIdGuncelleTxt.Text);
                //    komut.ExecuteNonQuery();

                //    // ListView'deki personel bilgilerini güncelle
                //    foreach (ListViewItem item in personelListView.Items)
                //    {
                //        if (item.SubItems[0].Text == personelIdGuncelleTxt.Text)
                //        {
                //            item.SubItems[1].Text = personelAdGuncelleTxt.Text;
                //            item.SubItems[2].Text = personelSoyadGuncelleTxt.Text;
                //            item.SubItems[3].Text = personelTcGuncelleTxt.Text;
                //            item.SubItems[4].Text = personelTelefonGuncelleMtb.Text;
                //            item.SubItems[5].Text = personelMailGuncelleTxt.Text;
                //            item.SubItems[6].Text = personelDepartmanAdiGuncelleComboBox.Text;
                //            item.SubItems[7].Text = personelGorevGuncelleComboBox.Text;
                //            item.SubItems[8].Text = personelMaasGuncelleTxt.Text;
                //            item.SubItems[9].Text = PersonelGirisTarihi;
                //        }
                //    }

                //    MessageBox.Show("Güncelleme Başarılı!");
                //}
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Bağlantıda Hata Var! " + ex.Message);
        //    }
        //}

        //    try
        //    {
        //        MySqlConnection baglanti = new MySqlConnection("Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;");
        //        baglanti.Open();

        //        string PersonelGirisTarihi = personelGirisTarihiGuncelleDtp.Value.ToString("yyyy-MM-dd");

        //        MySqlCommand komutum = new MySqlCommand("UPDATE Musteriler SET PersonelAd = '" + personelAdGuncelleTxt.Text + "', PersonelSoyad = '" + personelSoyadGuncelleTxt.Text + "' , " +
        //         "', PersonelTc = '" + personelTcGuncelleTxt.Text + "', " + "PersonelTelefon = '" + personelTelefonGuncelleMtb.Text + "', PersonelMail = '" + personelMailGuncelleTxt.Text +
        //         "', PersonelAdres = '" + personelAdresGuncelleTxt.Text + "PersonelDepartmanAdi = '" + personelDepartmanAdiGuncelleComboBox.Text + "', PersonelGorev = '" + personelGorevGuncelleComboBox.Text
        //         + "', PersonelMaas = '" + personelMaasGuncelleTxt.Text + "', " + "PersonelGirisTarihi = '" + PersonelGirisTarihi + "', " + "' WHERE PersonelId = " + personelIdGuncelleTxt.Text + "");
        //        komutum.Connection = baglanti;
        //        komutum.ExecuteNonQuery();


        //        //oku
        //        foreach (ListViewItem item in personelListView.Items)
        //        {
        //            if (item.SubItems[0].Text == personelIdGuncelleTxt.Text)
        //            {
        //                item.SubItems[1].Text = personelAdGuncelleTxt.Text;
        //                item.SubItems[2].Text = personelSoyadGuncelleTxt.Text;
        //                item.SubItems[5].Text = personelTcGuncelleTxt.Text;
        //                item.SubItems[3].Text = personelTelefonGuncelleMtb.Text;
        //                item.SubItems[4].Text = personelMailGuncelleTxt.Text;
        //                item.SubItems[6].Text = personelAdresGuncelleTxt.Text;
        //                item.SubItems[7].Text = personelDepartmanAdiGuncelleComboBox.Text;
        //                item.SubItems[8].Text = personelGorevGuncelleComboBox.Text;
        //                item.SubItems[9].Text = personelMaasGuncelleTxt.Text;
        //                item.SubItems[10].Text = PersonelGirisTarihi;
        //            }
        //        }
        //        MySqlCommand komut = new MySqlCommand("SELECT * FROM Personel ");
        //        komut.Connection = baglanti;
        //        MySqlDataReader okunanlar = komut.ExecuteReader();

        //        MessageBox.Show("Güncelleme Başarılı!");
        //        baglanti.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Bağlantıda Hata Var! " + ex.Message);
        //    }
        //}

        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            
            //try
            //{

            //    MySqlConnection baglanti =
            //    new MySqlConnection("Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;");
            //    baglanti.Open();

            //    MySqlCommand komutum = new MySqlCommand("DELETE FROM Personel WHERE PersonelId = " + personelSilTextBox.Text + "");
            //    komutum.Connection = baglanti;
            //    komutum.ExecuteNonQuery();

            //    foreach (ListViewItem item in personelListView.Items)
            //    {
            //        if (item.SubItems[0].Text == personelSilTextBox.Text)
            //        {
            //            personelListView.Items.Remove(item);
            //            break;
            //        }
            //    }

            //    MessageBox.Show("Personel Başarı İle Silindi!");
            //    baglanti.Close();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Personel Silinemedi!!");
            //    throw;
            //}
        }
        private void personelKaydetBtn_Click(object sender, EventArgs e)
        {          
            try
            {

                (new PersonelService()).PersonelKaydet(personelAdTxt.Text, personelSoyadTxt.Text, personelTcTxt.Text, personelTelefonMtb.Text, personelMailTxt.Text,
                personelAdresTxt.Text, personelDepartmanAdiComboBox.Text, personelGorevComboBox.Text, personelMaasTxt.Text, DateTime.Parse(personelGirisTarihiDtp.Text));
                int yeniPersonelId = new PersonelService().GetHashCode();
                ListViewItem item = new ListViewItem(yeniPersonelId.ToString());
                item.SubItems.Add(personelAdTxt.Text);
                item.SubItems.Add(personelSoyadTxt.Text);
                item.SubItems.Add(personelTcTxt.Text);
                item.SubItems.Add(personelTelefonMtb.Text);
                item.SubItems.Add(personelMailTxt.Text);
                item.SubItems.Add(personelAdresTxt.Text);
                item.SubItems.Add(personelDepartmanAdiComboBox.Text);
                item.SubItems.Add(personelGorevComboBox.Text);
                item.SubItems.Add(personelMaasTxt.Text);
                item.SubItems.Add(personelGirisTarihiDtp.Text);
                personelListView.Items.Add(item);


                MessageBox.Show("Personel kaydı yapıldı.");
            }
            catch (Exception)
            {
                MessageBox.Show("!!!Personel kaydı yapılamadı!!!");
                throw;
            }
        }

        private void personelBilgileriniGuncelleBtn_Click(object sender, EventArgs e)
        {
            personelBilgileriniGuncelle fr = new personelBilgileriniGuncelle();
            fr.Show();
            this.Hide();
            //personelBilgileriniGuncelleGroupBox.Visible = true;
            //personelBilgileriniGuncelleGroupBox.BringToFront();
            //personelSilGroupBox.Visible = false;
            //personelGroupBox.Visible = false;
        }

        private void yeniPersonelEkleBtn_Click(object sender, EventArgs e)
        {

            otelPersonelleri fr = new otelPersonelleri();
            fr.Show();
            this.Hide();
            //personelGroupBox.Visible = true;
            //personelGroupBox.BringToFront();
            //personelBilgileriniGuncelleGroupBox.Visible = false;
            //personelSilGroupBox.Visible = false;

        }

        private void personelBilgileriniSilBtn_Click(object sender, EventArgs e)
        {
            personelBilgileriSil fr = new personelBilgileriSil();
            fr.Show();
            this.Hide();
            //personelSilGroupBox.Visible = true;
            //personelSilGroupBox.BringToFront();
            //personelBilgileriniGuncelleGroupBox.Visible = false;
            //personelGroupBox.Visible = false;
        }

        private void personelListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            anaForm fr = new anaForm();
            fr.Show();
            this.Hide();
        }

        private void adAraButton_Click(object sender, EventArgs e)
        {

        }

        private void personelTablosuBtn_Click(object sender, EventArgs e)
        {
            personelTablosu fr = new personelTablosu();
            fr.Show();
            this.Hide();
        }
    }
}