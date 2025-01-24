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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _1_finalOdevOtelOtomasyonu
{
    public partial class duyurular : Form
    {
        public duyurular()
        {
            InitializeComponent();
        }
        string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;";

        private void duyurular_Load(object sender, EventArgs e)
        {
            ListeleDuyurular();
        }


        private void ListeleDuyurular()
        {
            lvDuyurular.Items.Clear(); // Önce mevcut veriyi temizle

            string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Duyurular ORDER BY Tarih DESC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ListViewItem item = new ListViewItem(dr["DuyuruId"].ToString());
                            item.SubItems.Add(dr["Baslik"].ToString());
                            item.SubItems.Add(dr["Icerik"].ToString());
                            item.SubItems.Add(Convert.ToDateTime(dr["Tarih"]).ToString("dd-MM-yyyy"));
                            item.SubItems.Add(dr["Oncelik"].ToString());
                            lvDuyurular.Items.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekme hatası: " + ex.Message);
                }
            }
        }





        private void duyuruEkleBtn_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Duyurular (Baslik, Icerik, Tarih, Oncelik) VALUES (@Baslik, @Icerik, @Tarih, @Oncelik)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Baslik", richTextBoxBaslik.Text);
                    cmd.Parameters.AddWithValue("@Icerik", richTextBoxDuyuru.Text);
                    cmd.Parameters.AddWithValue("@Tarih", dateTimePickerDuyuru.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Oncelik", comboBoxOncelik.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Duyuru eklendi.");
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            lvDuyurular.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Duyurular ORDER BY Tarih DESC";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListViewItem item = new ListViewItem(dr["DuyuruId"].ToString());
                        item.SubItems.Add(dr["Baslik"].ToString());
                        item.SubItems.Add(dr["Icerik"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(dr["Tarih"]).ToString("dd-MM-yyyy"));
                        lvDuyurular.Items.Add(item);
                    }
                }
            }
        }

        private void duyuruSilBtn_Click(object sender, EventArgs e)
        {
            if (lvDuyurular.SelectedItems.Count > 0)
            {
                string duyuruId = lvDuyurular.SelectedItems[0].SubItems[0].Text;
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Duyurular WHERE DuyuruId=@DuyuruId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DuyuruId", duyuruId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Duyuru silindi.");
                    btnListele_Click(sender, e); // Listeyi güncelle
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek duyuruyu seçin.");
            }
        }

        private void duyuruGuncelleBtn_Click(object sender, EventArgs e)
        {
            if (lvDuyurular.SelectedItems.Count > 0)
            {
                string duyuruId = lvDuyurular.SelectedItems[0].SubItems[0].Text;
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Duyurular SET Baslik=@Baslik, Icerik=@Icerik, Tarih=@Tarih WHERE DuyuruId=@DuyuruId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Baslik", richTextBoxBaslik.Text);
                        cmd.Parameters.AddWithValue("@Icerik", richTextBoxDuyuru.Text);
                        cmd.Parameters.AddWithValue("@Tarih", dateTimePickerDuyuru.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@DuyuruId", duyuruId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Duyuru güncellendi.");
                    btnListele_Click(sender, e); // Listeyi güncelle
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek duyuruyu seçin.");
            }
        }

        private void lvDuyurular_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvDuyurular_DoubleClick(object sender, EventArgs e)
        {
            if (lvDuyurular.SelectedItems.Count > 0)
            {
                var selectedItem = lvDuyurular.SelectedItems[0];
                if (selectedItem.SubItems.Count >= 5)
                {
                    int duyuruId = int.Parse(selectedItem.SubItems[0].Text);
                    richTextBoxBaslik.Text = selectedItem.SubItems[1].Text;
                    richTextBoxDuyuru.Text = selectedItem.SubItems[2].Text;
                    dateTimePickerDuyuru.Text = selectedItem.SubItems[3].Text;
                    comboBoxOncelik.Text = selectedItem.SubItems[4].Text;
                }
                else
                {
                    // Handle the case where there are not enough sub-items
                    MessageBox.Show("The selected item does not have enough details.");
                }
            }
        }

        private void yoneticiBilgileriBtn_Click(object sender, EventArgs e)
        {
            duyurular fr = new duyurular();
            fr.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            anaForm fr = new anaForm();
            fr.Show();
            this.Hide();
        }
    }
}
