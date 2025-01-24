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
    internal class YoneticiDAO
    {
        public void YoneticiKaydet(yonetici gYonetici)
        {
            new MySqlCommand("INSERT INTO Yonetici (YoneticiAd, YoneticiSoyad, YoneticiKullaniciAdi, YoneticiSifre) values ('" +
                gYonetici.YAd + "','" + gYonetici.YSoyad + "','" + gYonetici.YKullaniciAdi + "','" + gYonetici.YSifre + "')", (new dbBaglanti()).baglantiGetir()).ExecuteNonQuery();
        }




        //    internal System.Collections.ArrayList YoneticiGetir()
        //    {
        //        ArrayList okunanUrunler = new ArrayList();
        //        //MySqlCommand komutum=new MySqlCommand("select * from bolum", (new dbBaglanti()).baglantiGetir())
        //        MySqlDataReader okunan = (new MySqlCommand("select * from YoneticiGiris", (new dbBaglanti()).baglantiGetir())).ExecuteReader();
        //        while (okunan.Read())
        //        {
        //            okunanUrunler.Add(new Urun(Convert.ToInt32(okunan[0]), okunan[1].ToString(), Convert.ToDouble(okunan[2]), Convert.ToInt32(okunan[3])));
        //        }
        //        return okunanUrunler;
        //    }

        //    internal void yoneticiSil(int gId)
        //    {
        //        (new MySqlCommand("delete from Musteriler where id=" + gId, (new dbBaglanti()).baglantiGetir())
        //            ).ExecuteNonQuery();
        //    }
    }


}
