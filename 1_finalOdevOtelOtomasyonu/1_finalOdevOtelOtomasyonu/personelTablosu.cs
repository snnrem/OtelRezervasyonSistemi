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
    public partial class personelTablosu : Form
    {
        public personelTablosu()
        {
            InitializeComponent();
        }

        private void personelTablosuBtn_Click(object sender, EventArgs e)
        {
            personelTablosu personelTablosu = new personelTablosu();
            personelTablosu.Show();
            this.Hide();
        }

        private void personelBilgileriniSilBtn_Click(object sender, EventArgs e)
        {
            otelPersonelleri otelPersonelleri = new otelPersonelleri();
            otelPersonelleri.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            anaForm anaForm = new anaForm();
            anaForm.Show();
            this.Hide();
        }

        private void personelTablosu_Load(object sender, EventArgs e)
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

                }
            }
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

        private void personelListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
