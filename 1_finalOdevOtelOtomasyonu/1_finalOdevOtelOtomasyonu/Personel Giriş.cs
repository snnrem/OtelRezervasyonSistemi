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
    public partial class Personel_Giriş : Form
    {
        public Personel_Giriş()
        {
            InitializeComponent();
        }


        private void girisYapBtn_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlConnection baglanti = new MySqlConnection("Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA;");
                baglanti.Open();
                string sql = "SELECT * FROM YoneticiGiris WHERE YoneticiKullaniciAdi=@kullaniciAdi AND YoneticiSifre=@sifre";
                MySqlParameter prm1 = new MySqlParameter("kullaniciAdi", kullaniciAdiTxt.Text.Trim());
                MySqlParameter prm2 = new MySqlParameter("sifre", sifreTxt.Text.Trim());
                MySqlCommand cmd = new MySqlCommand(sql, baglanti);
                cmd.Parameters.Add(prm1);
                cmd.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    anaForm fr = new anaForm();
                    fr.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı!");
                }
                baglanti.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }



            //string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA";
            //string username = kullaniciAdiTxt.Text;
            //string password = sifreTxt.Text;
            //using (MySqlConnection conn = new MySqlConnection(connectionString))
            //{
            //    try
            //    {
            //        conn.Open();
            //        string query = "SELECT YoneticiAdi FROM YoneticiGiris WHERE YoneticiKullaniciAdi=@username AND YoneticiSifre=@password";
            //        using (MySqlCommand cmd = new MySqlCommand(query, conn))
            //        {
            //            cmd.Parameters.AddWithValue("@username", username);
            //            cmd.Parameters.AddWithValue("@password", password);
            //            object result = cmd.ExecuteScalar();
            //            if (result != null)
            //            {
            //                string adminName = result.ToString();
            //                label2.Text = adminName;

            //            }
            //            else
            //            {
            //                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //            }

            //        }
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("$Bir Hata Oluştu: { ex.Message}", "Hata:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        throw;
            //    }
            //}



        //    string connectionString = "Server=172.21.54.253;Database=25_132330122;User=25_132330122;Password=!nif.ogr22SA";
        //    string username = kullaniciAdiTxt.Text; // Kullanıcı adı giriş alanından alınır
        //    string password = sifreTxt.Text; // Şifre giriş alanından alınır

        //    using (MySqlConnection conn = new MySqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            string query = "SELECT YoneticiAdi, YoneticiSoyadi FROM YoneticiGiris WHERE YoneticiKullaniciAdi = @username AND YoneticiSifre = @password";

        //            using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@username", username);
        //                cmd.Parameters.AddWithValue("@password", password);

        //                using (MySqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        string adminName = reader["YoneticiAdi"].ToString();
        //                        string adminSurname = reader["YoneticiSoyadi"].ToString();

        //                        label22.Text = $"Hoş geldiniz, {adminName} {adminSurname}!";

        //                        // ListView'e yönetici bilgilerini ekleme
        //                        //ListViewItem item = new ListViewItem(adminName);
        //                        //item.SubItems.Add(adminSurname);
        //                        //listView1.Items.Add(item);
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sifreYenile fr = new sifreYenile();
            fr.Show();
            this.Hide();
        }

        private void Personel_Giriş_Load(object sender, EventArgs e)
        {

        }
    }
}
