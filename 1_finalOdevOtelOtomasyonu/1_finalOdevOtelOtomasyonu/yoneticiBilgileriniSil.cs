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
    public partial class yoneticiBilgileriniSil : Form
    {
        public yoneticiBilgileriniSil()
        {
            InitializeComponent();
        }

        private void yoneticiBilgileriniSil_Load(object sender, EventArgs e)
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
        

        private void yoneticiSil_Click(object sender, EventArgs e)
        {
            yoneticiBilgileriniSil fr = new yoneticiBilgileriniSil();
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

        private void yoneticiSilBtn_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection baglanti = new MySqlConnection("Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;");
                baglanti.Open();

                MySqlCommand komutum = new MySqlCommand("DELETE FROM YoneticiGiris WHERE YoneticiId = " + yoneticiIdSilTxt.Text + "");
                komutum.Connection = baglanti;
                komutum.ExecuteNonQuery();
                baglanti.Close();

                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[0].Text == yoneticiIdSilTxt.Text)
                    {
                        listView1.Items.Remove(item);
                        break;
                    }
                }

                MessageBox.Show("Yönetici Başarı İle Silindi!");
                baglanti.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Yönetici Silinemedi!!");
                throw;
            }
        }
    }
}
