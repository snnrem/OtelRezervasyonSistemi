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
    public partial class odaDurumu : Form
    {
        public odaDurumu()
        {
            InitializeComponent();
        }

        private void button109_Click(object sender, EventArgs e)
        {
            odaDurumu od = new odaDurumu();
            od.Show();
            this.Hide();
        }

        

        private void button110_Click(object sender, EventArgs e)
        {
            anaForm fr = new anaForm();
            fr.Show();
            this.Hide();
        }

        private void odaDurumu_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA";
            string query = "SELECT * FROM Odalar";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    odalarListView.Items.Clear();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["OdaNumarasi"].ToString());
                        item.SubItems.Add(reader["Durum"].ToString());
                        item.SubItems.Add(reader["OdaTuru"].ToString());
                        item.SubItems.Add(reader["OdaFiyat"].ToString());
                        odalarListView.Items.Add(item);
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

        private void odalarListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void yoneticiGuncelleBtn_Click(object sender, EventArgs e)
        {
            // Form kontrollerinden değerleri alın
            string odaNumarasi = odaNoGuncelleTxt.Text; // Oda numarasını aldığınız kontrol
            int yeniFiyat = int.Parse(odaFiyatGuncelleTxt.Text); // Yeni fiyatı aldığınız kontrol
            int yeniDurum = int.Parse(odaDurumGuncelleTxt.Text); // Yeni durumu aldığınız kontrol

            // Oda bilgilerini güncelle
            OdaBilgileriniGuncelle(odaNumarasi, yeniFiyat, yeniDurum);
        }

        public void OdaBilgileriniGuncelle(string odaNumarasi, int yeniFiyat, int yeniDurum)
        {
            string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA";
            MySqlConnection connection = new MySqlConnection(connectionString);

            // Oda fiyatı ve durumu güncelleme SQL sorgusu
            string query = "UPDATE Odalar SET OdaFiyat = @OdaFiyat, Durum = @Durum WHERE OdaNumarasi = @OdaNumarasi";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@OdaNumarasi", odaNumarasi);
            command.Parameters.AddWithValue("@OdaFiyat", yeniFiyat);
            command.Parameters.AddWithValue("@Durum", yeniDurum);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();  // Veritabanında güncelleme işlemi
                MessageBox.Show("Oda bilgileri güncellendi.");

                // ListView'i güncelle
                ListViewItem item = odalarListView.Items.Cast<ListViewItem>()
                                    .FirstOrDefault(i => i.Text == odaNumarasi);
                if (item != null)
                {
                    item.SubItems[3].Text = yeniFiyat.ToString();
                    item.SubItems[1].Text = yeniDurum.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button112_Click(object sender, EventArgs e)
        {
            odaBilgileriGuncelle fr = new odaBilgileriGuncelle();
            fr.Show();
            this.Hide();
        }
    }
}
