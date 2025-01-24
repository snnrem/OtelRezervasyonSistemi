using _1_finalOdevOtelOtomasyonu.DOMAIN;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_finalOdevOtelOtomasyonu.DAL
{
    internal class PersonelDAO
    {
        public void PersonelKaydet(personel gPersonel)
        {
            new MySqlCommand("INSERT INTO Personel (PersonelAd, PersonelSoyad, PersonelTc, PersonelTelefon, PersonelMail, PersonelAdres, PersonelDepartmanAdi, PersonelGorev, PersonelMaas, PersonelGirisTarihi) values ('"+
                gPersonel.PAd + "','" + gPersonel.PSoyad + "','" + gPersonel.PTc + "','" + gPersonel.PTelefon + "','" + gPersonel.PMail + "','" + gPersonel.PAdres + "','" + gPersonel.PDepartmanAdi + "','" + gPersonel.PGorev + "'," + gPersonel.PMaas + ",'" + gPersonel.PGirisTarihi + "')", (new dbBaglanti()).baglantiGetir()).ExecuteNonQuery();
        }


        internal void PersonelGuncelle(int gId, personel personel)
        {
            throw new NotImplementedException();
        }

        internal void PersonelGuncelle(int gId, yonetici yonetici)
        {
            throw new NotImplementedException();
        }

        internal void PersonelSil(int gId)
        {
            throw new NotImplementedException();
        }

        internal void YoneticiKaydet(yonetici yonetici)
        {
            throw new NotImplementedException();
        }


        internal System.Collections.ArrayList personelleriGetir()
        {
            ArrayList okunanPersoneller = new ArrayList();
            //MySqlCommand komutum=new MySqlCommand("select * from bolum", (new dbBaglanti()).baglantiGetir())
            MySqlDataReader okunan = (new MySqlCommand("select * from Personel", (new dbBaglanti()).baglantiGetir())).ExecuteReader();
            while (okunan.Read())
            {
                okunanPersoneller.Add(new Personel(Convert.ToInt32(okunan[0]), okunan[1].ToString(), Convert.ToInt32(okunan[2]), okunan[3].ToString(), okunan[4].ToString(), okunan[5].ToString(), okunan[6].ToString(), okunan[7].ToString(), okunan[7].ToString(),okunan[8].ToString(), okunan[9].ToString()));
            }
            return okunanPersoneller;
        }

        internal void personelSil(int gId)
        {
            (new MySqlCommand("delete from Personel where id=" + gId, (new dbBaglanti()).baglantiGetir())
                ).ExecuteNonQuery();
        }
    }
}
