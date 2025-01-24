using _1_finalOdevOtelOtomasyonu.DOMAIN;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Datatypes.Scalar.Types;
using static System.Net.Mime.MediaTypeNames;

namespace _1_finalOdevOtelOtomasyonu.DAL
{
    public class MusterilerDAO
    {

        public void MusterileriKaydet(musteriler gMusteriler)
        {
            using (var connection = (new dbBaglanti()).baglantiGetir())
            {
                var command = new MySqlCommand("INSERT INTO Musteriler (MusteriAd, MusteriSoyad, MusteriTelefon, MusteriMail, MusteriTc, MusteriCinsiyet, MusteriOdaNumarasi, MusteriUcret, MusteriGirisTarihi, MusteriCikisTarihi) VALUES (@Ad, @Soyad, @Telefon, @Mail, @Tc, @Cinsiyet, @OdaNumarasi, @Ucret, @GirisTarihi, @CikisTarihi)", connection);
                command.Parameters.AddWithValue("@Ad", gMusteriler.Ad);
                command.Parameters.AddWithValue("@Soyad", gMusteriler.Soyad);
                command.Parameters.AddWithValue("@Telefon", gMusteriler.Telefon);
                command.Parameters.AddWithValue("@Mail", gMusteriler.Mail);
                command.Parameters.AddWithValue("@Tc", gMusteriler.Tc);
                command.Parameters.AddWithValue("@Cinsiyet", gMusteriler.Cinsiyet);
                command.Parameters.AddWithValue("@OdaNumarasi", gMusteriler.OdaNumarasi);
                command.Parameters.AddWithValue("@Ucret", gMusteriler.Ucret);
                command.Parameters.AddWithValue("@GirisTarihi", gMusteriler.GirisTarihi);
                command.Parameters.AddWithValue("@CikisTarihi", gMusteriler.CikisTarihi);

                command.ExecuteNonQuery();
                connection.Close();
            }
            
        }


       
        internal void MusterileriSil(int gId)
        {
            (new MySqlCommand("delete from Musteriler where id=" + gId, (new dbBaglanti()).baglantiGetir())
                ).ExecuteNonQuery();
        }

        internal ArrayList MusterileriGetir()
        {
            throw new NotImplementedException();
        }

        internal void MusteriSil(int gId)
        {
            throw new NotImplementedException();
        }

        internal System.Collections.ArrayList urunleriGetir()
        {
            ArrayList okunanUrunler = new ArrayList();
            //MySqlCommand komutum=new MySqlCommand("select * from bolum", (new dbBaglanti()).baglantiGetir())
            MySqlDataReader okunan = (new MySqlCommand("select * from urunler", (new dbBaglanti()).baglantiGetir())).ExecuteReader();
            while (okunan.Read())
            {
                okunanUrunler.Add(new musteriler(Convert.ToInt32(okunan[0]), okunan[1].ToString(), Convert.ToDouble(okunan[2]), Convert.ToInt32(okunan[3]), okunan[4].ToString(), okunan[5].ToString(), okunan[6].ToString(), okunan[7].ToString(), okunan[7].ToString(), okunan[8].ToString(), okunan[9].ToString()));
            }
            return okunanUrunler;
        }

    }
}
