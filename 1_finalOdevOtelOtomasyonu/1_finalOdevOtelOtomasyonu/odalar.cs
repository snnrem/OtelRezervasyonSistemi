using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _1_finalOdevOtelOtomasyonu
{
    public partial class odalar : Form
    {
        public odalar()
        {
            InitializeComponent();
        }



        private void odalar_Load(object sender, EventArgs e)
        {
            //        string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;";

            //        using (MySqlConnection connection = new MySqlConnection(connectionString))
            //        {

            //            try
            //            {
            //                connection.Open();
            //                string query = "SELECT OdaNo, Durum, RezerveEden FROM Odalar";
            //                using (MySqlCommand command = new MySqlCommand(query, connection))
            //                using (MySqlDataReader reader = command.ExecuteReader())
            //                {
            //                    while (reader.Read())
            //                    {
            //                        int odaNo = reader.GetInt32("OdaNo");
            //                        int durum = reader.GetInt32("Durum");
            //                        string rezerveEden = reader.IsDBNull(2) ? "" : reader.GetString("RezerveEden");

            //                        // Oda numarasına göre buton bulma
            //                        Button btn = Controls.Find("btn" + odaNo, true).FirstOrDefault() as Button;
            //                        if (btn != null)
            //                        {
            //                            if (durum == 1) // Oda dolu
            //                            {
            //                                btn.BackColor = Color.Red;
            //                                btn.Text = $"{odaNo}\n{rezerveEden}";
            //                            }
            //                            else // Oda boş
            //                            {
            //                                btn.BackColor = Color.Green;
            //                                btn.Text = odaNo.ToString();
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show("Hata: " + ex.Message);
            //            }
            //        }
            //    }

            //    private void button1_Click(object sender, EventArgs e)
            //    {
            //        string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;";
            //        Button btn = sender as Button;
            //        if (btn != null)
            //        {
            //            int odaNo = int.Parse(btn.Text.Split('\n')[0]); // Oda numarasını al

            //            using (MySqlConnection connection = new MySqlConnection(connectionString))
            //            {
            //                try
            //                {
            //                    connection.Open();
            //                    string query = "UPDATE odalar SET Durum = 1, RezerveEden = @RezerveEden WHERE OdaNo = @OdaNo";
            //                    using (MySqlCommand command = new MySqlCommand(query, connection))
            //                    {
            //                        command.Parameters.AddWithValue("@RezerveEden", "Müşteri Adı"); // Müşteri adını buradan alabilirsiniz
            //                        command.Parameters.AddWithValue("@OdaNo", odaNo);
            //                        command.ExecuteNonQuery();
            //                    }

            //                    // Butonu güncelle
            //                    btn.BackColor = Color.Red;
            //                    btn.Text = $"{odaNo}\nMüşteri Adı"; // Müşteri adı buraya eklenir
            //                    MessageBox.Show($"{odaNo} numaralı oda rezerve edildi!");
            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show("Hata: " + ex.Message);
            //                }
            //            }
            //        }
              }
        private void button110_Click(object sender, EventArgs e)
        {
            anaForm fr = new anaForm();
            fr.Show();
            this.Hide();
        }

        private void yeniEkleBtn_Click(object sender, EventArgs e)
        {

        }

        private void button111_Click(object sender, EventArgs e)
        {
           
        }

        private void button109_Click(object sender, EventArgs e)
        {
           
        }

        private void button110_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button112_Click(object sender, EventArgs e)
        {
           
        }
    }
    }
